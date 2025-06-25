using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class AdminForm : Form
    {
        // Простой класс для хранения информации о квартире
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

        public AdminForm()
        {
            InitializeComponent();
            LoadApartments();
        }

        private void LoadApartments()
        {
            lstApartments.Items.Clear();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ApartmentID, Title, PricePerDay FROM Apartments";
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

        private void BtnAddApartment_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления квартиры
            AddApartmentForm addForm = new AddApartmentForm();
            addForm.ShowDialog();
            LoadApartments();
        }

        private void BtnEditApartment_Click(object sender, EventArgs e)
        {
            if (lstApartments.SelectedItem == null)
            {
                MessageBox.Show("Выберите квартиру для редактирования.");
                return;
            }
            Apartment selectedApartment = (Apartment)lstApartments.SelectedItem;
            // Открываем форму редактирования с передачей выбранного ID
            EditApartmentForm editForm = new EditApartmentForm(selectedApartment.ApartmentID);
            editForm.ShowDialog();
            LoadApartments();
        }

        private void BtnViewBookings_Click(object sender, EventArgs e)
        {
            int currentAdminId = 1;
            int apartmentId = 0; // 0 означает "все квартиры"
            BookingsForm bookingsForm = new BookingsForm(currentAdminId, apartmentId);
            bookingsForm.ShowDialog();
        }


        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadApartments();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
