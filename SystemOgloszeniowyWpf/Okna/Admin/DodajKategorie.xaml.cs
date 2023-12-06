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

namespace SystemOgloszeniowyWpf.Okna.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKategorie.xaml
    /// </summary>
    public partial class DodajKategorie : Window
    {
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public DodajKategorie(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

        }

        private void DodajKat(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            int id = 0;
            Kategoria kategoria = new Kategoria(id, name);

            Baza.UtworzKategorie(kategoria);

            NameTextBox.Text = string.Empty;
        }

        private void ZarzadzajKategoriami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieKategoria z = new ZarzadzanieKategoria(admin, logged, usermn);
            z.Show();
            this.Close();
        }
    }
}
