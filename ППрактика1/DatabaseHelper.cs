using System;
using System.Data.SQLite;

namespace ППрактика1
{
    public static class DatabaseHelper
    {
        // Строка подключения к базе данных
        private static string connectionString = "Data Source=\"M:\\Практика\\ППрактика №1\\Apartment\";Version=3;";

        /// <summary>
        /// Возвращает открытое подключение к базе данных.
        /// Если подключение не удалось открыть, выбрасывается исключение.
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось открыть подключение к базе данных.", ex);
            }
        }

        /// <summary>
        /// Аутентификация пользователя по номеру телефона и паролю.
        /// Если пользователь найден, возвращается значение isAdmin.
        /// </summary>
        public static bool AuthenticateUser(string phone, string password, out bool isAdmin, out int userId)
        {
            isAdmin = false;
            userId = 0;
            using (var connection = GetConnection())
            {
                using (var command = new SQLiteCommand("SELECT UserID, IsAdmin FROM Users WHERE PhoneNumber = @phone AND Password = @password", connection))
                {
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["UserID"]);
                            isAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
