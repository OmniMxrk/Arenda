namespace ППрактика1
{
    partial class AddApartmentForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label "Добавление квартиры"
            this.lblTitle.Text = "Добавление квартиры";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // Label "Название"
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(20, 70);
            this.lblName.Size = new System.Drawing.Size(100, 30);

            // TextBox "Название"
            this.txtName.Location = new System.Drawing.Point(130, 70);
            this.txtName.Size = new System.Drawing.Size(180, 30);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Label "Описание"
            this.lblDescription.Text = "Описание:";
            this.lblDescription.Location = new System.Drawing.Point(20, 120);
            this.lblDescription.Size = new System.Drawing.Size(100, 30);

            // TextBox "Описание"
            this.txtDescription.Location = new System.Drawing.Point(130, 120);
            this.txtDescription.Size = new System.Drawing.Size(180, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Label "Цена"
            this.lblPrice.Text = "Цена (руб/день):";
            this.lblPrice.Location = new System.Drawing.Point(20, 200);
            this.lblPrice.Size = new System.Drawing.Size(120, 30);

            // NumericUpDown "Цена"
            this.numPrice.Location = new System.Drawing.Point(150, 200);
            this.numPrice.Size = new System.Drawing.Size(120, 30);
            this.numPrice.Maximum = 100000;
            this.numPrice.DecimalPlaces = 2;

            // Label "Изображение"
            this.lblImage.Text = "Путь к изображению:";
            this.lblImage.Location = new System.Drawing.Point(20, 250);
            this.lblImage.Size = new System.Drawing.Size(140, 30);

            // TextBox "Путь к изображению"
            this.txtImagePath.Location = new System.Drawing.Point(170, 250);
            this.txtImagePath.Size = new System.Drawing.Size(140, 30);
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Button "Загрузить изображение"
            this.btnUploadImage.Text = "Выбрать...";
            this.btnUploadImage.Location = new System.Drawing.Point(20, 290);
            this.btnUploadImage.Size = new System.Drawing.Size(100, 30);
            this.btnUploadImage.Click += new System.EventHandler(this.BtnUploadImage_Click);

            // CheckBox "Доступность"
            this.chkAvailable.Text = "Доступно для аренды";
            this.chkAvailable.Location = new System.Drawing.Point(20, 330);
            this.chkAvailable.Size = new System.Drawing.Size(200, 30);

            // Button "Сохранить"
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(20, 370);
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // Button "Отмена"
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(170, 370);
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Настройки формы
            this.ClientSize = new System.Drawing.Size(320, 430);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.chkAvailable);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }
    }
}
