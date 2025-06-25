using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class ReviewForm : Form
    {
        private int userId;
        private int apartmentId;

        public ReviewForm(int userId, int apartmentId)
        {
            InitializeComponent();
            this.userId = userId;
            this.apartmentId = apartmentId;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbRating.SelectedItem == null || string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            int rating = Convert.ToInt32(cmbRating.SelectedItem);
            string comment = txtComment.Text;

            using (var connection = new SQLiteConnection("Data Source=Apartment.sqlite;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("INSERT INTO Reviews (UserID, ApartmentID, Rating, Comment) VALUES (@userId, @apartmentId, @rating, @comment)", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@apartmentId", apartmentId);
                    command.Parameters.AddWithValue("@rating", rating);
                    command.Parameters.AddWithValue("@comment", comment);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ваш отзыв успешно добавлен!");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
