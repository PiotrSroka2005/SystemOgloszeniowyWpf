using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SystemOgloszeniowyWpf.Okna.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy ZarzadzanieKategoria.xaml
    /// </summary>
    public partial class ZarzadzanieKategoria : Window
    {
        private ObservableCollection<Kategoria> kategorie;

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public ZarzadzanieKategoria(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            kategorie = new ObservableCollection<Kategoria>(Baza.CzytajKategorie());
            listaKategorie.ItemsSource = kategorie;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            DodajKategorie d = new DodajKategorie(admin, logged, usermn);
            d.Show();
            this.Close();
        }


        private void Usun(object sender, RoutedEventArgs e)
        {


            Kategoria kategoria = (Kategoria)listaKategorie.SelectedItem;
            Baza.UsunKategorie(kategoria);
            kategorie = new ObservableCollection<Kategoria>(Baza.CzytajKategorie());
            listaKategorie.ItemsSource = kategorie;

        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            Kategoria kategoria = (Kategoria)listaKategorie.SelectedItem;

            if (kategoria != null)
            {
                EdytujKategorie d = new EdytujKategorie(kategoria.KategoriaId, kategoria.KategoriaNazwa, admin, logged, usermn);
                d.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wybrać kategorie", "Info", MessageBoxButton.OK);
            }
        }


        private void PanelAdmina_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow d = new AdminWindow(admin, logged, usermn);
            d.Show();
            this.Close();
        }
    }
}
