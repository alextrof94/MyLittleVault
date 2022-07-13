using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace MyLittleVault
{
	public partial class Form1 : Form
	{
		readonly string AppName = "MyLittleVault";
		readonly string Version = "1.0";
		readonly string Author = "alextrof94@gmail.com";

		readonly RegistryKey RegistryKeyAutorun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		private List<ToolStripMenuItem> GeneratedRootMenuItems = new List<ToolStripMenuItem>();

		public Form1()
		{
			this.ShowInTaskbar = false;
			this.Opacity = 0;
			this.Shown += HideWindowCompletely;
			InitializeComponent();
			NotifyIcon.Text = AppName + " v" + Version + "\r\nAuthor: " + Author;
			CheckAutostart();
			OpenFile(true);
		}

		private void CheckAutostart()
		{
			ToolStripMenuItemAutostart.Checked = (RegistryKeyAutorun.GetValue(AppName) != null);
		}

		private void HideWindowCompletely(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void OpenFile(bool initializing)
		{
			string path;
			if (initializing)
			{
				path = Properties.Settings.Default.FilePath;
				if (!File.Exists(path))
				{
					MessageBox.Show("Файл отсутствует. Откройте новый файл. Прежний путь:\r\n" + (string.IsNullOrEmpty(path) ? "Путь отсутствует" : path));
					OpenFile(false);
					return;
				}
			}
			else
			{
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = AppName + " files (*.mvl, *.mlvenc)|*.mlv;*.mlvenc";
				ofd.Title = AppName + " - Открыть файл";
				ofd.Multiselect = false;
				if (ofd.ShowDialog() == DialogResult.Cancel)
				{
					MessageBox.Show("Отменено", AppName);
					return;
				}
				path = ofd.FileName;

				if (Path.GetExtension(path) == ".mlvenc")
				{
					path = DecryptFile(path);
					if (string.IsNullOrEmpty(path))
					{
						MessageBox.Show("Отменено", AppName);
						SetButtonsEnabled(false);
						return;
					}
				}
			}
			DeserializeFile(path);
		}

		private string DecryptFile(string path)
		{
			string newPath;

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = AppName + " File (*.mlv)|*.mlv";
			sfd.Title = AppName + " - Сохранить расшифрованный файл";
			if (sfd.ShowDialog() == DialogResult.Cancel)
			{
				return null;
			}
			newPath = sfd.FileName;

			string password = "";
			PasswordInput passwordInputForm = new PasswordInput();
			DialogResult dialogResult = passwordInputForm.ShowDialog();

			if (dialogResult == DialogResult.OK)
				password = passwordInputForm.Password;
			passwordInputForm.Dispose();

			if (dialogResult != DialogResult.OK)
			{
				return null;
			}

			try
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open))
				{
					using (Aes aes = Aes.Create())
					{
						byte[] iv = new byte[aes.IV.Length];
						int numBytesToRead = aes.IV.Length;
						int numBytesRead = 0;
						while (numBytesToRead > 0)
						{
							int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
							if (n == 0) break;

							numBytesRead += n;
							numBytesToRead -= n;
						}

						if (password.Length > 32)
							password = password.Substring(0, 31);
						while (password.Length < 32)
							password += "0";
						byte[] key = Encoding.UTF8.GetBytes(password);

						using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
						{
							using (StreamReader decryptReader = new StreamReader(cryptoStream))
							{
								string decryptedMessage = decryptReader.ReadToEnd();
								File.WriteAllText(newPath, decryptedMessage);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка при попытке расшифровать файл:" + ex.Message, AppName);
				newPath = null;
			}

			return newPath;
		}

		private void DeserializeFile(string path)
		{
			try
			{
				foreach(ToolStripMenuItem oldItem in GeneratedRootMenuItems)
					NotifyIconContextMenuStrip.Items.Remove(oldItem);
				GeneratedRootMenuItems.Clear();

				string json = File.ReadAllText(path).Replace("\r\n", "");
				MlvMenuItemRoot MenuItemRoot = JsonConvert.DeserializeObject<MlvMenuItemRoot>(json);

				GenerateMenuItemsFromRoot(MenuItemRoot);

				if (Properties.Settings.Default.FilePath != path)
				{
					Properties.Settings.Default.FilePath = path;
					Properties.Settings.Default.Save();
				}
				SetButtonsEnabled(true);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при открытии файла. Путь:\r\n" + path + "\r\n" + ex.Message);
			}
		}

		private void SetButtonsEnabled(bool enabled)
		{
			MenuItemEncrypt.Enabled = enabled;
			MenuItemCopyPath.Enabled = enabled;
		}

		private void GenerateMenuItemsFromRoot(MlvMenuItemRoot menuItemRoot)
		{
			foreach (MlvMenuItem mlvMenuItem in menuItemRoot.RootItems)
			{
				ToolStripMenuItem mi = GenerateMenuItem(mlvMenuItem);
				NotifyIconContextMenuStrip.Items.Add(mi);
				GeneratedRootMenuItems.Add(mi);
			}
		}

		private ToolStripMenuItem GenerateMenuItem(MlvMenuItem mlvMenuItem)
		{
			ToolStripMenuItem mi = new ToolStripMenuItem();
			mi.DropDown = CreateCheckImageContextMenuStrip();
			((ContextMenuStrip)mi.DropDown).ShowImageMargin = false;
			mi.Name = mlvMenuItem.Name;
			mi.Enabled = mlvMenuItem.Enabled;
			mi.Text = mlvMenuItem.Name;
			if (mi.Enabled)
			{
				switch (mlvMenuItem.Type)
				{
					case MlvMenuItemType.Text:
						mi.Text = mlvMenuItem.Name + ": " + mlvMenuItem.Value; //override
						mi.Tag = mlvMenuItem.Value;
						mi.Click += MenuItemClick;
						break;
					case MlvMenuItemType.Hidden:
						mi.Tag = mlvMenuItem.Value;
						mi.Click += MenuItemClick;
						break;
					case MlvMenuItemType.Folder:
						foreach (MlvMenuItem child in mlvMenuItem.Childs)
						{
							ToolStripMenuItem miChild = GenerateMenuItem(child);
							mi.DropDownItems.Add(miChild);
						}
						break;
					default:
						throw new Exception("Неопознанный тип элемента меню.");
				}
			}
			return mi;
		}

		internal ContextMenuStrip CreateCheckImageContextMenuStrip()
		{
			ContextMenuStrip checkImageContextMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem noCheckNoImage = new ToolStripMenuItem("No Check, No Image");

			return checkImageContextMenuStrip;
		}

		private void MenuItemClick(object sender, EventArgs e)
		{
			ToolStripMenuItem mi = (ToolStripMenuItem)sender;
			Clipboard.SetText((string)mi.Tag);
		}

		private void MenuItemExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MenuItemOpenNewFile_Click(object sender, EventArgs e)
		{
			OpenFile(false);
		}

		private void MenuItemEncrypt_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = AppName + " Encrypted File (*.mlvenc)|*.mlvenc";
			sfd.Title = AppName + " - Сохранить зашифрованный файл";
			if (sfd.ShowDialog() == DialogResult.Cancel)
			{
				MessageBox.Show("Отменено", AppName);
				return;
			}

			string password = "";
			PasswordInput passwordInputForm = new PasswordInput();
			DialogResult dialogResult = passwordInputForm.ShowDialog();

			if (dialogResult == DialogResult.OK)
				password = passwordInputForm.Password;
			passwordInputForm.Dispose();

			if (dialogResult != DialogResult.OK)
			{
				MessageBox.Show("Отменено", AppName);
				return;
			}

			try
			{
				using (FileStream fileStream = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
				{
					using (Aes aes = Aes.Create())
					{
						if (password.Length > 32)
							password = password.Substring(0, 31);
						while (password.Length < 32)
							password += "0";
						aes.Key = Encoding.UTF8.GetBytes(password);

						byte[] iv = aes.IV;
						fileStream.Write(iv, 0, iv.Length);

						using (CryptoStream cryptoStream = new CryptoStream(
							fileStream,
							aes.CreateEncryptor(),
							CryptoStreamMode.Write))
						{
							using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
							{
								encryptWriter.Write(File.ReadAllText(Properties.Settings.Default.FilePath));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка при попытке зашифровать файл:" + ex.Message, AppName);
			}
		}

		private void MenuItemCopyPath_Click(object sender, EventArgs e)
		{
			try { Clipboard.SetText(Properties.Settings.Default.FilePath); } catch { }
		}

		private void ToolStripMenuItemAutostart_Click(object sender, EventArgs e)
		{
			if (RegistryKeyAutorun.GetValue(AppName) == null)
			{
				RegistryKeyAutorun.SetValue(AppName, Application.ExecutablePath);
				ToolStripMenuItemAutostart.Checked = true;
			}
			else
			{
				RegistryKeyAutorun.DeleteValue(AppName, false);
				ToolStripMenuItemAutostart.Checked = false;
			}
		}
	}
}
