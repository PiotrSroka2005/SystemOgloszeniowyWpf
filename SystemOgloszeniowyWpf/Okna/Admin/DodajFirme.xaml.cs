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
    /// Logika interakcji dla klasy DodajFirme.xaml
    /// </summary>
    public partial class DodajFirme : Window
    {
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public DodajFirme(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

        }

        private void DodajFirm(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            int id = 0;
            Firma firma = new Firma(id, name);

            Baza.UtworzFirme(firma);

            NameTextBox.Text = string.Empty;
        }

        private void ZarzadzajFirmami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieFirma z = new ZarzadzanieFirma(admin, logged, usermn);
            z.Show();
            this.Close();
        }
    }
}
