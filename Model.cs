using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ3_PR2_z1
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly static Dictionary<string, string[]> powiązaneWłaściwości = new Dictionary<string, string[]>()
        {
            ["Imię"] = new string[] { "Format" }
        };
        public void OnPropertyChanged([CallerMemberName] string własnaNazwa = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(własnaNazwa));
            foreach(string nazwaPowiązana in powiązaneWłaściwości[własnaNazwa])
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nazwaPowiązana));
        }

        string imię = "Nemo";
        public string Imię {
            get { return imię; }
            set
            {
                imię = value;
                OnPropertyChanged();
                //OnPropertyChanged("Format");
            }
        }
        public string Format
        {
            get { return $"Podane imię to {Imię}."; }
        }
    }
}
