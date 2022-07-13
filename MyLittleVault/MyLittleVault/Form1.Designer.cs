
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
			this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemOpenNewFile = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEncrypt = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemCopyPath = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAutostart = new System.Windows.Forms.ToolStripMenuItem();
			this.NotifyIconContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
			this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Text = "MyLittleVault";
			this.NotifyIcon.Visible = true;
			// 
			// NotifyIconContextMenuStrip
			// 
			this.NotifyIconContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpenNewFile,
            this.MenuItemEncrypt,
            this.MenuItemCopyPath,
            this.ToolStripMenuItemAutostart,
            this.MenuItemExit,
            this.toolStripSeparator1});
			this.NotifyIconContextMenuStrip.Name = "ContextMenuStrip";
			this.NotifyIconContextMenuStrip.ShowCheckMargin = true;
			this.NotifyIconContextMenuStrip.ShowImageMargin = false;
			this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(217, 142);
			// 
			// MenuItemOpenNewFile
			// 
			this.MenuItemOpenNewFile.Name = "MenuItemOpenNewFile";
			this.MenuItemOpenNewFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuItemOpenNewFile.Size = new System.Drawing.Size(216, 22);
			this.MenuItemOpenNewFile.Text = "Открыть новый файл";
			this.MenuItemOpenNewFile.Click += new System.EventHandler(this.MenuItemOpenNewFile_Click);
			// 
			// MenuItemEncrypt
			// 
			this.MenuItemEncrypt.Name = "MenuItemEncrypt";
			this.MenuItemEncrypt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuItemEncrypt.Size = new System.Drawing.Size(216, 22);
			this.MenuItemEncrypt.Text = "Зашифровать";
			this.MenuItemEncrypt.Click += new System.EventHandler(this.MenuItemEncrypt_Click);
			// 
			// MenuItemExit
			// 
			this.MenuItemExit.Name = "MenuItemExit";
			this.MenuItemExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuItemExit.Size = new System.Drawing.Size(216, 22);
			this.MenuItemExit.Text = "Выйти";
			this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
			// 
			// MenuItemCopyPath
			// 
			this.MenuItemCopyPath.Name = "MenuItemCopyPath";
			this.MenuItemCopyPath.Size = new System.Drawing.Size(216, 22);
			this.MenuItemCopyPath.Text = "Скопировать путь к файлу";
			this.MenuItemCopyPath.Click += new System.EventHandler(this.MenuItemCopyPath_Click);
			// 
			// ToolStripMenuItemAutostart
			// 
			this.ToolStripMenuItemAutostart.Checked = true;
			this.ToolStripMenuItemAutostart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ToolStripMenuItemAutostart.Name = "ToolStripMenuItemAutostart";
			this.ToolStripMenuItemAutostart.Size = new System.Drawing.Size(216, 22);
			this.ToolStripMenuItemAutostart.Text = "Автозапуск";
			this.ToolStripMenuItemAutostart.Click += new System.EventHandler(this.ToolStripMenuItemAutostart_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "MyLittleVault";
			this.NotifyIconContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon NotifyIcon;
		private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem MenuItemOpenNewFile;
		private System.Windows.Forms.ToolStripMenuItem MenuItemEncrypt;
		private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuItemCopyPath;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAutostart;
	}
}

