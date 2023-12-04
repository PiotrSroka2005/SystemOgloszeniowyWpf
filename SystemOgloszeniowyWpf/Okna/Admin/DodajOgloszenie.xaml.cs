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

namespace SystemOgloszeniowyWpf.Okna.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy DodajOgloszenie.xaml
    /// </summary>
    public partial class DodajOgloszenie : Window
    {
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public DodajOgloszenie(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;
        }

        private void ZarzadzajOgloszeniami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieOgloszeniami z = new ZarzadzanieOgloszeniami(admin, logged, usermn);
            z.Show();
            this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
