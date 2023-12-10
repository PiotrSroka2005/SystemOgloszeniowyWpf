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

            usermn = user;
            admin = adm;
            logged = log;

            ogloszenia = Baza.CzytajOgloszeniaSzczegoly(IdOgloszenia);

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            viewModel.Ogloszenia = ogloszenia;

        }


    }
}
