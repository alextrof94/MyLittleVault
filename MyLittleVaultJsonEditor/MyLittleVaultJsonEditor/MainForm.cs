using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MyLittleVaultJsonEditor
{
	public partial class MainForm : Form
	{
		public readonly string AppName = "MyLittleVault";
		public readonly string Version = "1.0";
		public readonly string TargetVersion = "1.1.1";
		public readonly string Author = "alextrof94";
		public readonly string GithubLink = "https://github.com/alextrof94/MyLittleVault";

		private bool NeedProcessRootElementChanging = true;

		private MlvMenuItemRoot MenuItemRoot = new MlvMenuItemRoot();

		private Color SelectedNodeColorBeforeSelect;
		private TreeNode SelectedNode;
		private MlvMenuItem SelectedMenuItem;
		private bool ItemApplied = true;

		public MainForm()
		{
			InitializeComponent();
			this.Text = "Json Editor v" + Version + " for " + AppName + " v" + TargetVersion;
		}

		private void ButtonOpenFile_Click(object sender, EventArgs e)
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
				MessageBox.Show("Ошибка при открытии файла:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonSaveEncryptedFile_Click(object sender, EventArgs e)
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
								encryptWriter.Write(JsonConvert.SerializeObject(MenuItemRoot));
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

		private void ButtonSaveDecryptedFile_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = AppName + " Расшифрованный файл (*.mlv)|*.mlv";
				sfd.Title = "Сохранить расшифрованный файл - " + AppName;
				if (sfd.ShowDialog() != DialogResult.OK)
					throw new Exception("Отменен выбор места сохранения расшифрованных данных");

				File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(MenuItemRoot));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Произошла ошибка при попытке сохранить расшифрованный файл\r\nТекст ошибки:\r\n" + ex.Message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MenuItemRoot = JsonConvert.DeserializeObject<MlvMenuItemRoot>(json);
				foreach (MlvMenuItem menuItem in MenuItemRoot.RootItems)
					SetParentToMenuItem(menuItem, MenuItemRoot.RootItems);

				TreeViewItems.Nodes.Clear();
				foreach (MlvMenuItem item in MenuItemRoot.RootItems)
				{
					TreeNode miChild = GenerateNode(item);
					TreeViewItems.Nodes.Add(miChild);
				}
				if (TreeViewItems.Nodes.Count > 0)
					TreeViewItems.SelectedNode = TreeViewItems.Nodes[0];
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при попытке десериализации данных\r\n" + ex.Message);
			}
		}

		private void SetParentToMenuItem(MlvMenuItem menuItem, List<MlvMenuItem> parentList)
		{
			menuItem.ParentList = parentList;
			foreach (MlvMenuItem child in menuItem.Childs)
				SetParentToMenuItem(child, menuItem.Childs);
		}

		private TreeNode GenerateNode(MlvMenuItem mlvMenuItem, bool oneOfParentIsDisabled = false)
		{
			TreeNode node = new TreeNode();
			node.Name = mlvMenuItem.Name;
			node.Text = mlvMenuItem.Name;
			switch (mlvMenuItem.Type)
			{
				case MlvMenuItemType.Text:
					node.Tag = mlvMenuItem;
					if (mlvMenuItem.Enabled)
						node.Text = mlvMenuItem.Name + ": " + mlvMenuItem.Value; //override
					break;
				case MlvMenuItemType.Hidden:
					node.Tag = mlvMenuItem;
					break;
				case MlvMenuItemType.Folder:
					node.Tag = mlvMenuItem;
					foreach (MlvMenuItem child in mlvMenuItem.Childs)
					{
						bool nextOneOfParentIsDisabled = !(!oneOfParentIsDisabled && mlvMenuItem.Enabled);
						TreeNode miChild = GenerateNode(child, nextOneOfParentIsDisabled);
						node.Text = mlvMenuItem.Name + " ->";
						node.Nodes.Add(miChild);
					}
					break;
				default:
					throw new Exception("Неопознанный тип элемента меню.");
			}

			if (!mlvMenuItem.Enabled)
				node.Text += " [x]";

			if (oneOfParentIsDisabled)
				node.BackColor = Color.LightGray;


			return node;
		}

		private void TreeViewItems_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (TreeViewItems.SelectedNode == null || TreeViewItems.SelectedNode.Tag == null)
				return;

			if (!NeedProcessRootElementChanging)
				return;

			if (SelectedNode == TreeViewItems.SelectedNode)
			{
				if (!GroupBoxItem.Visible)
					GroupBoxItem.Visible = true;
				return;
			}

			if (!ItemApplied)
			{
				if (MessageBox.Show("Изменения не применены. Отменить изменения?", AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				{
					NeedProcessRootElementChanging = false;
					TreeViewItems.SelectedNode = SelectedNode;
					NeedProcessRootElementChanging = true;
					return;
				}
			}

			if (SelectedNode != null)
				SelectedNode.BackColor = SelectedNodeColorBeforeSelect;

			SelectedNode = TreeViewItems.SelectedNode;
			SelectedNodeColorBeforeSelect = SelectedNode.BackColor;
			SelectedNode.BackColor = Color.LightGreen;
			SelectedMenuItem = (MlvMenuItem)SelectedNode.Tag;
			LoadValuesFromItem();
			if (!GroupBoxItem.Visible)
				GroupBoxItem.Visible = true;
		}

		private void LoadValuesFromItem()
		{
			TextBoxItemName.Text = SelectedMenuItem.Name;
			TextBoxItemValue.Text = SelectedMenuItem.Value;
			CheckBoxItemEnabled.Checked = SelectedMenuItem.Enabled;
			switch (SelectedMenuItem.Type)
			{
				case MlvMenuItemType.Text:
					ComboBoxItemType.SelectedIndex = 0;
					break;
				case MlvMenuItemType.Hidden:
					ComboBoxItemType.SelectedIndex = 1;
					break;
				default:
					ComboBoxItemType.SelectedIndex = 2;
					break;
			}
			SetItemApplied(true);
		}

		private void ButtonItemApply_Click(object sender, EventArgs e)
		{
			SelectedMenuItem.Name = TextBoxItemName.Text;
			SelectedMenuItem.Value = TextBoxItemValue.Text;
			SelectedMenuItem.Enabled = CheckBoxItemEnabled.Checked;
			switch (ComboBoxItemType.SelectedIndex)
			{
				case 0:
					SelectedMenuItem.Type = MlvMenuItemType.Text;
					break;
				case 1:
					SelectedMenuItem.Type = MlvMenuItemType.Hidden;
					break;
				default:
					SelectedMenuItem.Type = MlvMenuItemType.Folder;
					break;
			}
			// Update node name
			SelectedNode.Name = SelectedMenuItem.Name;
			SelectedNode.Text = SelectedMenuItem.Name;
			if (SelectedMenuItem.Type == MlvMenuItemType.Text && SelectedMenuItem.Enabled)
				SelectedNode.Text = SelectedMenuItem.Name + ": " + SelectedMenuItem.Value; //override
			if (SelectedMenuItem.Type == MlvMenuItemType.Folder)
				SelectedNode.Text = SelectedMenuItem.Name + " ->"; //override
			if (!SelectedMenuItem.Enabled)
				SelectedNode.Text += " [x]";

			foreach (TreeNode child in SelectedNode.Nodes)
				UpdateChildNodeColorByEnabledParent(child, SelectedMenuItem.Enabled);

			SetItemApplied(true);
			SetControlsVisible();
		}

		private void UpdateChildNodeColorByEnabledParent(TreeNode item, bool parentEnabled)
		{
			item.BackColor = parentEnabled?Color.White:Color.LightGray;
			foreach (TreeNode child in item.Nodes)
				UpdateChildNodeColorByEnabledParent(child, SelectedMenuItem.Enabled);
		}

		private void TextBoxItemName_TextChanged(object sender, EventArgs e)
		{
			SetItemApplied(false);
		}

		private void TextBoxItemValue_TextChanged(object sender, EventArgs e)
		{
			SetItemApplied(false);
		}

		private void CheckBoxItemEnabled_CheckedChanged(object sender, EventArgs e)
		{
			SetItemApplied(false);
			SetControlsVisible();
		}

		private void ComboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetItemApplied(false);
			SetControlsVisible();
		}

		private void SetItemApplied(bool value)
		{
			if (SelectedMenuItem.Name == TextBoxItemName.Text &&
				SelectedMenuItem.Value == TextBoxItemValue.Text &&
				SelectedMenuItem.Enabled == CheckBoxItemEnabled.Checked)
			{
				MlvMenuItemType type;
				switch (ComboBoxItemType.SelectedIndex)
				{
					case 0: type = MlvMenuItemType.Text; break;
					case 1: type = MlvMenuItemType.Hidden; break;
					default: type = MlvMenuItemType.Folder; break;
				}
				if (SelectedMenuItem.Type == type)
					value = true;
			}
			ItemApplied = value;
		}

		private void SetControlsVisible()
		{
			if (CheckBoxItemEnabled.Checked)
			{
				switch (ComboBoxItemType.SelectedIndex)
				{
					case 0:
						TextBoxItemValue.Visible = true;
						LabelItemValue.Visible = true;
						ButtonAddChildElement.Visible = false;
						break;
					case 1:
						TextBoxItemValue.Visible = true;
						LabelItemValue.Visible = true;
						ButtonAddChildElement.Visible = false;
						break;
					case 2:
						TextBoxItemValue.Visible = false;
						LabelItemValue.Visible = false;
						if (SelectedMenuItem.Type == MlvMenuItemType.Folder)
							ButtonAddChildElement.Visible = true;
						break;
				}
			}
			else
			{
				TextBoxItemValue.Visible = false;
				LabelItemValue.Visible = false;
				if (ComboBoxItemType.SelectedIndex == 2 && SelectedMenuItem.Type == MlvMenuItemType.Folder)
					ButtonAddChildElement.Visible = true;
				else
					ButtonAddChildElement.Visible = false;
			}
		}

		private void ButtonAddRootItem_Click(object sender, EventArgs e)
		{
			MlvMenuItem newItem = new MlvMenuItem("Название", "Значение", MlvMenuItemType.Text, MenuItemRoot.RootItems);
			MenuItemRoot.RootItems.Add(newItem);
			TreeNode newNode = GenerateNode(newItem);
			TreeViewItems.Nodes.Add(newNode);
			TreeViewItems.SelectedNode = newNode;

			if (!SelectedNode.IsExpanded)
				SelectedNode.Expand();
		}

		private void ButtonAddChildElement_Click(object sender, EventArgs e)
		{
			MlvMenuItem newItem = new MlvMenuItem("Название", "Значение", MlvMenuItemType.Text, SelectedMenuItem.Childs);
			SelectedMenuItem.Childs.Add(newItem);
			TreeNode newNode = GenerateNode(newItem);
			SelectedNode.Nodes.Add(newNode);

			if (!SelectedNode.IsExpanded)
				SelectedNode.Expand();
		}

		private void ButtonDeleteItem_Click(object sender, EventArgs e)
		{
			if (SelectedNode == null)
				return;
			if (MessageBox.Show("Вы действительно хотите удалить элемент?", AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;
			SelectedMenuItem.ParentList.Remove(SelectedMenuItem);
			TreeViewItems.Nodes.Remove(SelectedNode);
		}

		private void ButtonItemRaiseUp_Click(object sender, EventArgs e)
		{
			ChangeMenuPosition(-1);
		}

		private void ButtonItemPutDown_Click(object sender, EventArgs e)
		{
			ChangeMenuPosition(1);
		}

		private void ChangeMenuPosition(int direction)
		{
			if (SelectedNode == null)
				return;
			int index = SelectedMenuItem.ParentList.IndexOf(SelectedMenuItem);
			if (direction == -1 && index == 0 || direction == 1 && index == SelectedMenuItem.ParentList.Count - 1)
				return;
			SelectedMenuItem.ParentList.RemoveAt(index);
			SelectedMenuItem.ParentList.Insert(index + direction, SelectedMenuItem);

			int nodeIndex;
			TreeNode targetNode = SelectedNode;
			if (SelectedNode.Parent != null)
			{
				nodeIndex = targetNode.Parent.Nodes.IndexOf(SelectedNode);
				TreeNode upperNode = targetNode.Parent.Nodes[nodeIndex + direction];
				upperNode.Parent.Nodes.RemoveAt(nodeIndex);
				upperNode.Parent.Nodes.Insert(nodeIndex + direction, targetNode);
			}
			else
			{
				nodeIndex = TreeViewItems.Nodes.IndexOf(SelectedNode);
				TreeViewItems.Nodes.RemoveAt(nodeIndex);
				TreeViewItems.Nodes.Insert(nodeIndex + direction, targetNode);
			}

			TreeViewItems.SelectedNode = targetNode;
		}
	}
}
