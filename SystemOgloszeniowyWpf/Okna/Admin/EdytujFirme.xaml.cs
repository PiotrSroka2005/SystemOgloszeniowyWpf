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
    /// Logika interakcji dla klasy EdytujFirme.xaml
    /// </summary>
    public partial class EdytujFirme : Window
    {
       
        private int _id;


        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public EdytujFirme(int id, string nazwa, int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            Btn_Nazwa.Text = nazwa;
            _id = id;
        }

        private void EdytujFirm(object sender, RoutedEventArgs e)
        {
            string nazwa = Btn_Nazwa.Text;


            if (!string.IsNullOrWhiteSpace(Btn_Nazwa.Text))
            {
                int id = _id;


                Firma firm = new Firma();
                firm.FirmaId = id;
                firm.FirmaNazwa = nazwa;


                Baza.EdycjaFirmy(firm);

                MessageBox.Show("Firma została zaktualizowana", "Info", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Proszę uzupełnic pola", "Info", MessageBoxButton.OK);
            }
        }

        private void ZarzadzajFirmami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieFirma z = new ZarzadzanieFirma(admin, logged, usermn);
            z.Show();
            this.Close();
        }
    }
}
