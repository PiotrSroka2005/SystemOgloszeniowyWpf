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
    /// Logika interakcji dla klasy EdytujKategorie.xaml
    /// </summary>
    public partial class EdytujKategorie : Window
    {
        

        private int _id;


        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public EdytujKategorie(int id, string nazwa, int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            Btn_Nazwa.Text = nazwa;
            _id = id;
        }

        private void EdytujKat(object sender, RoutedEventArgs e)
        {
            string nazwa = Btn_Nazwa.Text;


            if (!string.IsNullOrWhiteSpace(Btn_Nazwa.Text))
            {
                int id = _id;


                Kategoria kat = new Kategoria();
                kat.KategoriaId = id;
                kat.KategoriaNazwa = nazwa;


                Baza.EdycjaKategorii(kat);

                MessageBox.Show("Kategoria została zaktualizowana", "Info", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Proszę uzupełnic pola", "Info", MessageBoxButton.OK);
            }
        }


        private void ZarzadzajKategoriami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieKategoria z = new ZarzadzanieKategoria(admin, logged, usermn);
            z.Show();
            this.Close();
        }
    }
}
