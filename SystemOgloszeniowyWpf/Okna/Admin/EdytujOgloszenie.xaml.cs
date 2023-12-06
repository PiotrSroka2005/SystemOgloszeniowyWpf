using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy EdytujOgloszenie.xaml
    /// </summary>
    public partial class EdytujOgloszenie : Window
    {

        private List<Kategoria> kategorie;
        private List<Firma> firmy;
        private ObservableCollection<Ogloszenie> ogloszenia;
        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        private int _id;
        public EdytujOgloszenie(int ogloszenieId, int kategoriaId, int firmaId, string tytul, string nazwaStanowiska, string poziomStanowiska, string rodzajPracy, string wymiarZatrudnienia, string rodzajUmowy, decimal? najmniejszeWynagrodzenie,
        decimal? najwiekszeWynagrodzenie, string dniPracy, string godzinyPracy, DateTime? dataWaznosci, string obowiazki, string wymagania, string benefity, string informacje, DateTime dataUtworzenia, string zdjecie, int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;
          

            _id = ogloszenieId;
            kategorie = Baza.CzytajKategorie();
            KategoriaComboBox.ItemsSource = kategorie;
            firmy = Baza.CzytajFirmy();
            FirmaComboBox.ItemsSource = firmy;

            TxBTytul.Text = tytul;

            TxBNazwaStanowiska.Text = nazwaStanowiska;

            TxBPoziomStanowiska.Text = poziomStanowiska;

            TxBRodzajPracy.Text = rodzajPracy;

            TxBWymiarZatrudnienia.Text = wymiarZatrudnienia;

            TxBRodzajUmowy.Text = rodzajUmowy;

            TxBNajmniejszeWynagrodzenie.Text = najmniejszeWynagrodzenie.ToString();

            TxBNajwiekszeWynagrodzenie.Text = najwiekszeWynagrodzenie.ToString();

            TxBDniPracy.Text = dniPracy;

            TxBGodzinyPracy.Text = godzinyPracy;

            TxBDataWaznosci.SelectedDate = dataWaznosci;

            TxBObowiazki.Text = obowiazki;

            TxBWymagania.Text = wymagania;

            TxBBenefity.Text = benefity;

            TxBInformacje.Text = informacje;

            TxBZdjecie.Text = zdjecie;

            DateTime DataUtworzeniaOgloszenia = dataUtworzenia;

        
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {

            Kategoria wybranaKategoria = (Kategoria)KategoriaComboBox.SelectedItem;

            Firma wybranaFirma = (Firma)FirmaComboBox.SelectedItem;

            string Tytul = TxBTytul.Text;

            string NazwaStanowiska = TxBNazwaStanowiska.Text;

            string PoziomStanowiska = TxBPoziomStanowiska.Text;

            string RodzajPracy = TxBRodzajPracy.Text;

            string WymiarZatrudnienia = TxBWymiarZatrudnienia.Text;

            string RodzajUmowy = TxBRodzajUmowy.Text;

            string NajmniejszeWynagrodzenieText = TxBNajmniejszeWynagrodzenie.Text;

            string NajwiekszeWynagrodzenieText = TxBNajwiekszeWynagrodzenie.Text;

            string DniPracy = TxBDniPracy.Text;

            string GodzinyPracy = TxBGodzinyPracy.Text;

            DateTime? DataWaznosci = TxBDataWaznosci.SelectedDate;

            string Obowiazki = TxBObowiazki.Text;

            string Wymagania = TxBWymagania.Text;

            string Benefity = TxBBenefity.Text;

            string Informacje = TxBInformacje.Text;
            
            string Zdjecie = TxBZdjecie.Text;

            if (DataWaznosci == null)
            {
                MessageBox.Show("Podaj datę ważności.", "Product Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal NajmniejszeWynagrodzenie;
            decimal NajwiekszeWynagrodzenie;
            if (Regex.IsMatch(NajmniejszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajmniejszeWynagrodzenie = decimal.Parse(NajmniejszeWynagrodzenieText);
            }
            else
            {
                MessageBox.Show("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Regex.IsMatch(NajwiekszeWynagrodzenieText, @"^[-,0-9]+$"))
            {
                NajwiekszeWynagrodzenie = decimal.Parse(NajwiekszeWynagrodzenieText);
            }
            else
            {
                MessageBox.Show("Mozna wprowadzac wartosc dziesietne tylko po przecinku.", "Product Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(string.IsNullOrWhiteSpace(TxBTytul.Text) || string.IsNullOrWhiteSpace(TxBNazwaStanowiska.Text) || string.IsNullOrWhiteSpace(TxBRodzajPracy.Text) || string.IsNullOrWhiteSpace(TxBWymiarZatrudnienia.Text) ||
      string.IsNullOrWhiteSpace(TxBRodzajUmowy.Text) || string.IsNullOrWhiteSpace(TxBTytul.Text) || string.IsNullOrWhiteSpace(TxBNajmniejszeWynagrodzenie.Text) || string.IsNullOrWhiteSpace(TxBNajwiekszeWynagrodzenie.Text) || string.IsNullOrWhiteSpace(TxBDniPracy.Text) ||
      string.IsNullOrWhiteSpace(TxBGodzinyPracy.Text) || string.IsNullOrWhiteSpace(TxBDataWaznosci.Text) || string.IsNullOrWhiteSpace(TxBObowiazki.Text) || string.IsNullOrWhiteSpace(TxBWymagania.Text) || string.IsNullOrWhiteSpace(TxBBenefity.Text) || string.IsNullOrWhiteSpace(TxBInformacje.Text) || string.IsNullOrWhiteSpace(TxBZdjecie.Text)))
            {
                if(wybranaKategoria != null)
                {
                    if (wybranaFirma != null)
                    {
                        int id = _id;
                        int kategoria = wybranaKategoria.KategoriaId;
                        int firma = wybranaFirma.FirmaId;

                        Ogloszenie oglo = new Ogloszenie();
                        oglo.KategoriaId = kategoria;
                        oglo.FirmaId = firma;
                        oglo.Tytul = Tytul;
                        oglo.NazwaStanowiska = NazwaStanowiska;
                        oglo.PoziomStanowiska = PoziomStanowiska;
                        oglo.RodzajPracy = RodzajPracy;
                        oglo.WymiarZatrudnienia = WymiarZatrudnienia;
                        oglo.RodzajUmowy = RodzajUmowy;
                        oglo.NajmniejszeWynagrodzenie = NajmniejszeWynagrodzenie;
                        oglo.NajwiekszeWynagrodzenie = NajwiekszeWynagrodzenie;
                        oglo.DniPracy = DniPracy;
                        oglo.GodzinyPracy = GodzinyPracy;
                        oglo.OgloszenieId = id;
                        oglo.DataWaznosci = DataWaznosci;
                        oglo.Obowiazki = Obowiazki;
                        oglo.Wymagania = Wymagania;
                        oglo.Benefity = Benefity;
                        oglo.Informacje = Informacje;
                        oglo.Zdjecie = Zdjecie;
                        Baza.EdycjaOgloszenia(oglo);

                        MessageBox.Show("Ogłoszenie zostało zaktualizowane", "Info", MessageBoxButton.OK);
                    }                        
                }
            }
            else
            {
                MessageBox.Show("Proszę uzupełnic pola", "Info", MessageBoxButton.OK);
            }
        }


        private void ZarzadzajOgloszeniami(object sender, RoutedEventArgs e)
        {
            ZarzadzanieOgloszeniami z = new ZarzadzanieOgloszeniami(admin, logged, usermn);
            z.Show();
            this.Close();
        }
    }
}
