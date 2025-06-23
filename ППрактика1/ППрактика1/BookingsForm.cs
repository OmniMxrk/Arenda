using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class BookingsForm : Form
    {
        private int currentUserId;
        private int currentApartmentId;
        private int currentYear;
        private int currentMonth;
        private List<Booking> bookingList;

        // Выбранные даты для новой брони
        private DateTime selectedStartDate = DateTime.MinValue;
        private DateTime selectedEndDate = DateTime.MinValue;
        // Запоминаем последний клик по календарю (для обновления ListBox)
        private DateTime lastClickedDate = DateTime.MinValue;

        // Класс для представления бронирования из БД
        public class Booking
        {
            public int BookingID { get; set; }
            public int BookingUserID { get; set; }
            public int ApartmentID { get; set; }
            public string Title { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        // Вспомогательный класс для отображения брони в ListBox
        public class BookingListItem
        {
            public Booking Booking { get; set; }
            public string DisplayText { get; set; }
            public override string ToString() => DisplayText;
        }

        public BookingsForm(int userId, int apartmentId)
        {
            InitializeComponent();
            currentUserId = userId;
            currentApartmentId = apartmentId;
            currentYear = DateTime.Today.Year;
            currentMonth = DateTime.Today.Month;
            LoadBookingsFromDB();
            UpdateMonthLabel();
            pnlCalendar.Invalidate();

            // Подписываемся на изменение выбора в ListBox
            lstBookings.SelectedIndexChanged += lstBookings_SelectedIndexChanged;
            // Изначально деактивируем кнопки отмены и отзыва
            btnCancelBooking.Enabled = false;
            btnLeaveReview.Enabled = false;
        }

        /// <summary>
        /// Загружает бронирования для выбранной квартиры из БД.
        /// </summary>
        private void LoadBookingsFromDB()
        {
            bookingList = new List<Booking>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT b.BookingID, b.UserID, b.ApartmentID, a.Title, b.StartDate, b.EndDate 
                                 FROM Bookings b 
                                 JOIN Apartments a ON b.ApartmentID = a.ApartmentID 
                                 WHERE b.ApartmentID = @apartmentId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@apartmentId", currentApartmentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking b = new Booking()
                            {
                                BookingID = Convert.ToInt32(reader["BookingID"]),
                                BookingUserID = Convert.ToInt32(reader["UserID"]),
                                ApartmentID = Convert.ToInt32(reader["ApartmentID"]),
                                Title = reader["Title"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"])
                            };
                            bookingList.Add(b);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обновляет метку с названием текущего месяца и года.
        /// </summary>
        private void UpdateMonthLabel()
        {
            lblCurrentMonth.Text = $"{new DateTime(currentYear, currentMonth, 1):MMMM yyyy}";
        }

        /// <summary>
        /// Отрисовывает календарь для текущего месяца.
        /// Цвет ячейки: LightGreen – если есть бронь пользователя, LightCoral – если чужая бронь, LightGray – свободно.
        /// </summary>
        private void pnlCalendar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            DateTime firstDayOfMonth = new DateTime(currentYear, currentMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);

            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            startDayOfWeek = startDayOfWeek == 0 ? 6 : startDayOfWeek - 1;

            int cellWidth = pnlCalendar.Width / 7;
            int cellHeight = pnlCalendar.Height / 6;

            for (int day = 1; day <= daysInMonth; day++)
            {
                int index = day + startDayOfWeek - 1;
                int row = index / 7;
                int col = index % 7;
                Rectangle cellRect = new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight);

                DateTime currentDay = new DateTime(currentYear, currentMonth, day);
                Color fillColor = Color.LightGray;
                bool isMyBooking = false;
                bool isOtherBooking = false;

                foreach (var booking in bookingList)
                {
                    if (currentDay >= booking.StartDate.Date && currentDay <= booking.EndDate.Date)
                    {
                        if (booking.BookingUserID == currentUserId)
                            isMyBooking = true;
                        else
                            isOtherBooking = true;
                    }
                }

                if (isMyBooking)
                    fillColor = Color.LightGreen;
                else if (isOtherBooking)
                    fillColor = Color.LightCoral;

                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    g.FillRectangle(brush, cellRect);
                }
                g.DrawRectangle(Pens.Black, cellRect);
                TextRenderer.DrawText(g, day.ToString(), this.Font,
                    new Point(cellRect.X + 5, cellRect.Y + 5), Color.Black);
            }
        }

        /// <summary>
        /// Вызывается при клике по панели календаря.
        /// Запоминается выбранный день, выводятся в ListBox как выбранные даты для брони (если заданы)
        /// и список броней, попадающих на этот день.
        /// </summary>
        private void pnlCalendar_MouseClick(object sender, MouseEventArgs e)
        {
            int cellWidth = pnlCalendar.Width / 7;
            int cellHeight = pnlCalendar.Height / 6;
            int col = e.X / cellWidth;
            int row = e.Y / cellHeight;

            DateTime firstDay = new DateTime(currentYear, currentMonth, 1);
            int startDayOfWeek = (int)firstDay.DayOfWeek;
            startDayOfWeek = startDayOfWeek == 0 ? 6 : startDayOfWeek - 1;

            int day = row * 7 + col - startDayOfWeek + 1;
            if (day < 1 || day > DateTime.DaysInMonth(currentYear, currentMonth))
                return;

            DateTime clicked = new DateTime(currentYear, currentMonth, day);
            lastClickedDate = clicked;

            // Проверяем, есть ли бронь на выбранный день от другого пользователя
            Booking otherBooking = bookingList.Find(b => clicked >= b.StartDate.Date && clicked <= b.EndDate.Date
                                                          && b.BookingUserID != currentUserId);
            if (otherBooking != null)
            {
                MessageBox.Show("Эта дата уже забронирована!", "Ошибка");
                return;
            }

            // Проверяем, есть ли бронь, оформленная вами, на эту дату
            Booking myBooking = bookingList.Find(b => clicked >= b.StartDate.Date && clicked <= b.EndDate.Date
                                                       && b.BookingUserID == currentUserId);
            if (myBooking != null)
            {
                // В режиме отмены брони:
                PopulateBookingsForDate(clicked);
                // Делаем кнопку бронирования недоступной, чтобы нельзя было заново бронировать
                btnConfirmBooking.Enabled = false;
                return;
            }
            else
            {
                // Если на эту дату брони нет, включаем режим оформления новой брони
                btnConfirmBooking.Enabled = true;
                PopulateBookingsForDate(clicked);
                // Логика выбора дат для новой брони:
                if (selectedStartDate == DateTime.MinValue)
                {
                    selectedStartDate = clicked;
                    MessageBox.Show($"Дата заезда установлена: {selectedStartDate:yyyy-MM-dd}");
                }
                else if (selectedEndDate == DateTime.MinValue)
                {
                    if (clicked <= selectedStartDate)
                    {
                        MessageBox.Show("Дата выезда должна быть позже даты заезда!", "Ошибка");
                        return;
                    }
                    selectedEndDate = clicked;
                    MessageBox.Show($"Дата выезда установлена: {selectedEndDate:yyyy-MM-dd}");
                }
            }
        }

        /// <summary>
        /// Заполняет ListBox информацией:
        ///  — Если заданы даты для новой брони, они выводятся первыми.
        ///  — Затем выводятся бронирования, попадающие в chosenDate.
        /// </summary>
        private void PopulateBookingsForDate(DateTime chosenDate)
        {
            lstBookings.Items.Clear();

            // Отобразить выбранные даты для новой брони, если заданы
            if (selectedStartDate != DateTime.MinValue)
                lstBookings.Items.Add($"Выбран: Заезд {selectedStartDate:dd.MM.yyyy}");
            if (selectedEndDate != DateTime.MinValue)
                lstBookings.Items.Add($"Выбран: Выезд {selectedEndDate:dd.MM.yyyy}");

            // Добавить бронирования, которые затрагивают chosenDate
            foreach (var b in bookingList)
            {
                if (chosenDate >= b.StartDate.Date && chosenDate <= b.EndDate.Date)
                {
                    string prefix = b.BookingUserID == currentUserId ? "Моя бронь" : "Чужая бронь";
                    string caption = $"{prefix}: {b.StartDate:dd.MM.yyyy} – {b.EndDate:dd.MM.yyyy}";
                    BookingListItem item = new BookingListItem { Booking = b, DisplayText = caption };
                    lstBookings.Items.Add(item);
                }
            }

            // Если список пуст, выдаем сообщение
            if (lstBookings.Items.Count == 0)
                lstBookings.Items.Add("Свободно");

            // Деактивировать кнопки отмены и отзыва до выбора элемента
            btnCancelBooking.Enabled = false;
            btnLeaveReview.Enabled = false;
        }

        /// <summary>
        /// Обработчик изменения выбора в ListBox:
        /// если выбрана бронь, принадлежащая текущему пользователю, активировать кнопки отмены и отзыва.
        /// </summary>
        private void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem is BookingListItem item)
            {
                if (item.Booking.BookingUserID == currentUserId)
                {
                    btnCancelBooking.Enabled = true;
                    btnLeaveReview.Enabled = true;
                }
                else
                {
                    btnCancelBooking.Enabled = false;
                    btnLeaveReview.Enabled = false;
                }
            }
            else
            {
                btnCancelBooking.Enabled = false;
                btnLeaveReview.Enabled = false;
            }
        }

        /// <summary>
        /// Подтверждает создание новой брони.
        /// </summary>
        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (selectedStartDate == DateTime.MinValue || selectedEndDate == DateTime.MinValue)
            {
                MessageBox.Show("Выберите дату заезда и дату выезда!");
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Bookings (UserID, ApartmentID, StartDate, EndDate) VALUES (@userId, @apartmentId, @startDate, @endDate)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", currentUserId);
                    command.Parameters.AddWithValue("@apartmentId", currentApartmentId);
                    command.Parameters.AddWithValue("@startDate", selectedStartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@endDate", selectedEndDate.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Бронь успешно оформлена!");
            // Обновляем список броней и перерисовываем календарь
            LoadBookingsFromDB();
            PopulateBookingsForDate(lastClickedDate);
            pnlCalendar.Invalidate();
        }

        /// <summary>
        /// Отмена бронирования: удаляется выбранная бронь, если она принадлежит пользователю.
        /// </summary>
        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (!(lstBookings.SelectedItem is BookingListItem item))
            {
                MessageBox.Show("Выберите бронь для отмены.");
                return;
            }
            Booking booking = item.Booking;
            if (booking.BookingUserID != currentUserId)
            {
                MessageBox.Show("Вы можете отменять только свои брони!");
                return;
            }
            if (MessageBox.Show("Отменить выбранную бронь?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            using (var conn = DatabaseHelper.GetConnection())
            {
                string delQuery = "DELETE FROM Bookings WHERE BookingID=@id";
                using (var cmd = new SQLiteCommand(delQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", booking.BookingID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Бронь отменена.");
            LoadBookingsFromDB();
            PopulateBookingsForDate(lastClickedDate);
            pnlCalendar.Invalidate();
        }

        /// <summary>
        /// Открывает форму отзывов для выбранной брони, если она принадлежит пользователю.
        /// </summary>
        private void btnLeaveReview_Click(object sender, EventArgs e)
        {
            if (!(lstBookings.SelectedItem is BookingListItem item))
            {
                MessageBox.Show("Выберите свою бронь для оставления отзыва.");
                return;
            }
            Booking booking = item.Booking;
            if (booking.BookingUserID != currentUserId)
            {
                MessageBox.Show("Отзыв можно оставить только о своей броне.");
                return;
            }
            // Предполагаем, что существует форма ReviewForm, принимающая userId и ApartmentID
            new ReviewForm(currentUserId, booking.ApartmentID).ShowDialog();
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            if (currentMonth == 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            else
            {
                currentMonth--;
            }
            UpdateMonthLabel();
            pnlCalendar.Invalidate();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            if (currentMonth == 12)
            {
                currentMonth = 1;
                currentYear++;
            }
            else
            {
                currentMonth++;
            }
            UpdateMonthLabel();
            pnlCalendar.Invalidate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}