using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyLittleVault
{
	public partial class About : Form
	{
		Form1 MainForm;

		public About(Form1 MainForm)
		{
			this.MainForm = MainForm;
			InitializeComponent();
			this.Text = "О программе - " + MainForm.AppName;
			LabelName.Text = MainForm.AppName;
			LabelVersion.Text = MainForm.Version;
			LabelAuthor.Text = MainForm.Author;
			LabelGithub.Text = MainForm.GithubLink;
		}

		private void LabelName_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(MainForm.AppName);
		}

		private void LabelVersion_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(MainForm.Version);
		}

		private void LabelAuthor_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(MainForm.Author);
		}

		private void LabelGithub_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(MainForm.GithubLink);
		}

		private void ButtonClearData_Click(object sender, EventArgs e)
		{
			MainForm.ClearDataFromSettings();
		}
	}
}
