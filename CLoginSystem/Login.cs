using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLoginSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.accountsTableAdapter.Fill(this.accountsDataSet.Accounts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            try
            {
                accountsTableAdapter.SelectUsername(Username_Textbox.Text);
            }
            catch
            {
                a = 1;
            }
            if (a == 0)
            {
                if (Password_Textbox.Text == accountsTableAdapter.SelectPassword(Username_Textbox.Text))
                {
                    MessageBox.Show("The data entered is valid.\nYou have been successfully logged in!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Username_Textbox.Text = "";
                    Password_Textbox.Text = "";
                    MessageBox.Show("The data you entered is incorrect.\nPlease try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Username_Textbox.Text = "";
                Password_Textbox.Text = "";
                MessageBox.Show("The data you entered is incorrect.\nPlease try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
