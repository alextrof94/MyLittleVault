
namespace MyLittleVault
{
	partial class About
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.LabelName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.LabelVersion = new System.Windows.Forms.Label();
			this.LabelAuthor = new System.Windows.Forms.Label();
			this.LabelGithub = new System.Windows.Forms.Label();
			this.ButtonClearData = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LabelName
			// 
			this.LabelName.AutoSize = true;
			this.LabelName.Location = new System.Drawing.Point(78, 9);
			this.LabelName.Name = "LabelName";
			this.LabelName.Size = new System.Drawing.Size(60, 13);
			this.LabelName.TabIndex = 0;
			this.LabelName.Text = "Название:";
			this.LabelName.Click += new System.EventHandler(this.LabelName_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Название:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Версия:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Автор:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Github:";
			// 
			// LabelVersion
			// 
			this.LabelVersion.AutoSize = true;
			this.LabelVersion.Location = new System.Drawing.Point(78, 22);
			this.LabelVersion.Name = "LabelVersion";
			this.LabelVersion.Size = new System.Drawing.Size(60, 13);
			this.LabelVersion.TabIndex = 5;
			this.LabelVersion.Text = "Название:";
			this.LabelVersion.Click += new System.EventHandler(this.LabelVersion_Click);
			// 
			// LabelAuthor
			// 
			this.LabelAuthor.AutoSize = true;
			this.LabelAuthor.Location = new System.Drawing.Point(78, 35);
			this.LabelAuthor.Name = "LabelAuthor";
			this.LabelAuthor.Size = new System.Drawing.Size(60, 13);
			this.LabelAuthor.TabIndex = 6;
			this.LabelAuthor.Text = "Название:";
			this.LabelAuthor.Click += new System.EventHandler(this.LabelAuthor_Click);
			// 
			// LabelGithub
			// 
			this.LabelGithub.AutoSize = true;
			this.LabelGithub.Location = new System.Drawing.Point(78, 48);
			this.LabelGithub.Name = "LabelGithub";
			this.LabelGithub.Size = new System.Drawing.Size(60, 13);
			this.LabelGithub.TabIndex = 7;
			this.LabelGithub.Text = "Название:";
			this.LabelGithub.Click += new System.EventHandler(this.LabelGithub_Click);
			// 
			// ButtonClearData
			// 
			this.ButtonClearData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonClearData.Location = new System.Drawing.Point(15, 66);
			this.ButtonClearData.Name = "ButtonClearData";
			this.ButtonClearData.Size = new System.Drawing.Size(330, 23);
			this.ButtonClearData.TabIndex = 8;
			this.ButtonClearData.Text = "Стереть сохраненные данные";
			this.ButtonClearData.UseVisualStyleBackColor = true;
			this.ButtonClearData.Click += new System.EventHandler(this.ButtonClearData_Click);
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 101);
			this.Controls.Add(this.ButtonClearData);
			this.Controls.Add(this.LabelGithub);
			this.Controls.Add(this.LabelAuthor);
			this.Controls.Add(this.LabelVersion);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LabelName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label LabelVersion;
		private System.Windows.Forms.Label LabelAuthor;
		private System.Windows.Forms.Label LabelGithub;
		private System.Windows.Forms.Button ButtonClearData;
	}
}