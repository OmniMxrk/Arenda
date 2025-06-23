namespace ППрактика1
{
    partial class LoginForm
    {
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private void InitializeComponent()
        {
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label "Телефон"
            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Location = new System.Drawing.Point(50, 50);
            this.lblPhone.Size = new System.Drawing.Size(100, 30);

            // TextBox "Номер телефона"
            this.txtPhone.Location = new System.Drawing.Point(150, 50);
            this.txtPhone.Size = new System.Drawing.Size(180, 30);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Label "Пароль"
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Location = new System.Drawing.Point(50, 100);
            this.lblPassword.Size = new System.Drawing.Size(100, 30);

            // TextBox "Пароль"
            this.txtPassword.Location = new System.Drawing.Point(150, 100);
            this.txtPassword.Size = new System.Drawing.Size(180, 30);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.PasswordChar = '*';

            // Button "Войти"
            this.btnLogin.Text = "Войти";
            this.btnLogin.Location = new System.Drawing.Point(100, 160);
            this.btnLogin.Size = new System.Drawing.Size(180, 40);
            this.btnLogin.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            // Настройки формы
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.ResumeLayout(false);
        }
    }
}
