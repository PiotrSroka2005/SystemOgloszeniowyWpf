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
using SystemOgloszeniowyWpf.Klasy;
using SystemOgloszeniowyWpf.Okna.Admin;

namespace SystemOgloszeniowyWpf.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy SzczegolyOglozenia.xaml
    /// </summary>
    public partial class SzczegolyOgloszenia : Window
    {
        private List<Ogloszenie> ogloszenia;

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";        

        public SzczegolyOgloszenia(int adm, bool log, string user, int IdOgloszenia)
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
                profil.Visibility = Visibility.Collapsed;
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

            Baza.TabelaOgloszenia();

            ogloszenia = Baza.CzytajOgloszeniaSzczegoly(IdOgloszenia);

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            viewModel.Ogloszenia = ogloszenia;

        }


        public SzczegolyOgloszenia(int IdOgloszenia)
        {
            InitializeComponent();

            Baza.TabelaOgloszenia();

            uzytkownik.Visibility = Visibility.Collapsed;
            PanelAdm.Visibility = Visibility.Collapsed;
            Wyl.Visibility = Visibility.Collapsed;
            profil.Visibility = Visibility.Collapsed;

            ogloszenia = Baza.CzytajOgloszeniaSzczegoly(IdOgloszenia);

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            viewModel.Ogloszenia = ogloszenia;

        }


        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow p = new ProfilWindow(admin, logged, usermn);
            p.Show();
            this.Close();
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







    }
}
