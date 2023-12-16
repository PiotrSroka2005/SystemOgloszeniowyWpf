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
    /// Logika interakcji dla klasy ZarzadzanieAdminem.xaml
    /// </summary>
    public partial class ZarzadzanieAdminem : Window
    {

        private int admin = 0;
        private bool logged = false;
        private string usermn = "";

        public ZarzadzanieAdminem(int adm, bool log, string user)
        {
            InitializeComponent();

            usermn = user;
            admin = adm;
            logged = log;

            List<Uzytkownik> users = Baza.GetAllUsers();
            personsListBox.ItemsSource = users;
        }


        private void GiveAdmin_Btn(object sender, RoutedEventArgs e)
        {
            var selected = personsListBox.SelectedItem;
            Uzytkownik person = (Uzytkownik)selected;

            if (personsListBox.SelectedItem != null)
            {
                person.Administrator = true;
                Baza.GiveUserAdmin(person);
                List<Uzytkownik> users = Baza.GetAllUsers();
                personsListBox.ItemsSource = users;
            }
        }

        private void RemoveAdmin_Btn(object sender, RoutedEventArgs e)
        {
            var selected = personsListBox.SelectedItem;
            Uzytkownik person = (Uzytkownik)selected;

            if (personsListBox.SelectedItem != null)
            {
                person.Administrator = false;
                Baza.GiveUserAdmin(person);
                List<Uzytkownik> users = Baza.GetAllUsers();
                personsListBox.ItemsSource = users;
            }
        }

        private void PanelAdmina_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow d = new AdminWindow(admin, logged, usermn);
            d.Show();
            this.Close();
        }
    }
}
