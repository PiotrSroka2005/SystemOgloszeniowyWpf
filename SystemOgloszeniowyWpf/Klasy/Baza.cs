using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyWpf.Klasy
{
    public class Baza
    {
        public static void TabelaUzytkownikow()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS uzytkownicy (uzytkownik_id INTEGER PRIMARY KEY AUTOINCREMENT, nick TEXT, haslo TEXT, email TEXT, administrator BOOLEAN)";

                var createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void UtworzUzytkownika(Uzytkownik uzytkownik)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO uzytkownicy VALUES(NULL, @Nick, @Haslo, @Email, @Admin);";
                insertCommand.Parameters.AddWithValue("@Nick", uzytkownik.Nick);
                insertCommand.Parameters.AddWithValue("@Email", uzytkownik.Email);
                insertCommand.Parameters.AddWithValue("@Haslo", uzytkownik.Haslo);
                insertCommand.Parameters.AddWithValue("@Admin", uzytkownik.Administrator);
                insertCommand.ExecuteReader();
            }
        }


        public static void TabelaOgloszenia()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                string tableCommand = "CREATE TABLE IF NOT EXISTS kategorie(kategoria_id INTEGER PRIMARY KEY AUTOINCREMENT, nazwa TEXT);" +
                "CREATE TABLE IF NOT EXISTS firmy(firma_id INTEGER PRIMARY KEY AUTOINCREMENT, nazwa TEXT);" +
                "CREATE TABLE IF NOT EXISTS ogloszenia (ogloszenie_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "kategoria_id INTEGER,firma_id INTEGER,tytul TEXT,nazwa_stanowiska TEXT," +
                "poziom_stanowiska TEXT,rodzaj_pracy TEXT,wymiar_zatrudnienia TEXT,rodzaj_umowy TEXT,najmniejsze_wynagrodzenie DECIMAL(5,2)," +
                "najwieksze_wynagrodzenie DECIMAL(5,2),dni_pracy TEXT,godziny_pracy TEXT,data_waznosci DATE,obowiazki TEXT," +
                "wymagania TEXT,benefity TEXT,informacje TEXT,data_utworzenia DATE, zdjecie TEXT," +
                "FOREIGN KEY(kategoria_id) REFERENCES kategorie(kategoria_id),FOREIGN KEY(firma_id) REFERENCES firmy(firma_id));";
                var createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }
        
        public static void UtworzOgloszenie(Ogloszenie ogloszenie)
        {            
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO ogloszenia VALUES(NULL, @KategoriaId, @FirmaId, @Tytul, @NazwaStanowiska, @PoziomStanowiska, @RodzajPracy, @WymiarZatrudnienia, @RodzajUmowy," +
                    "@NajmniejszeWynagrodzenie, @NajwiekszeWynagrodzenie, @DniPracy, @GodzinyPracy, @DataWaznosci, @Obowiazki, @Wymagania, @Benefity, @Informacje, @DataUtworzenia, @Zdjecie);";
                insertCommand.Parameters.AddWithValue("@KategoriaId", ogloszenie.KategoriaId);
                insertCommand.Parameters.AddWithValue("@FirmaId", ogloszenie.FirmaId);
                insertCommand.Parameters.AddWithValue("@Tytul", ogloszenie.Tytul);
                insertCommand.Parameters.AddWithValue("@NazwaStanowiska", ogloszenie.NazwaStanowiska);
                insertCommand.Parameters.AddWithValue("@PoziomStanowiska", ogloszenie.PoziomStanowiska);
                insertCommand.Parameters.AddWithValue("@RodzajPracy", ogloszenie.RodzajPracy);
                insertCommand.Parameters.AddWithValue("@WymiarZatrudnienia", ogloszenie.WymiarZatrudnienia);
                insertCommand.Parameters.AddWithValue("@RodzajUmowy", ogloszenie.RodzajUmowy);
                insertCommand.Parameters.AddWithValue("@NajmniejszeWynagrodzenie", ogloszenie.NajmniejszeWynagrodzenie);
                insertCommand.Parameters.AddWithValue("@NajwiekszeWynagrodzenie", ogloszenie.NajwiekszeWynagrodzenie);
                insertCommand.Parameters.AddWithValue("@DniPracy", ogloszenie.DniPracy);
                insertCommand.Parameters.AddWithValue("@GodzinyPracy", ogloszenie.GodzinyPracy);
                insertCommand.Parameters.AddWithValue("@DataWaznosci", ogloszenie.DataWaznosci);
                insertCommand.Parameters.AddWithValue("@Obowiazki", ogloszenie.Obowiazki);
                insertCommand.Parameters.AddWithValue("@Wymagania", ogloszenie.Wymagania);
                insertCommand.Parameters.AddWithValue("@Benefity", ogloszenie.Benefity);
                insertCommand.Parameters.AddWithValue("@Informacje", ogloszenie.Informacje);
                insertCommand.Parameters.AddWithValue("@DataUtworzenia", ogloszenie.DataUtworzenia);
                insertCommand.Parameters.AddWithValue("@Zdjecie", ogloszenie.Zdjecie);                
                insertCommand.ExecuteReader();
            }
        }

        public static void EdycjaOgloszenia(Ogloszenie ogloszenie)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                updateCommand.CommandText = "UPDATE ogloszenia SET kategoria_id=@KategoriaId, firma_id=@FirmaId, Tytul=@Tytul, nazwa_stanowiska=@NazwaStanowiska, poziom_stanowiska=@PoziomStanowiska ,rodzaj_pracy=@RodzajPracy,wymiar_zatrudnienia=@WymiarZatrudnienia,rodzaj_umowy=@RodzajUmowy" +
                    ",najmniejsze_wynagrodzenie=@NajmniejszeWynagrodzenie,najwieksze_wynagrodzenie=@NajwiekszeWynagrodzenie,dni_pracy=@DniPracy,godziny_pracy=@GodzinyPracy,data_waznosci=@DataWaznosci,obowiazki=@Obowiazki,wymagania=@Wymagania," +
                    "benefity=@Benefity,informacje=@Informacje, zdjecie=@Zdjecie  WHERE ogloszenie_id = @Id;";
                updateCommand.Parameters.AddWithValue("@Id", ogloszenie.OgloszenieId);
                updateCommand.Parameters.AddWithValue("@KategoriaId", ogloszenie.KategoriaId);
                updateCommand.Parameters.AddWithValue("@FirmaId", ogloszenie.FirmaId);
                updateCommand.Parameters.AddWithValue("@Tytul", ogloszenie.Tytul);
                updateCommand.Parameters.AddWithValue("@NazwaStanowiska", ogloszenie.NazwaStanowiska);
                updateCommand.Parameters.AddWithValue("@PoziomStanowiska", ogloszenie.PoziomStanowiska);
                updateCommand.Parameters.AddWithValue("@RodzajPracy", ogloszenie.RodzajPracy);
                updateCommand.Parameters.AddWithValue("@WymiarZatrudnienia", ogloszenie.WymiarZatrudnienia);
                updateCommand.Parameters.AddWithValue("@RodzajUmowy", ogloszenie.RodzajUmowy);
                updateCommand.Parameters.AddWithValue("@NajmniejszeWynagrodzenie", ogloszenie.NajmniejszeWynagrodzenie);
                updateCommand.Parameters.AddWithValue("@NajwiekszeWynagrodzenie", ogloszenie.NajwiekszeWynagrodzenie);
                updateCommand.Parameters.AddWithValue("@DniPracy", ogloszenie.DniPracy);
                updateCommand.Parameters.AddWithValue("@GodzinyPracy", ogloszenie.GodzinyPracy);
                updateCommand.Parameters.AddWithValue("@DataWaznosci", ogloszenie.DataWaznosci);
                updateCommand.Parameters.AddWithValue("@Obowiazki", ogloszenie.Obowiazki);
                updateCommand.Parameters.AddWithValue("@Wymagania", ogloszenie.Wymagania);
                updateCommand.Parameters.AddWithValue("@Benefity", ogloszenie.Benefity);
                updateCommand.Parameters.AddWithValue("@Informacje", ogloszenie.Informacje);                
                updateCommand.Parameters.AddWithValue("@Zdjecie", ogloszenie.Zdjecie);
                updateCommand.ExecuteReader();
            }
        }

        public static List<Ogloszenie> CzytajOgloszenia(int kategoriaId, int firmaId)
        {
            List<Ogloszenie> ogloszenia = new List<Ogloszenie>();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM ogloszenia o INNER JOIN kategorie k ON o.kategoria_id = k.kategoria_id WHERE k.kategoria_id = @kategoria";
                selectCommand.Parameters.AddWithValue("@kategoria", kategoriaId);
                using (SqliteDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ogloszenie = reader.GetInt32(0);
                        int kategoria = reader.GetInt32(1);
                        int firma = reader.GetInt32(2);
                        string tytul = reader.GetString(3);
                        string nazwaStanowiska = reader.GetString(4);
                        string poziomStanowiska = reader.GetString(5);
                        string rodzajPracy = reader.GetString(6);
                        string wymiarZatrudnienia = reader.GetString(7);
                        string rodzajUmowy = reader.GetString(8);
                        decimal? najmniejszeWynagrodzenie = reader.GetDecimal(9);
                        decimal? najwiekszeWynagrodzenie = reader.GetDecimal(10);
                        string dniPracy = reader.GetString(11);
                        string godzinyPracy = reader.GetString(12);
                        DateTime dataWaznosci = reader.GetDateTime(13);
                        string obowiazki = reader.GetString(14);
                        string wymagania = reader.GetString(15);
                        string benefity = reader.GetString(16);
                        string informacje = reader.GetString(17);
                        DateTime dataUtworzenia = reader.GetDateTime(18);  
                        string zdjecie = reader.GetString(19);

                        Ogloszenie ogl = new Ogloszenie(ogloszenie, kategoria, firma, tytul, nazwaStanowiska, poziomStanowiska, rodzajPracy, wymiarZatrudnienia, rodzajUmowy, najmniejszeWynagrodzenie, najwiekszeWynagrodzenie,
                            dniPracy, godzinyPracy, dataWaznosci, obowiazki, wymagania, benefity, informacje, dataUtworzenia, zdjecie);

                        ogloszenia.Add(ogl);
                    }
                }
            }

            return ogloszenia;
        }

        public static List<Ogloszenie> CzytajWszystkieOgloszenia()
        {
            List<Ogloszenie> ogloszenia = new List<Ogloszenie>();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM ogloszenia ORDER BY data_utworzenia DESC ";
                using (SqliteDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ogloszenie = reader.GetInt32(0);
                        int kategoria = reader.GetInt32(1);
                        int firmaId = reader.GetInt32(2);
                        string tytul = reader.GetString(3);
                        string nazwaStanowiska = reader.GetString(4);
                        string poziomStanowiska = reader.GetString(5);
                        string rodzajPracy = reader.GetString(6);
                        string wymiarZatrudnienia = reader.GetString(7);
                        string rodzajUmowy = reader.GetString(8);
                        decimal? najmniejszeWynagrodzenie = reader.GetDecimal(9);
                        decimal? najwiekszeWynagrodzenie = reader.GetDecimal(10);
                        string dniPracy = reader.GetString(11);
                        string godzinyPracy = reader.GetString(12);
                        DateTime dataWaznosci = reader.GetDateTime(13);
                        string obowiazki = reader.GetString(14);
                        string wymagania = reader.GetString(15);
                        string benefity = reader.GetString(16);
                        string informacje = reader.GetString(17);
                        DateTime dataUtworzenia = reader.GetDateTime(18);
                        string zdjecie = reader.GetString(19);

                        Ogloszenie ogl = new Ogloszenie(ogloszenie, kategoria, firmaId, tytul, nazwaStanowiska, poziomStanowiska, rodzajPracy, wymiarZatrudnienia, rodzajUmowy, najmniejszeWynagrodzenie, najwiekszeWynagrodzenie,
                            dniPracy, godzinyPracy, dataWaznosci, obowiazki, wymagania, benefity, informacje, dataUtworzenia, zdjecie);

                        ogloszenia.Add(ogl);
                    }
                }
            }

            return ogloszenia;
        }

        public static void UsunOgloszenie(Ogloszenie ogloszenie)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM ogloszenia WHERE ogloszenie_id = @Id;";
                deleteCommand.Parameters.AddWithValue("@Id", ogloszenie.OgloszenieId);
                deleteCommand.ExecuteReader();
            }
        }


        public static void UsunKategorie(Kategoria kategoria)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                // Usuń powiązane rekordy w tabeli "produkty" dla danej kategorii
                var deleteProduktyCommand = new SqliteCommand();
                deleteProduktyCommand.Connection = db;
                deleteProduktyCommand.CommandText = "DELETE FROM ogloszenia WHERE kategoria_id = @ID;";
                deleteProduktyCommand.Parameters.AddWithValue("@ID", kategoria.KategoriaId);
                deleteProduktyCommand.ExecuteReader();

                // Usuń kategorię
                var deleteKategoriaCommand = new SqliteCommand();
                deleteKategoriaCommand.Connection = db;
                deleteKategoriaCommand.CommandText = "DELETE FROM kategorie WHERE kategoria_id = @ID;";
                deleteKategoriaCommand.Parameters.AddWithValue("@ID", kategoria.KategoriaId);
                deleteKategoriaCommand.ExecuteReader();
            }
        }

        public static void UtworzKategorie(Kategoria kategoria)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");


            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCategoryCommand = new SqliteCommand();
                insertCategoryCommand.Connection = db;
                insertCategoryCommand.CommandText = "INSERT INTO kategorie VALUES(NULL, @Nazwa);";
                insertCategoryCommand.Parameters.AddWithValue("@Nazwa", kategoria.KategoriaNazwa);
                insertCategoryCommand.ExecuteReader();
            }
        }


        public static void EdycjaKategorii(Kategoria kategoria)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                updateCommand.CommandText = "UPDATE kategorie SET Nazwa=@Nazwa WHERE kategoria_id = @ID;";
                updateCommand.Parameters.AddWithValue("@ID", kategoria.KategoriaId);
                updateCommand.Parameters.AddWithValue("@Nazwa", kategoria.KategoriaNazwa);
                updateCommand.ExecuteNonQuery();
            }
        }


        public static List<Kategoria> CzytajKategorie()
        {
            List<Kategoria> kategorie = new List<Kategoria>();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM kategorie;";

                using (SqliteDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nazwa = reader.GetString(1);

                        Kategoria kat = new Kategoria(id, nazwa);
                        kategorie.Add(kat);
                    }
                }
            }

            return kategorie;
        }

        public static List<Firma> CzytajFirmy()
        {
            List<Firma> firmy = new List<Firma>();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM firmy;";

                using (SqliteDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nazwa = reader.GetString(1);

                        Firma fir = new Firma(id, nazwa);
                        firmy.Add(fir);
                    }
                }
            }

            return firmy;
        }

        public static void UsunFirme(Firma firma)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();

                var deleteProduktyCommand = new SqliteCommand();
                deleteProduktyCommand.Connection = db;
                deleteProduktyCommand.CommandText = "DELETE FROM ogloszenia WHERE firma_id = @ID;";
                deleteProduktyCommand.Parameters.AddWithValue("@ID", firma.FirmaId);
                deleteProduktyCommand.ExecuteReader();

                var deleteKategoriaCommand = new SqliteCommand();
                deleteKategoriaCommand.Connection = db;
                deleteKategoriaCommand.CommandText = "DELETE FROM firmy WHERE firma_id = @ID;";
                deleteKategoriaCommand.Parameters.AddWithValue("@ID", firma.FirmaId);
                deleteKategoriaCommand.ExecuteReader();
            }
        }

        public static void UtworzFirme(Firma firma)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");


            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCategoryCommand = new SqliteCommand();
                insertCategoryCommand.Connection = db;
                insertCategoryCommand.CommandText = "INSERT INTO firmy VALUES(NULL, @Nazwa);";
                insertCategoryCommand.Parameters.AddWithValue("@Nazwa", firma.FirmaNazwa);
                insertCategoryCommand.ExecuteReader();
            }
        }


        public static void EdycjaFirmy(Firma firma)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "systemOgloszeniowy.db");

            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                updateCommand.CommandText = "UPDATE firmy SET Nazwa=@Nazwa WHERE firma_id = @ID;";
                updateCommand.Parameters.AddWithValue("@ID", firma.FirmaId);
                updateCommand.Parameters.AddWithValue("@Nazwa", firma.FirmaNazwa);
                updateCommand.ExecuteNonQuery();
            }
        }

    }    
}
