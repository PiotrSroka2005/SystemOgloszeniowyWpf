using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
using SystemOgloszeniowyWpf.Klasy;
using SystemOgloszeniowyWpf.Okna;
using SystemOgloszeniowyWpf.Okna.Admin;

namespace SystemOgloszeniowyWpf
{
    /// <summary>
    /// Logika interakcji dla klasy Profil.xaml
    /// </summary>
    public partial class ProfilWindow : Window
    {
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public ProfilWindow(int adm, bool log, string user)
        {
            InitializeComponent();
            PanelAdm.Visibility = Visibility.Collapsed;
            usermn = user;
            admin = adm;
            logged = log;

            if (logged == false)
            {
                Wyl.Visibility = Visibility.Collapsed;
                uzytkownik.Visibility = Visibility.Collapsed;
            }
            else
            {
                uzytkownik.Header = user;
                Zal.Visibility = Visibility.Collapsed;
                if (admin == 1)
                {
                    PanelAdm.Visibility = Visibility.Visible;
                }
                else
                {
                    PanelAdm.Visibility = Visibility.Collapsed;
                }
            }


            MainViewProfile viewModel = new MainViewProfile();
            DataContext = viewModel;

            viewModel.Profile = Baza.CzytajProfil(usermn);
        }

        private void ZalogujSie_Click(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            this.Close();
        }

        private void WylogujSie_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }


        private void StronaGlowna(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(admin, logged, usermn);
            mainwindow.Show();
            this.Close();
        }

        private void PanelAdmina_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow d = new AdminWindow(admin, logged, usermn);
            d.Show();
            this.Close();
        }

        private void ZdjProf_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Pliki obrazów|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Wszystkie pliki|*.*";
            
            bool? wynik = openFileDialog.ShowDialog();
            
            if (wynik == true)
            {                
                string oryginalnaSciezkaDoPliku = openFileDialog.FileName;
                
                string folderImages = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".../Images");
                
                if (!Directory.Exists(folderImages))
                {
                    Directory.CreateDirectory(folderImages);
                }
               
                string sciezkaDoZapisanegoPliku = System.IO.Path.Combine(folderImages, System.IO.Path.GetFileName(oryginalnaSciezkaDoPliku));
                
                File.Copy(oryginalnaSciezkaDoPliku, sciezkaDoZapisanegoPliku, true);
                              
                ZapiszSciezkeDoBazyDanych(sciezkaDoZapisanegoPliku);
                
                MessageBox.Show("Plik zapisano w folderze 'Images' i ścieżka została zapisana w bazie danych.");
            }
        }

        private void ZapiszSciezkeDoBazyDanych(string sciezka)
        {
            
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO profil (zdjecie_profilowe) VALUES ('@Sciezka'));";                
                insertCommand.Parameters.AddWithValue("@Sciezka", sciezka);
                insertCommand.ExecuteReader();
            }
            
        }
    }
}
