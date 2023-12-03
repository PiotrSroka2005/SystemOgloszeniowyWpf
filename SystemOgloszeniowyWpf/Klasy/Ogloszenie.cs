using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyWpf.Klasy
{
    public class Ogloszenie
    {
        public int Id { get; set; }

        public string Tytul {  get; set; }

        public string NazwaStanowiska { get; set; }

        public string PoziomStanowiska { get; set; }

        public string RodzajPracy {  get; set; }

        public string WymiarZatrudnienia { get; set; }

        public int Kategoria {  get; set; }

        public int Firma {  get; set; }

        public string RodzajUmowy {  get; set; }

        public decimal? NajmniejszeWynagrodzenie { get; set; }

        public decimal? NajwiekszeWynagrodzenie { get; set; }

        public string DniPracy { get; set; }

        public string GodzinyPracy { get; set; }

        public DateTime DataWaznosci {  get; set; }

        public string Obowiazki {  get; set; }

        public string Wymagania { get; set; }

        public string Benefity { get; set; }

        public string Informacje { get; set; }

        public DateTime DataUtworzenia { get; set; }

        public Ogloszenie(int id, int kategoria, int firma, string tytul, string nazwaStanowiska, string poziomStanowska, string rodzajPracy, string wymiarZatrudnienia, string rodzajUmowy, decimal? najmniejszeWynagrodzenie,
        decimal? najwiekszeWynagrodzenie, string dniPracy, string godzinyPracy, DateTime dataWaznosci, string obowiazki, string wymagania, string benefity, string informacje, DateTime dataUtworzenia)
        {
            Id = id;
            Kategoria = kategoria;
            Firma = firma;
            Tytul = tytul;
            NazwaStanowiska = nazwaStanowiska;
            PoziomStanowiska = poziomStanowska;
            RodzajPracy = rodzajPracy;
            WymiarZatrudnienia = wymiarZatrudnienia;
            RodzajUmowy = rodzajUmowy;
            NajmniejszeWynagrodzenie = najmniejszeWynagrodzenie;
            NajwiekszeWynagrodzenie = najwiekszeWynagrodzenie;
            DniPracy = dniPracy;
            GodzinyPracy = godzinyPracy;
            DataWaznosci = dataWaznosci;
            Obowiazki = obowiazki;
            Wymagania = wymagania;
            Benefity = benefity;
            Informacje = informacje;
            DataUtworzenia = dataUtworzenia;
        }

        public Ogloszenie() { }

    }
}
