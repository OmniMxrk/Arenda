using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class EditApartmentForm : Form
    {
        private int apartmentId;

        public EditApartmentForm(int apartmentId)
        {
            InitializeComponent();
            this.apartmentId = apartmentId;
            LoadApartmentData();
        }

        private void LoadApartmentData()
        {
            using (var connection = new SQLiteConnection("Data Source=\"M:\\Практика\\ППрактика №1\\Apartment\";Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Title, Description, PricePerDay, IsAvailable FROM Apartments WHERE ApartmentID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", apartmentId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["Title"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            numPrice.Value = Convert.ToDecimal(reader["PricePerDay"]);
                            chkAvailable.Checked = Convert.ToBoolean(reader["IsAvailable"]);
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=\"M:\\Практика\\ППрактика №1\\Apartment\";Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("UPDATE Apartments SET Title = @title, Description = @desc, PricePerDay = @price, IsAvailable = @available WHERE ApartmentID = @id", connection))
                {
                    command.Parameters.AddWithValue("@title", txtName.Text);
                    command.Parameters.AddWithValue("@desc", txtDescription.Text);
                    command.Parameters.AddWithValue("@price", numPrice.Value);
                    command.Parameters.AddWithValue("@available", chkAvailable.Checked);
                    command.Parameters.AddWithValue("@id", apartmentId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Данные успешно обновлены!");
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=\"M:\\Практика\\ППрактика №1\\Apartment\";Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("DELETE FROM Apartments WHERE ApartmentID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", apartmentId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Квартира удалена!");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditApartmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
