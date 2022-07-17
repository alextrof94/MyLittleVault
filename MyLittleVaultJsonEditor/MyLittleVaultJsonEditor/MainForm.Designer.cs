
namespace MyLittleVaultJsonEditor
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ButtonOpenFile = new System.Windows.Forms.Button();
			this.ButtonSaveDecryptedFile = new System.Windows.Forms.Button();
			this.ButtonSaveEncryptedFile = new System.Windows.Forms.Button();
			this.TreeViewItems = new System.Windows.Forms.TreeView();
			this.SplitContainer = new System.Windows.Forms.SplitContainer();
			this.ButtonItemPutDown = new System.Windows.Forms.Button();
			this.ButtonItemRaiseUp = new System.Windows.Forms.Button();
			this.ButtonDeleteItem = new System.Windows.Forms.Button();
			this.ButtonAddRootItem = new System.Windows.Forms.Button();
			this.GroupBoxItem = new System.Windows.Forms.GroupBox();
			this.ButtonAddChildElement = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ButtonItemApply = new System.Windows.Forms.Button();
			this.TextBoxItemName = new System.Windows.Forms.TextBox();
			this.TextBoxItemValue = new System.Windows.Forms.TextBox();
			this.CheckBoxItemEnabled = new System.Windows.Forms.CheckBox();
			this.LabelItemValue = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ComboBoxItemType = new System.Windows.Forms.ComboBox();
			this.SplitContainer.Panel1.SuspendLayout();
			this.SplitContainer.Panel2.SuspendLayout();
			this.SplitContainer.SuspendLayout();
			this.GroupBoxItem.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonOpenFile
			// 
			this.ButtonOpenFile.Location = new System.Drawing.Point(12, 12);
			this.ButtonOpenFile.Name = "ButtonOpenFile";
			this.ButtonOpenFile.Size = new System.Drawing.Size(124, 23);
			this.ButtonOpenFile.TabIndex = 9;
			this.ButtonOpenFile.Text = "Открыть файл";
			this.ButtonOpenFile.UseVisualStyleBackColor = true;
			this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
			// 
			// ButtonSaveDecryptedFile
			// 
			this.ButtonSaveDecryptedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonSaveDecryptedFile.Location = new System.Drawing.Point(320, 12);
			this.ButtonSaveDecryptedFile.Name = "ButtonSaveDecryptedFile";
			this.ButtonSaveDecryptedFile.Size = new System.Drawing.Size(214, 23);
			this.ButtonSaveDecryptedFile.TabIndex = 10;
			this.ButtonSaveDecryptedFile.Text = "Сохранить расшифрованный файл";
			this.ButtonSaveDecryptedFile.UseVisualStyleBackColor = true;
			this.ButtonSaveDecryptedFile.Click += new System.EventHandler(this.ButtonSaveDecryptedFile_Click);
			// 
			// ButtonSaveEncryptedFile
			// 
			this.ButtonSaveEncryptedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonSaveEncryptedFile.Location = new System.Drawing.Point(540, 12);
			this.ButtonSaveEncryptedFile.Name = "ButtonSaveEncryptedFile";
			this.ButtonSaveEncryptedFile.Size = new System.Drawing.Size(214, 23);
			this.ButtonSaveEncryptedFile.TabIndex = 11;
			this.ButtonSaveEncryptedFile.Text = "Сохранить зашифрованный файл";
			this.ButtonSaveEncryptedFile.UseVisualStyleBackColor = true;
			this.ButtonSaveEncryptedFile.Click += new System.EventHandler(this.ButtonSaveEncryptedFile_Click);
			// 
			// TreeViewItems
			// 
			this.TreeViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TreeViewItems.Location = new System.Drawing.Point(3, 3);
			this.TreeViewItems.Name = "TreeViewItems";
			this.TreeViewItems.Size = new System.Drawing.Size(203, 261);
			this.TreeViewItems.TabIndex = 12;
			this.TreeViewItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewItems_AfterSelect);
			// 
			// SplitContainer
			// 
			this.SplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SplitContainer.Location = new System.Drawing.Point(12, 41);
			this.SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			this.SplitContainer.Panel1.Controls.Add(this.ButtonItemPutDown);
			this.SplitContainer.Panel1.Controls.Add(this.ButtonItemRaiseUp);
			this.SplitContainer.Panel1.Controls.Add(this.ButtonDeleteItem);
			this.SplitContainer.Panel1.Controls.Add(this.ButtonAddRootItem);
			this.SplitContainer.Panel1.Controls.Add(this.TreeViewItems);
			// 
			// SplitContainer.Panel2
			// 
			this.SplitContainer.Panel2.Controls.Add(this.GroupBoxItem);
			this.SplitContainer.Size = new System.Drawing.Size(742, 317);
			this.SplitContainer.SplitterDistance = 245;
			this.SplitContainer.TabIndex = 14;
			// 
			// ButtonItemPutDown
			// 
			this.ButtonItemPutDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonItemPutDown.Location = new System.Drawing.Point(209, 38);
			this.ButtonItemPutDown.Name = "ButtonItemPutDown";
			this.ButtonItemPutDown.Size = new System.Drawing.Size(31, 29);
			this.ButtonItemPutDown.TabIndex = 16;
			this.ButtonItemPutDown.Text = "▼";
			this.ButtonItemPutDown.UseVisualStyleBackColor = true;
			this.ButtonItemPutDown.Click += new System.EventHandler(this.ButtonItemPutDown_Click);
			// 
			// ButtonItemRaiseUp
			// 
			this.ButtonItemRaiseUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonItemRaiseUp.Location = new System.Drawing.Point(209, 3);
			this.ButtonItemRaiseUp.Name = "ButtonItemRaiseUp";
			this.ButtonItemRaiseUp.Size = new System.Drawing.Size(31, 29);
			this.ButtonItemRaiseUp.TabIndex = 15;
			this.ButtonItemRaiseUp.Text = "▲";
			this.ButtonItemRaiseUp.UseVisualStyleBackColor = true;
			this.ButtonItemRaiseUp.Click += new System.EventHandler(this.ButtonItemRaiseUp_Click);
			// 
			// ButtonDeleteItem
			// 
			this.ButtonDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonDeleteItem.Location = new System.Drawing.Point(209, 235);
			this.ButtonDeleteItem.Name = "ButtonDeleteItem";
			this.ButtonDeleteItem.Size = new System.Drawing.Size(31, 29);
			this.ButtonDeleteItem.TabIndex = 14;
			this.ButtonDeleteItem.Text = "✖";
			this.ButtonDeleteItem.UseVisualStyleBackColor = true;
			this.ButtonDeleteItem.Click += new System.EventHandler(this.ButtonDeleteItem_Click);
			// 
			// ButtonAddRootItem
			// 
			this.ButtonAddRootItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonAddRootItem.Location = new System.Drawing.Point(3, 270);
			this.ButtonAddRootItem.Name = "ButtonAddRootItem";
			this.ButtonAddRootItem.Size = new System.Drawing.Size(237, 42);
			this.ButtonAddRootItem.TabIndex = 13;
			this.ButtonAddRootItem.Text = "Добавить корневой элемент";
			this.ButtonAddRootItem.UseVisualStyleBackColor = true;
			this.ButtonAddRootItem.Click += new System.EventHandler(this.ButtonAddRootItem_Click);
			// 
			// GroupBoxItem
			// 
			this.GroupBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GroupBoxItem.Controls.Add(this.ButtonAddChildElement);
			this.GroupBoxItem.Controls.Add(this.label1);
			this.GroupBoxItem.Controls.Add(this.ButtonItemApply);
			this.GroupBoxItem.Controls.Add(this.TextBoxItemName);
			this.GroupBoxItem.Controls.Add(this.TextBoxItemValue);
			this.GroupBoxItem.Controls.Add(this.CheckBoxItemEnabled);
			this.GroupBoxItem.Controls.Add(this.LabelItemValue);
			this.GroupBoxItem.Controls.Add(this.label2);
			this.GroupBoxItem.Controls.Add(this.ComboBoxItemType);
			this.GroupBoxItem.Location = new System.Drawing.Point(6, 3);
			this.GroupBoxItem.Name = "GroupBoxItem";
			this.GroupBoxItem.Size = new System.Drawing.Size(482, 309);
			this.GroupBoxItem.TabIndex = 8;
			this.GroupBoxItem.TabStop = false;
			this.GroupBoxItem.Text = "Значения элемента меню";
			this.GroupBoxItem.Visible = false;
			// 
			// ButtonAddChildElement
			// 
			this.ButtonAddChildElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonAddChildElement.Location = new System.Drawing.Point(6, 162);
			this.ButtonAddChildElement.Name = "ButtonAddChildElement";
			this.ButtonAddChildElement.Size = new System.Drawing.Size(470, 23);
			this.ButtonAddChildElement.TabIndex = 8;
			this.ButtonAddChildElement.Text = "Добавить дочерний элемент";
			this.ButtonAddChildElement.UseVisualStyleBackColor = true;
			this.ButtonAddChildElement.Click += new System.EventHandler(this.ButtonAddChildElement_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Название";
			// 
			// ButtonItemApply
			// 
			this.ButtonItemApply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonItemApply.Location = new System.Drawing.Point(6, 255);
			this.ButtonItemApply.Name = "ButtonItemApply";
			this.ButtonItemApply.Size = new System.Drawing.Size(470, 48);
			this.ButtonItemApply.TabIndex = 7;
			this.ButtonItemApply.Text = "Применить изменения";
			this.ButtonItemApply.UseVisualStyleBackColor = true;
			this.ButtonItemApply.Click += new System.EventHandler(this.ButtonItemApply_Click);
			// 
			// TextBoxItemName
			// 
			this.TextBoxItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxItemName.Location = new System.Drawing.Point(6, 32);
			this.TextBoxItemName.Multiline = true;
			this.TextBoxItemName.Name = "TextBoxItemName";
			this.TextBoxItemName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBoxItemName.Size = new System.Drawing.Size(470, 74);
			this.TextBoxItemName.TabIndex = 1;
			this.TextBoxItemName.Text = "1\r\n2\r\n3\r\n4\r\n5";
			this.TextBoxItemName.TextChanged += new System.EventHandler(this.TextBoxItemName_TextChanged);
			// 
			// TextBoxItemValue
			// 
			this.TextBoxItemValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxItemValue.Location = new System.Drawing.Point(6, 175);
			this.TextBoxItemValue.Multiline = true;
			this.TextBoxItemValue.Name = "TextBoxItemValue";
			this.TextBoxItemValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBoxItemValue.Size = new System.Drawing.Size(470, 74);
			this.TextBoxItemValue.TabIndex = 6;
			this.TextBoxItemValue.Text = "1\r\n2\r\n3\r\n4\r\n5";
			this.TextBoxItemValue.TextChanged += new System.EventHandler(this.TextBoxItemValue_TextChanged);
			// 
			// CheckBoxItemEnabled
			// 
			this.CheckBoxItemEnabled.AutoSize = true;
			this.CheckBoxItemEnabled.Location = new System.Drawing.Point(6, 112);
			this.CheckBoxItemEnabled.Name = "CheckBoxItemEnabled";
			this.CheckBoxItemEnabled.Size = new System.Drawing.Size(100, 17);
			this.CheckBoxItemEnabled.TabIndex = 4;
			this.CheckBoxItemEnabled.Text = "Пункт активен";
			this.CheckBoxItemEnabled.UseVisualStyleBackColor = true;
			this.CheckBoxItemEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxItemEnabled_CheckedChanged);
			// 
			// LabelItemValue
			// 
			this.LabelItemValue.AutoSize = true;
			this.LabelItemValue.Location = new System.Drawing.Point(6, 159);
			this.LabelItemValue.Name = "LabelItemValue";
			this.LabelItemValue.Size = new System.Drawing.Size(55, 13);
			this.LabelItemValue.TabIndex = 5;
			this.LabelItemValue.Text = "Значение";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 138);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Тип";
			// 
			// ComboBoxItemType
			// 
			this.ComboBoxItemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ComboBoxItemType.FormattingEnabled = true;
			this.ComboBoxItemType.Items.AddRange(new object[] {
            "Текст",
            "Скрытый",
            "Подменю"});
			this.ComboBoxItemType.Location = new System.Drawing.Point(44, 135);
			this.ComboBoxItemType.Name = "ComboBoxItemType";
			this.ComboBoxItemType.Size = new System.Drawing.Size(432, 21);
			this.ComboBoxItemType.TabIndex = 3;
			this.ComboBoxItemType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxItemType_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 370);
			this.Controls.Add(this.SplitContainer);
			this.Controls.Add(this.ButtonSaveEncryptedFile);
			this.Controls.Add(this.ButtonSaveDecryptedFile);
			this.Controls.Add(this.ButtonOpenFile);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "MyLittleVault Json Editor";
			this.SplitContainer.Panel1.ResumeLayout(false);
			this.SplitContainer.Panel2.ResumeLayout(false);
			this.SplitContainer.ResumeLayout(false);
			this.GroupBoxItem.ResumeLayout(false);
			this.GroupBoxItem.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button ButtonOpenFile;
		private System.Windows.Forms.Button ButtonSaveDecryptedFile;
		private System.Windows.Forms.Button ButtonSaveEncryptedFile;
		private System.Windows.Forms.TreeView TreeViewItems;
		private System.Windows.Forms.SplitContainer SplitContainer;
		private System.Windows.Forms.Button ButtonItemApply;
		private System.Windows.Forms.TextBox TextBoxItemValue;
		private System.Windows.Forms.Label LabelItemValue;
		private System.Windows.Forms.CheckBox CheckBoxItemEnabled;
		private System.Windows.Forms.ComboBox ComboBoxItemType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TextBoxItemName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox GroupBoxItem;
		private System.Windows.Forms.Button ButtonAddRootItem;
		private System.Windows.Forms.Button ButtonAddChildElement;
		private System.Windows.Forms.Button ButtonDeleteItem;
		private System.Windows.Forms.Button ButtonItemPutDown;
		private System.Windows.Forms.Button ButtonItemRaiseUp;
	}
}

