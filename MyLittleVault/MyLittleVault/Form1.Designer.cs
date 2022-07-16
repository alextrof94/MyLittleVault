
namespace MyLittleVault
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.NIContextAppMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemOpenNewFile = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemSaveEncrypted = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemSaveDecrypted = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAutostart = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.NIContextAppMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.ContextMenuStrip = this.NIContextAppMenu;
			this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Text = "MyLittleVault";
			this.NotifyIcon.Visible = true;
			// 
			// NIContextAppMenu
			// 
			this.NIContextAppMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.NIContextAppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.ToolStripMenuItemAutostart,
            this.ToolStripMenuItemAbout,
            this.MenuItemExit,
            this.toolStripSeparator1});
			this.NIContextAppMenu.Name = "ContextMenuStrip";
			this.NIContextAppMenu.ShowCheckMargin = true;
			this.NIContextAppMenu.ShowImageMargin = false;
			this.NIContextAppMenu.Size = new System.Drawing.Size(148, 98);
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpenNewFile,
            this.MenuItemSaveEncrypted,
            this.MenuItemSaveDecrypted});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// MenuItemOpenNewFile
			// 
			this.MenuItemOpenNewFile.Name = "MenuItemOpenNewFile";
			this.MenuItemOpenNewFile.Size = new System.Drawing.Size(263, 22);
			this.MenuItemOpenNewFile.Text = "Открыть файл";
			this.MenuItemOpenNewFile.Click += new System.EventHandler(this.MenuItemOpenNewFile_Click);
			// 
			// MenuItemSaveEncrypted
			// 
			this.MenuItemSaveEncrypted.Name = "MenuItemSaveEncrypted";
			this.MenuItemSaveEncrypted.Size = new System.Drawing.Size(263, 22);
			this.MenuItemSaveEncrypted.Text = "Сохранить зашифрованный файл";
			this.MenuItemSaveEncrypted.Click += new System.EventHandler(this.MenuItemSaveEncrypted_Click);
			// 
			// MenuItemSaveDecrypted
			// 
			this.MenuItemSaveDecrypted.Name = "MenuItemSaveDecrypted";
			this.MenuItemSaveDecrypted.Size = new System.Drawing.Size(263, 22);
			this.MenuItemSaveDecrypted.Text = "Сохранить расшифрованный файл";
			this.MenuItemSaveDecrypted.Click += new System.EventHandler(this.MenuItemSaveDecrypted_Click);
			// 
			// ToolStripMenuItemAutostart
			// 
			this.ToolStripMenuItemAutostart.Checked = true;
			this.ToolStripMenuItemAutostart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ToolStripMenuItemAutostart.Name = "ToolStripMenuItemAutostart";
			this.ToolStripMenuItemAutostart.Size = new System.Drawing.Size(147, 22);
			this.ToolStripMenuItemAutostart.Text = "Автозапуск";
			this.ToolStripMenuItemAutostart.Click += new System.EventHandler(this.ToolStripMenuItemAutostart_Click);
			// 
			// ToolStripMenuItemAbout
			// 
			this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
			this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(147, 22);
			this.ToolStripMenuItemAbout.Text = "О программе";
			this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
			// 
			// MenuItemExit
			// 
			this.MenuItemExit.Name = "MenuItemExit";
			this.MenuItemExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuItemExit.Size = new System.Drawing.Size(147, 22);
			this.MenuItemExit.Text = "Выйти";
			this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(269, 0);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.Text = "MyLittleVault";
			this.NIContextAppMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon NotifyIcon;
		private System.Windows.Forms.ContextMenuStrip NIContextAppMenu;
		private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAutostart;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MenuItemOpenNewFile;
		private System.Windows.Forms.ToolStripMenuItem MenuItemSaveEncrypted;
		private System.Windows.Forms.ToolStripMenuItem MenuItemSaveDecrypted;
	}
}

