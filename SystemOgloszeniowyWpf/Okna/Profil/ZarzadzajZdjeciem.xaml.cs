using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemOgloszeniowyWpf.Okna.Profil
{
    /// <summary>
    /// Logika interakcji dla klasy ZarzadzajZdjeciem.xaml
    /// </summary>
    public partial class ZarzadzajZdjeciem : Window
    {

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        private string przeslanaSciezka = "";

        public ZarzadzajZdjeciem(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;
        }


        public ZarzadzajZdjeciem(int adm, bool log, string user, string sciezka)
        {
            InitializeComponent();


            przeslanaSciezka = sciezka;
            usermn = user;
            admin = adm;
            logged = log;

            ZdjButton.Content = "Edytuj";
        }

        private void DodajLubEdytuj(object sender, RoutedEventArgs e)
        {
            string LokalnaSciezka = SciezkaTextBox.Text;

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var command = new SqliteCommand();
                command.Connection = db;

                if (string.IsNullOrEmpty(przeslanaSciezka))
                {
                    command.CommandText = "INSERT INTO profile (zdjecie_profilowe) VALUES (@Sciezka);";
                    command.Parameters.AddWithValue("@Sciezka", LokalnaSciezka);
                }
                else
                {                    
                    command.CommandText = "UPDATE profile SET zdjecie_profilowe = @Sciezka WHERE warunek_edycji";
                    command.Parameters.AddWithValue("@Sciezka", przeslanaSciezka);
                }

                command.ExecuteNonQuery();
            }
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow p = new ProfilWindow(admin, logged, usermn);
            p.Show();
            this.Close();
        }
    }
}
