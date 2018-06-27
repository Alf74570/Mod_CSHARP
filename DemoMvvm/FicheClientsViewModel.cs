using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoMvvm
{
    public class FicheClientsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private ObservableCollection<Client> fiches;

        public ObservableCollection<Client> Fiches
        {
            get
            {
                return fiches;
            }
            set
            {
                if (value != fiches)
                {
                    fiches = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Client ficheSelectionnee;

        public Client FicheSelectionnee
        {
            get
            {
                return ficheSelectionnee;
            }
            set
            {
                if (value != ficheSelectionnee)
                {
                    ficheSelectionnee = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public FicheClientsViewModel()
        {
            fiches = new ObservableCollection<Client>();

            FicheSelectionnee = new Client()
            {
                Nom = "Dupont",
                Prenom = "Pierre",
                Age = 32,
                Sexe = "M"
            };
            Fiches.Add(FicheSelectionnee);
        }

        private ICommand remiseAZeroDeLaFicheSelectionnee = new RelayCommand<Client>((client) =>
        {
            client.Age = 0;
            client.Nom = "";
            client.Prenom = "";
            client.Sexe = "";
        });
        
        public ICommand RemiseAZeroDeLaFicheSelectionnee
        {
            get
            {
                return remiseAZeroDeLaFicheSelectionnee;
            }
        }

        private ICommand ajoutDUneFicheClient;
        public ICommand AjoutDUneFicheClient
        {
            get
            {
                if (ajoutDUneFicheClient == null)
                {
                    ajoutDUneFicheClient = new RelayCommand<object>((obj) => Fiches.Add(new Client()));
                }
                return ajoutDUneFicheClient;
            }
        }

        private ICommand retraitDUneFicheClient;
        public ICommand RetraitDUneFicheClient
        {
            get
            {
                if (retraitDUneFicheClient == null)
                {
                    retraitDUneFicheClient = new RelayCommand<Client>((client) => Fiches.Remove(client));
                }
                return retraitDUneFicheClient;
            }
        }

        private ICommand editionDUneFicheClient;
        public ICommand EditionDUneFicheClient
        {
            get
            {
                if (editionDUneFicheClient == null)
                {
                    editionDUneFicheClient = new RelayCommand<Client>((client) => FicheSelectionnee = client);
                }
                return editionDUneFicheClient;
            }
        }
    }
}
