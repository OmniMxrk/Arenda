namespace ППрактика1
{
    partial class AdminForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstApartments;
        private System.Windows.Forms.Button btnAddApartment;
        private System.Windows.Forms.Button btnEditApartment;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lstApartments = new ListBox();
            btnAddApartment = new Button();
            btnEditApartment = new Button();
            btnViewBookings = new Button();
            btnRefresh = new Button();
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
            lblTitle.Text = "Панель администратора";
            // 
            // lstApartments
            // 
            lstApartments.ItemHeight = 15;
            lstApartments.Location = new Point(20, 60);
            lstApartments.Name = "lstApartments";
            lstApartments.Size = new Size(300, 139);
            lstApartments.TabIndex = 1;
            // 
            // btnAddApartment
            // 
            btnAddApartment.BackColor = Color.SaddleBrown;
            btnAddApartment.FlatStyle = FlatStyle.Flat;
            btnAddApartment.ForeColor = Color.White;
            btnAddApartment.Location = new Point(20, 220);
            btnAddApartment.Name = "btnAddApartment";
            btnAddApartment.Size = new Size(140, 40);
            btnAddApartment.TabIndex = 2;
            btnAddApartment.Text = "Добавить квартиру";
            btnAddApartment.UseVisualStyleBackColor = false;
            btnAddApartment.Click += BtnAddApartment_Click;
            // 
            // btnEditApartment
            // 
            btnEditApartment.BackColor = Color.SaddleBrown;
            btnEditApartment.FlatStyle = FlatStyle.Flat;
            btnEditApartment.ForeColor = Color.White;
            btnEditApartment.Location = new Point(180, 220);
            btnEditApartment.Name = "btnEditApartment";
            btnEditApartment.Size = new Size(140, 40);
            btnEditApartment.TabIndex = 3;
            btnEditApartment.Text = "Редактировать";
            btnEditApartment.UseVisualStyleBackColor = false;
            btnEditApartment.Click += BtnEditApartment_Click;
            // 
            // btnViewBookings
            // 
            btnViewBookings.BackColor = Color.SaddleBrown;
            btnViewBookings.FlatStyle = FlatStyle.Flat;
            btnViewBookings.ForeColor = Color.White;
            btnViewBookings.Location = new Point(20, 270);
            btnViewBookings.Name = "btnViewBookings";
            btnViewBookings.Size = new Size(140, 40);
            btnViewBookings.TabIndex = 4;
            btnViewBookings.Text = "Просмотр бронирований";
            btnViewBookings.UseVisualStyleBackColor = false;
            btnViewBookings.Click += BtnViewBookings_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.SaddleBrown;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(180, 270);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Обновить список";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(20, 320);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(300, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // AdminForm
            // 
            BackColor = Color.Beige;
            ClientSize = new Size(350, 380);
            Controls.Add(lblTitle);
            Controls.Add(lstApartments);
            Controls.Add(btnAddApartment);
            Controls.Add(btnEditApartment);
            Controls.Add(btnViewBookings);
            Controls.Add(btnRefresh);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}
