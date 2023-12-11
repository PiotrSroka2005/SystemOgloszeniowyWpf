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
    /// Logika interakcji dla klasy WyszukaneOgloszenia.xaml
    /// </summary>
    public partial class WyszukaneOgloszenia : Window
    {

        private List<Kategoria> kategorie;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";
        private string szukana = "";
        private int wybranaKategoria = 0;

        public WyszukaneOgloszenia(string Szukana)
        {
            InitializeComponent();
           
            Baza.TabelaOgloszenia();

            uzytkownik.Visibility = Visibility.Collapsed;
            PanelAdm.Visibility = Visibility.Collapsed;
            Wyl.Visibility = Visibility.Collapsed;
            profil.Visibility = Visibility.Collapsed;

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;

            // Wczytaj ogłoszenia            

            szukana = Szukana;
            

            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaSzukana(szukana);
        }

        public WyszukaneOgloszenia(int WybranaKategoria)
        {
            InitializeComponent();

            Baza.TabelaOgloszenia();

            uzytkownik.Visibility = Visibility.Collapsed;
            PanelAdm.Visibility = Visibility.Collapsed;
            Wyl.Visibility = Visibility.Collapsed;
            profil.Visibility = Visibility.Collapsed;

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;

            // Wczytaj ogłoszenia            
         

            wybranaKategoria = WybranaKategoria;

            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaKategoria(wybranaKategoria);
        }

        public WyszukaneOgloszenia(int adm, bool log, string user, string Szukana)
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

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;

            szukana = Szukana;
            

            // Wczytaj ogłoszenia
            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaSzukana(szukana);
            
        }

        public WyszukaneOgloszenia(int adm, bool log, string user, int WybranaKategoria)
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

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;
            

            wybranaKategoria = WybranaKategoria;

            // Wczytaj ogłoszenia
            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaKategoria(wybranaKategoria);

        }

        public WyszukaneOgloszenia(int adm, bool log, string user,string Szukana, int WybranaKategoria)
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

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();
            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;

            szukana = Szukana;  
            wybranaKategoria = WybranaKategoria;

            // Wczytaj ogłoszenia
            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszenia(szukana, wybranaKategoria);

        }

        public WyszukaneOgloszenia(string Szukana, int WybranaKategoria)
        {
            InitializeComponent();

            Baza.TabelaOgloszenia();

            uzytkownik.Visibility = Visibility.Collapsed;
            PanelAdm.Visibility = Visibility.Collapsed;
            Wyl.Visibility = Visibility.Collapsed;
            profil.Visibility = Visibility.Collapsed;

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            kategorie = Baza.CzytajKategorie();

            Kategoria specjalnaKategoria = new Kategoria { KategoriaId = 0, KategoriaNazwa = "Wybierz kategorie:" };
            kategorie.Insert(0, specjalnaKategoria);
            KategoriaComboBox.ItemsSource = kategorie;

            // Wczytaj ogłoszenia            

            szukana = Szukana;
            wybranaKategoria = WybranaKategoria;

            viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszenia(szukana, wybranaKategoria);
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

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;


            Ogloszenie ogloszenie = button?.DataContext as Ogloszenie;


            if (ogloszenie != null)
            {
                int idOgloszenia = ogloszenie.OgloszenieId;


                SzczegolyOgloszenia szczegolyWindow = new SzczegolyOgloszenia(admin, logged, usermn, idOgloszenia);
                szczegolyWindow.Show();
                this.Close();
            }
        }

        private void Szukaj_Click(object sender, RoutedEventArgs e)
        {
            string Szukana = searchBar.Text;

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            if (KategoriaComboBox.SelectedIndex != -1 && KategoriaComboBox.SelectedIndex != 0)
            {
                var zaznaczonaKategoria = KategoriaComboBox.SelectedItem as Kategoria;
                if (zaznaczonaKategoria != null)
                {
                    int zaznaczonaKategoriaId = zaznaczonaKategoria.KategoriaId;
                    if (searchBar.Text == "")
                    {
                        viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaKategoria(zaznaczonaKategoriaId);
                    }
                    else
                    {
                        viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszenia(Szukana, zaznaczonaKategoriaId);
                    }

                }
            }
            else
            {
                viewModel.Ogloszenia = Baza.CzytajWyszukaneOgloszeniaSzukana(Szukana);
            }
        }
    }
}
