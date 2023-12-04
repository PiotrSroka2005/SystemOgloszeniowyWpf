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
    /// Logika interakcji dla klasy ZarzadzanieOgloszeniami.xaml
    /// </summary>
    public partial class ZarzadzanieOgloszeniami : Window
    {
        private ObservableCollection<Ogloszenie> ogloszenia;

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public ZarzadzanieOgloszeniami(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            ogloszenia = new ObservableCollection<Ogloszenie>(Baza.CzytajWszystkieOgloszenia());
            listaOgloszenia.ItemsSource = ogloszenia;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            DodajOgloszenie d = new DodajOgloszenie(admin, logged, usermn);
            d.Show();
            this.Close();
        }

        private void Usun(object sender, RoutedEventArgs e)
        {

        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {

        }

        private void PanelAdmina_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow d = new AdminWindow(admin, logged, usermn);
            d.Show();
            this.Close();
        }

        
    }
}
