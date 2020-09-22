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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int s = 0;
        bool cifra = false;
        bool bukva = false;
        bool simvol = false;
        string pass;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if ((txtLogin.Text != "") & (txtPassword.Text != "") & (txtPassword1.Text != ""))
                btnRegistration.Enabled = true;
            else btnRegistration.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((txtLogin.Text != "") & (txtPassword.Text != "") & (txtPassword1.Text != ""))
                btnRegistration.Enabled = true;
            else btnRegistration.Enabled = false;

            if (txtPassword.Text == txtPassword1.Text & txtPassword.Text != "")
            {
                lbPas1.Text = "Пароли совпадают";
                lbPas1.ForeColor = Color.Green;
            }
            else
            {
                lbPas1.Text = "Пароли не совдадают";
                lbPas1.ForeColor = Color.Red;
            }
            s = 0;
            cifra = false;
            bukva = false;
            simvol = false;
            pass = txtPassword.Text;
            for (int i = 0; i < pass.Length; i++)
            {
                s++;
                if (pass[i] >= '0' & pass[i] <= '9')
                    cifra = true;
                if (pass[i] >= 'a' & pass[i] <= 'z')
                    bukva = true;
                if (pass[i] == '!' | pass[i] == '@' | pass[i] == '#' | pass[i] == '$' | pass[i] == '%' | pass[i] == '^')
                    simvol = true;


                if (s <= 5)
                {
                    lbPas.Text = "Пароль должен состоять минимум из 6 символов";
                    lbPas.ForeColor = Color.Red;
                }
                else
                if (cifra == false)
                {
                    lbPas.Text = "Пароль должен иметь минимум 1 цифру";
                    lbPas.ForeColor = Color.Red;
                }
                else
                if (bukva == false)
                {
                    lbPas.Text = "Пароль должен иметь минимум одну латинскую букву";
                    lbPas.ForeColor = Color.Red;
                }
                else
                if (simvol == false)
                {
                    lbPas.Text = "Пароль должен иметь минимум однин символ из: ! @ # $ % ^ ";
                    lbPas.ForeColor = Color.Red;
                }
                else
                {
                    lbPas.Text = "Отличный пароль!";
                    lbPas.ForeColor = Color.Green;
                }
            }
        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            if ((txtLogin.Text != "") & (txtPassword.Text != "") & (txtPassword1.Text != ""))
                btnRegistration.Enabled = true;
            else btnRegistration.Enabled = false;

            if (txtPassword.Text == txtPassword1.Text & txtPassword.Text != "")
            {
                lbPas1.Text = "Пароли совпадают";
                lbPas1.ForeColor = Color.Green;
            }
            else
            {
                lbPas1.Text = "Пароли не совдадают";
                lbPas1.ForeColor = Color.Red;
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if ((lbPas.Text == "Отличный пароль!") & (lbPas1.Text == "Пароли совпадают"))
            {
                MessageBox.Show("Вы успешно зарегистрировались");
                StreamWriter s = File.CreateText("users.txt");
                s.WriteLine(txtLogin.Text + ":" + txtPassword.Text);
                s.Close();
            }
            else MessageBox.Show("Пароль не соответствует требованиям");
        }
    }
}
