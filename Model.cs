using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ3_PR2_z1
{
    class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly static Dictionary<string, string[]> powiązaneWłaściwości = new Dictionary<string, string[]>()
        {
            ["Imię"] = new string[] { "ImięNazwisko" },
            ["Nazwisko"] = new string[] {"ImięNazwisko"}
        };
        public void OnPropertyChanged([CallerMemberName] string własnaNazwa = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(własnaNazwa));
            foreach (string nazwaPowiązana in powiązaneWłaściwości[własnaNazwa])
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaPowiązana));
        }
        public static uint następneID = 0;

        public uint ID { get; } = następneID++;
        string
            imię,
            nazwisko
            ;
        public string ImięNazwisko
        {
            get { return $"{Imię} {Nazwisko}"; }
        }

        public string Imię {
            get => imię;
            set {
                imię = value;
                OnPropertyChanged();
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                OnPropertyChanged();
            }
        }
    }
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly static Dictionary<string, string[]> powiązaneWłaściwości = new Dictionary<string, string[]>()
        {
            ["Imię"] = new string[] { "Format" }
        };
        public void OnPropertyChanged([CallerMemberName] string własnaNazwa = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(własnaNazwa));
            foreach (string nazwaPowiązana in powiązaneWłaściwości[własnaNazwa])
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaPowiązana));
        }

        public string[] Tab { get; set; } = new string[]
        {
            "a",
            "b",
            "c"
        };
        public LinkedList<Osoba> ListaOsób { get; set; } = new LinkedList<Osoba>(new Osoba[]{
            new Osoba(){Imię="Jan", Nazwisko="Sosnowski"},
            new Osoba(){Imię="Adam",Nazwisko="Dąbrowski"},
            new Osoba(){Imię="Anna",Nazwisko="Wiśniewska"},
            new Osoba(){Imię="Julia",Nazwisko="Jabłońska"}
        });
    }
}
