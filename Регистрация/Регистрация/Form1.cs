using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Регистрация
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string s;

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if ((txtLogin.Text != "") & (txtPassword.Text != ""))
                btnLogIn.Enabled = true;
            else btnLogIn.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((txtLogin.Text != "") & (txtPassword.Text != ""))
                btnLogIn.Enabled = true;
            else btnLogIn.Enabled = false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            StreamReader r = File.OpenText("users.txt");
            s = r.ReadLine();
            string[] array = s.Split(':');
            if ((txtLogin.Text == array[0]) & (txtPassword.Text == array[1]))
                MessageBox.Show("Вы успешно вошли");
            else MessageBox.Show("Не верный логин или пароль");

        }
    }
}
