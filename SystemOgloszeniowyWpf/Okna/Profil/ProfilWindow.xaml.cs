using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SystemOgloszeniowyWpf.Okna.Profil;

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


            Baza.TabelaProfile(usermn);
            

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

            MainViewProfile viewModel = new MainViewProfile(usermn);
            DataContext = viewModel;

            viewModel.Aplikacje = Baza.PobierzAplikacjeUzytkownika(usermn);
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
            ZarzadzajZdjeciem z = new ZarzadzajZdjeciem(admin, logged, usermn);
            z.Show();
            this.Close();
           
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var aplikacja = button.DataContext as Aplikacja;
                if (aplikacja != null)
                {
                    Baza.UsunAplikacje(aplikacja.IdOgloszenia, aplikacja.NazwaUzytkownika);

                    var viewModel = DataContext as MainViewProfile;
                    if (viewModel != null)
                    {
                        viewModel.Aplikacje = Baza.PobierzAplikacjeUzytkownika(usermn);
                    }
                }
            }
        }

        
    }
}
