using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class UserForm : Form
    {
        private int userId; // Идентификатор пользователя — передаётся из формы логина

        // Класс для представления квартиры
        public class Apartment
        {
            public int ApartmentID { get; set; }
            public string Title { get; set; }
            public decimal PricePerDay { get; set; }

            public override string ToString()
            {
                return $"{Title} — {PricePerDay} руб/день (ID: {ApartmentID})";
            }
        }

        public UserForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadApartments();
        }

        /// <summary>
        /// Загружает список доступных квартир в ListBox.
        /// </summary>
        private void LoadApartments()
        {
            lstApartments.Items.Clear();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ApartmentID, Title, PricePerDay FROM Apartments WHERE IsAvailable = 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Apartment apt = new Apartment()
                            {
                                ApartmentID = Convert.ToInt32(reader["ApartmentID"]),
                                Title = reader["Title"].ToString(),
                                PricePerDay = Convert.ToDecimal(reader["PricePerDay"])
                            };
                            lstApartments.Items.Add(apt);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Открывает календарь бронирования для выбранной квартиры.
        /// </summary>
        private void BtnViewBookings_Click(object sender, EventArgs e)
        {
            if (lstApartments.SelectedItem == null)
            {
                MessageBox.Show("Выберите квартиру для просмотра календаря бронирования.");
                return;
            }
            Apartment selectedApartment = (Apartment)lstApartments.SelectedItem;
            BookingsForm bookingsForm = new BookingsForm(userId, selectedApartment.ApartmentID);
            bookingsForm.ShowDialog();
        }

        /// <summary>
        /// Закрывает форму и возвращает пользователя на экран входа.
        /// </summary>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}