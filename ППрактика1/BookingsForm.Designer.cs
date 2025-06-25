namespace ППрактика1
{
    partial class BookingsForm
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentMonth;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.ListBox lstBookings;     //  NEW
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnConfirmBooking;
        private System.Windows.Forms.Button btnLeaveReview;   //  NEW
        private System.Windows.Forms.Button btnBack;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentMonth = new System.Windows.Forms.Label();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.lstBookings = new System.Windows.Forms.ListBox(); // NEW
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.btnLeaveReview = new System.Windows.Forms.Button();  // NEW
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ─────────── Заголовок формы
            this.lblTitle.Text = "Календарь бронирований";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Size = new System.Drawing.Size(320, 30);

            // ─────────── Текущий месяц/год
            this.lblCurrentMonth.Text = "Май 2025";          // обновляется кодом
            this.lblCurrentMonth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentMonth.Location = new System.Drawing.Point(80, 42);
            this.lblCurrentMonth.Size = new System.Drawing.Size(200, 22);
            this.lblCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ─────────── Панель-календарь
            this.pnlCalendar.Location = new System.Drawing.Point(20, 70);
            this.pnlCalendar.Size = new System.Drawing.Size(320, 300);
            this.pnlCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalendar.BackColor = System.Drawing.Color.White;
            this.pnlCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCalendar_Paint);
            this.pnlCalendar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCalendar_MouseClick);

            // ─────────── ListBox: брони выбранного дня
            this.lstBookings.Location = new System.Drawing.Point(20, 380);
            this.lstBookings.Size = new System.Drawing.Size(320, 80);
            this.lstBookings.Font = new System.Drawing.Font("Arial", 9F);

            // ─────────── Кнопки смены месяца
            this.btnPrevMonth.Text = "<";
            this.btnPrevMonth.Location = new System.Drawing.Point(20, 470);
            this.btnPrevMonth.Size = new System.Drawing.Size(50, 30);
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);

            this.btnNextMonth.Text = ">";
            this.btnNextMonth.Location = new System.Drawing.Point(290, 470);
            this.btnNextMonth.Size = new System.Drawing.Size(50, 30);
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);

            // ─────────── Кнопка подтверждения брони
            this.btnConfirmBooking.Text = "Забронировать";
            this.btnConfirmBooking.Location = new System.Drawing.Point(20, 510);
            this.btnConfirmBooking.Size = new System.Drawing.Size(150, 35);
            this.btnConfirmBooking.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnConfirmBooking.ForeColor = System.Drawing.Color.White;
            this.btnConfirmBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmBooking.Click += new System.EventHandler(this.btnConfirmBooking_Click);

            // ─────────── Кнопка отмены брони
            this.btnCancelBooking.Text = "Отменить бронь";
            this.btnCancelBooking.Location = new System.Drawing.Point(190, 510);
            this.btnCancelBooking.Size = new System.Drawing.Size(150, 35);
            this.btnCancelBooking.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCancelBooking.ForeColor = System.Drawing.Color.White;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);

            // ─────────── Кнопка «Оставить отзыв»
            this.btnLeaveReview.Text = "Оставить отзыв";
            this.btnLeaveReview.Location = new System.Drawing.Point(20, 555);
            this.btnLeaveReview.Size = new System.Drawing.Size(320, 35);
            this.btnLeaveReview.BackColor = System.Drawing.Color.DarkBlue;
            this.btnLeaveReview.ForeColor = System.Drawing.Color.White;
            this.btnLeaveReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveReview.Click += new System.EventHandler(this.btnLeaveReview_Click);

            // ─────────── Кнопка «Назад»
            this.btnBack.Text = "Назад";
            this.btnBack.Location = new System.Drawing.Point(130, 600);
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.BackColor = System.Drawing.Color.DarkRed;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ─────────── Добавляем элементы на форму
            this.ClientSize = new System.Drawing.Size(360, 650);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.Beige;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCurrentMonth);
            this.Controls.Add(this.pnlCalendar);
            this.Controls.Add(this.lstBookings);      // NEW
            this.Controls.Add(this.btnPrevMonth);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnConfirmBooking);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnLeaveReview);   // NEW
            this.Controls.Add(this.btnBack);

            this.ResumeLayout(false);
        }
    }
}
