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
    /// Logika interakcji dla klasy ZarzadzanieFirma.xaml
    /// </summary>
    public partial class ZarzadzanieFirma : Window
    {
        private ObservableCollection<Firma> firmy;

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public ZarzadzanieFirma(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            firmy = new ObservableCollection<Firma>(Baza.CzytajFirmy());
            listaFirmy.ItemsSource = firmy;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            DodajFirme d = new DodajFirme(admin, logged, usermn);
            d.Show();
            this.Close();
        }


        private void Usun(object sender, RoutedEventArgs e)
        {
            Firma firma = (Firma)listaFirmy.SelectedItem;
            Baza.UsunFirme(firma);
            firmy = new ObservableCollection<Firma>(Baza.CzytajFirmy());
            listaFirmy.ItemsSource = firmy;

        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            Firma firma = (Firma)listaFirmy.SelectedItem;

            if (firma != null)
            {
                EdytujFirme d = new EdytujFirme(firma.FirmaId, firma.FirmaNazwa, admin, logged, usermn);
                d.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wybrać firme", "Info", MessageBoxButton.OK);
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
