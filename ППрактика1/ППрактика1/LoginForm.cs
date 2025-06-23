using System;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string password = txtPassword.Text;

            if (DatabaseHelper.AuthenticateUser(phone, password, out bool isAdmin, out int userId))
            {
                MessageBox.Show("Вход выполнен успешно!");
                this.Hide();
                if (isAdmin)
                    new AdminForm().Show();
                else
                    new UserForm(userId).Show();
            }
            else
            {
                MessageBox.Show("Неверные данные! Попробуйте снова.");
            }
        }

    }
}
