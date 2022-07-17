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
		public readonly string AppName = "MyLittleVault";
		public readonly string Version = "1.1.1";
		public readonly string Author = "alextrof94";
		public readonly string GithubLink = "https://github.com/alextrof94/MyLittleVault";

		readonly RegistryKey RegistryKeyAutorun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		private List<ToolStripMenuItem> GeneratedRootMenuItems = new List<ToolStripMenuItem>();

		public Form1()
		{
			this.Shown += HideWindowCompletely;
			this.Shown += Initialized;
			InitializeComponent();
			NotifyIcon.Text = AppName + " v" + Version;
		}

		private void Initialized(object sender, EventArgs e)
		{
			CheckAutostart();
			LoadFromSettings();
		}

		private void LoadFromSettings()
		{
			try
			{
				string data = LoadAndDecryptDataFromSettings();
				Deserialize(data);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при попытке открыть сохраненные данные. Откройте файл заново.\r\nТекст ошибки:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		internal void ClearDataFromSettings()
		{
			Properties.Settings.Default.EncryptedData = null;
			Properties.Settings.Default.Save();
		}

		private void OpenFile()
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = AppName + " files (*.mvl, *.mlvenc)|*.mlv;*.mlvenc";
				ofd.Title = "Открыть файл - " + AppName;
				ofd.Multiselect = false;
				if (ofd.ShowDialog() == DialogResult.Cancel)
					throw new Exception("Отменено открытие файла");
				string path = ofd.FileName;

				string data;
				if (Path.GetExtension(path) == ".mlvenc")
					data = DecryptFile(path);
				else
					data = File.ReadAllText(path);
				
				Deserialize(data);
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при открытии файла\r\n" + ex.Message);
			}
		}

		private string DecryptFile(string path)
		{
			try
			{
				string password = "";
				PasswordInput passwordInputForm = new PasswordInput(this);
				DialogResult dialogResult = passwordInputForm.ShowDialog();

				if (dialogResult == DialogResult.OK)
					password = passwordInputForm.Password;
				passwordInputForm.Dispose();

				if (dialogResult != DialogResult.OK)
					throw new Exception("Отменен ввод пароля для расшифровки файла");

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
							password = password.Substring(0, 32);
						while (password.Length < 32)
							password += "0";
						byte[] key = Encoding.UTF8.GetBytes(password);

						using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
						{
							using (StreamReader decryptReader = new StreamReader(cryptoStream))
							{
								string data = decryptReader.ReadToEnd();
								if (string.IsNullOrEmpty(data))
									throw new Exception("Расшифрованные данные пусты");
								return data;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Произошла ошибка при попытке расшифровать файл\r\n" + ex.Message);
			}
		}

		private void Deserialize(string data)
		{
			try
			{
				string json = data.Replace("\r\n", "");
				MlvMenuItemRoot MenuItemRoot = JsonConvert.DeserializeObject<MlvMenuItemRoot>(json);
				GenerateMenuItemsFromRoot(MenuItemRoot);
				EncryptAndSaveDataToSettings(data);
				SetButtonsEnabled(true);
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при попытке десериализации данных\r\n" + ex.Message);
			}
		}

		private void EncryptAndSaveDataToSettings(string data)
		{
			byte[] decryptedData = Encoding.Unicode.GetBytes(data);
			byte[] encryptedData = ProtectedData.Protect(decryptedData, new byte[0], DataProtectionScope.CurrentUser);
			Properties.Settings.Default.EncryptedData = Convert.ToBase64String(encryptedData);
			Properties.Settings.Default.Save();
		}

		private string LoadAndDecryptDataFromSettings()
		{
			if (string.IsNullOrEmpty(Properties.Settings.Default.EncryptedData))
				throw new Exception("Сохраненные данные пусты");
			byte[] encryptedData = Convert.FromBase64String(Properties.Settings.Default.EncryptedData);
			byte[] decryptedData = ProtectedData.Unprotect(encryptedData, new byte[0], DataProtectionScope.CurrentUser);
			return Encoding.Unicode.GetString(decryptedData);
		}

		private void CheckAutostart()
		{
			ToolStripMenuItemAutostart.Checked = (RegistryKeyAutorun.GetValue(AppName) != null);
		}

		private void HideWindowCompletely(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void SetButtonsEnabled(bool enabled)
		{
			MenuItemSaveDecrypted.Enabled = enabled;
			MenuItemSaveEncrypted.Enabled = enabled;
		}

		private void GenerateMenuItemsFromRoot(MlvMenuItemRoot menuItemRoot)
		{
			try
			{
				List<ToolStripMenuItem> GeneratedRootMenuItemsNew = new List<ToolStripMenuItem>();
				foreach (MlvMenuItem mlvMenuItem in menuItemRoot.RootItems)
				{
					ToolStripMenuItem mi = GenerateMenuItem(mlvMenuItem);
					NIContextAppMenu.Items.Add(mi);
					GeneratedRootMenuItemsNew.Add(mi);
				}
				for (int i = GeneratedRootMenuItems.Count - 1; i >= 0; i--)
				{
					NIContextAppMenu.Items.Remove(GeneratedRootMenuItems[i]);
					GeneratedRootMenuItems.RemoveAt(i);
				}
				GeneratedRootMenuItems = GeneratedRootMenuItemsNew;
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при попытке создания меню\r\n" + ex.Message);
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
			try
			{
				OpenFile();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при попытке открыть файл.\r\nТекст ошибки:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		
		private void MenuItemSaveEncrypted_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = AppName + " Зашифрованный файл (*.mlvenc)|*.mlvenc";
				sfd.Title = "Сохранить зашифрованный файл - " + AppName;
				if (sfd.ShowDialog() != DialogResult.OK)
					throw new Exception("Отменен выбор места сохранения зашифрованных данных");

				string password = "";
				PasswordInput passwordInputForm = new PasswordInput(this);
				DialogResult dialogResult = passwordInputForm.ShowDialog();

				if (dialogResult == DialogResult.OK)
					password = passwordInputForm.Password;
				passwordInputForm.Dispose();

				if (dialogResult != DialogResult.OK)
					throw new Exception("Отменен ввод пароля шифрования");

				File.Delete(sfd.FileName);
				using (FileStream fileStream = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
				{
					using (Aes aes = Aes.Create())
					{
						if (password.Length > 32)
							password = password.Substring(0, 32);
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
								encryptWriter.Write(LoadAndDecryptDataFromSettings());
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка при попытке сохранить зашифрованный файл\r\nТекст ошибки:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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

		private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
		{
			About about = new About(this);
			about.ShowDialog();
		}

		private void MenuItemSaveDecrypted_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = AppName + " Расшифрованный файл (*.mlv)|*.mlv";
				sfd.Title = "Сохранить расшифрованный файл - " + AppName;
				if (sfd.ShowDialog() != DialogResult.OK)
					throw new Exception("Отменен выбор места сохранения расшифрованных данных");

				File.WriteAllText(sfd.FileName, LoadAndDecryptDataFromSettings());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка при попытке сохранить расшифрованный файл\r\nТекст ошибки:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
