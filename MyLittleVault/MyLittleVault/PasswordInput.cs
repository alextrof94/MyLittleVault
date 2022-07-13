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
	public partial class PasswordInput : Form
	{
		public string Password = "";

		public PasswordInput()
		{
			InitializeComponent();
		}

		private void ButtonEncrypt_Click(object sender, EventArgs e)
		{
			EnteringPasswordComplete();
		}

		private void EnteringPasswordComplete()
		{
			Password = TextBoxPassword.Text;
			if (string.IsNullOrEmpty(Password))
			{
				MessageBox.Show("Пароль не может быть пустым", "MyLittleVault");
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				EnteringPasswordComplete();
			}
		}

		private void PasswordInput_Shown(object sender, EventArgs e)
		{
			TextBoxPassword.Focus();
		}
	}
}
