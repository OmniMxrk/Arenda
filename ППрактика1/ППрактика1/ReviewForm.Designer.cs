namespace ППрактика1
{
    partial class ReviewForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label "Оставить отзыв"
            this.lblTitle.Text = "Оставить отзыв";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // Label "Рейтинг"
            this.lblRating.Text = "Рейтинг (1-5):";
            this.lblRating.Location = new System.Drawing.Point(20, 70);
            this.lblRating.Size = new System.Drawing.Size(120, 30);

            // ComboBox "Выбор рейтинга"
            this.cmbRating.Location = new System.Drawing.Point(140, 70);
            this.cmbRating.Size = new System.Drawing.Size(160, 30);
            this.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRating.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });

            // Label "Комментарий"
            this.lblComment.Text = "Комментарий:";
            this.lblComment.Location = new System.Drawing.Point(20, 120);
            this.lblComment.Size = new System.Drawing.Size(120, 30);

            // TextBox "Комментарий"
            this.txtComment.Location = new System.Drawing.Point(20, 150);
            this.txtComment.Size = new System.Drawing.Size(280, 60);
            this.txtComment.Multiline = true;
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Button "Отправить отзыв"
            this.btnSubmit.Text = "Отправить";
            this.btnSubmit.Location = new System.Drawing.Point(20, 220);
            this.btnSubmit.Size = new System.Drawing.Size(130, 40);
            this.btnSubmit.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            // Button "Отмена"
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(170, 220);
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Настройки формы
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.cmbRating);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }
    }
}
