namespace ППрактика1
{
    partial class EditApartmentForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            chkAvailable = new CheckBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Редактирование квартиры";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 30);
            lblName.TabIndex = 1;
            lblName.Text = "Название:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Location = new Point(130, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 16);
            txtName.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(20, 120);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 30);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Location = new Point(130, 120);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(180, 60);
            txtDescription.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(20, 200);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(120, 30);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Цена (руб/день):";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(150, 200);
            numPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 23);
            numPrice.TabIndex = 6;
            // 
            // chkAvailable
            // 
            chkAvailable.Location = new Point(20, 250);
            chkAvailable.Name = "chkAvailable";
            chkAvailable.Size = new Size(200, 30);
            chkAvailable.TabIndex = 7;
            chkAvailable.Text = "Доступно для аренды";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SaddleBrown;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 40);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(170, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 40);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Удалить квартиру";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(90, 350);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 40);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // EditApartmentForm
            // 
            BackColor = Color.Beige;
            ClientSize = new Size(320, 400);
            Controls.Add(lblTitle);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(numPrice);
            Controls.Add(chkAvailable);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EditApartmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += EditApartmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
