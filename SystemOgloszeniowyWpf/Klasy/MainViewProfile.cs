using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOgloszeniowyWpf.Klasy
{
    public class MainViewProfile : INotifyPropertyChanged
    {
        private List<Aplikacja> _aplikacje;
        private List<Profil> _profile;

        public List<Aplikacja> Aplikacje
        {
            get { return _aplikacje; }
            set
            {
                if (_aplikacje != value)
                {
                    _aplikacje = value;
                    OnPropertyChanged(nameof(Aplikacje));
                }
            }
        }

        public List<Profil> Profile
        {
            get { return _profile; }
            set
            {
                if (_profile != value)
                {
                    _profile = value;
                    OnPropertyChanged(nameof(Profile));
                }
            }
        }

        public MainViewProfile(string usermn)
        {
            Aplikacje = Baza.PobierzAplikacjeUzytkownika(usermn);
            Profile = Baza.CzytajProfil(usermn);
        }

        // Implementacja interfejsu INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
