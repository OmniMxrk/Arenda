namespace ППрактика1
{
    partial class UserForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstApartments;
        private System.Windows.Forms.Button btnBookApartment;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Button btnLogout;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lstApartments = new ListBox();
            btnBookApartment = new Button();
            btnViewBookings = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Доступные квартиры:";
            // 
            // lstApartments
            // 
            lstApartments.ItemHeight = 15;
            lstApartments.Location = new Point(20, 60);
            lstApartments.Name = "lstApartments";
            lstApartments.Size = new Size(300, 139);
            lstApartments.TabIndex = 1;
            // 
            // btnBookApartment
            // 
            btnBookApartment.Location = new Point(0, 0);
            btnBookApartment.Name = "btnBookApartment";
            btnBookApartment.Size = new Size(75, 23);
            btnBookApartment.TabIndex = 2;
            // 
            // btnViewBookings
            // 
            btnViewBookings.BackColor = Color.SaddleBrown;
            btnViewBookings.FlatStyle = FlatStyle.Flat;
            btnViewBookings.ForeColor = Color.White;
            btnViewBookings.Location = new Point(20, 220);
            btnViewBookings.Name = "btnViewBookings";
            btnViewBookings.Size = new Size(300, 40);
            btnViewBookings.TabIndex = 3;
            btnViewBookings.Text = "Забронировать";
            btnViewBookings.UseVisualStyleBackColor = false;
            btnViewBookings.Click += BtnViewBookings_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(20, 270);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(300, 40);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // UserForm
            // 
            BackColor = Color.Beige;
            ClientSize = new Size(350, 330);
            Controls.Add(lblTitle);
            Controls.Add(lstApartments);
            Controls.Add(btnBookApartment);
            Controls.Add(btnViewBookings);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}
