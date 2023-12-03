using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SystemOgloszeniowyWpf.Klasy;

namespace SystemOgloszeniowyWpf.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy RejestracjaWindow.xaml
    /// </summary>
    public partial class RejestracjaWindow : Window
    {
        public RejestracjaWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string email = EmailTextBox.Text;
            bool administrator = false;

            Uzytkownik uzytkownik = new Uzytkownik(username, password, email, administrator);
            string patter = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wprowadź login i hasło.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Regex.IsMatch(email, patter) == true)
            {
                if (CzyIstniejeEmail(email) == true)
                {
                    MessageBox.Show("Taki email już istnieje. Jeśli masz już konto proszę się zalogować", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (CzyIstniejeUzytkownik(username) == true)
                    {
                        MessageBox.Show("Taki użytkownik już istnieje", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Baza.UtworzUzytkownika(uzytkownik);

                        MessageBox.Show("Rejestreacja przebiegła pomyślnie.", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);

                        UsernameTextBox.Text = string.Empty;
                        PasswordTextBox.Password = string.Empty;
                        EmailTextBox.Text = string.Empty;

                        Logowanie logowanie = new Logowanie();
                        logowanie.Show();
                        this.Close();

                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę podać poprawny email", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool CzyIstniejeEmail(string email)
        {

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();


                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT COUNT() FROM uzytkownicy WHERE email = @Email;";
                selectCommand.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                return count > 0;
            }
        }

        private bool CzyIstniejeUzytkownik(string username)
        {

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();


                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT COUNT() FROM uzytkownicy WHERE nick = @Username;";
                selectCommand.Parameters.AddWithValue("@Username", username);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                return count > 0;
            }
        }

        private void ZalogujSie_Click(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            this.Close();
        }

        private void StronaGlowna(object sender, RoutedEventArgs e)
        {
            int adm = 0;
            bool log = false;
            string user = "";
            MainWindow mainwindow = new MainWindow(adm, log, user);
            mainwindow.Show();
            this.Close();
        }
    }
}
