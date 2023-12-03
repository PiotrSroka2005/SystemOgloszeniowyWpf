﻿using Microsoft.Data.Sqlite;
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
                "wymagania TEXT,benefity TEXT,informacje TEXT,data_utworzenia DATE," +
                "FOREIGN KEY(kategoria_id) REFERENCES kategorie(kategoria_id),FOREIGN KEY(firma_id) REFERENCES firmy(firma_id));";
                var createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
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

        public static List<Ogloszenie> CzytajOgloszenia(int kategoriaId)
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
                        int id = reader.GetInt32(0);
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

                        Ogloszenie ogl = new Ogloszenie(id, kategoria, firma, tytul, nazwaStanowiska, poziomStanowiska, rodzajPracy, wymiarZatrudnienia, rodzajUmowy, najmniejszeWynagrodzenie, najwiekszeWynagrodzenie,
                            dniPracy, godzinyPracy, dataWaznosci, obowiazki, wymagania, benefity, informacje, dataUtworzenia);

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
                selectCommand.CommandText = "SELECT * FROM ogloszenia ORDER BY data_utworzenia ";
                using (SqliteDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
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

                        Ogloszenie ogl = new Ogloszenie(id, kategoria, firma, tytul, nazwaStanowiska, poziomStanowiska, rodzajPracy, wymiarZatrudnienia, rodzajUmowy, najmniejszeWynagrodzenie, najwiekszeWynagrodzenie,
                            dniPracy, godzinyPracy, dataWaznosci, obowiazki, wymagania, benefity, informacje, dataUtworzenia);

                        ogloszenia.Add(ogl);
                    }
                }
            }

            return ogloszenia;
        }

    }    
}
