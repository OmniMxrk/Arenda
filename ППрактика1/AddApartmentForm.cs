using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ППрактика1
{
    public partial class AddApartmentForm : Form
    {
        public AddApartmentForm()
        {
            InitializeComponent();
        }

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg;*.png)|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog.FileName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=\"M:\\Практика\\ППрактика №1\\Apartment\";Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("INSERT INTO Apartments (Title, Description, PricePerDay, ImagePath, IsAvailable) VALUES (@title, @desc, @price, @image, @available)", connection))
                {
                    command.Parameters.AddWithValue("@title", txtName.Text);
                    command.Parameters.AddWithValue("@desc", txtDescription.Text);
                    command.Parameters.AddWithValue("@price", numPrice.Value);
                    command.Parameters.AddWithValue("@image", txtImagePath.Text);
                    command.Parameters.AddWithValue("@available", chkAvailable.Checked);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Квартира успешно добавлена!");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
