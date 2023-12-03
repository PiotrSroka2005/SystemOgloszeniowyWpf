﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemOgloszeniowyWpf.Klasy;
using SystemOgloszeniowyWpf.Okna;

namespace SystemOgloszeniowyWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";


        public MainWindow()
        {
            InitializeComponent();

            Baza.TabelaUzytkownikow();
            Baza.TabelaOgloszenia();

            uzytkownik.Visibility = Visibility.Collapsed;
            PanelAdm.Visibility = Visibility.Collapsed;
            Wyl.Visibility = Visibility.Collapsed;

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            // Wczytaj ogłoszenia
            viewModel.Ogloszenia = Baza.CzytajWszystkieOgloszenia();
        }

        public MainWindow(int adm, bool log, string user)
        {
            InitializeComponent();

            PanelAdm.Visibility = Visibility.Collapsed;
            usermn = user;
            admin = adm;
            logged = log;

            if (logged == false)
            {
                Wyl.Visibility = Visibility.Collapsed;
                uzytkownik.Visibility = Visibility.Collapsed;                
            }
            else
            {
                uzytkownik.Header = user;
                Zal.Visibility = Visibility.Collapsed;
                if (admin == 1)
                {
                    PanelAdm.Visibility = Visibility.Visible;
                }
                else
                {
                    PanelAdm.Visibility = Visibility.Collapsed;
                }
            }

            Baza.TabelaUzytkownikow();
            Baza.TabelaOgloszenia();

            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;

            // Wczytaj ogłoszenia
            viewModel.Ogloszenia = Baza.CzytajWszystkieOgloszenia();
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow p = new ProfilWindow(admin, logged, usermn);
            p.Show();
            this.Close();
        }

        private void ZalogujSie_Click(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            this.Close();
        }

        private void WylogujSie_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
