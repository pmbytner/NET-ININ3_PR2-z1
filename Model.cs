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
        readonly static Dictionary<string,string[]> powiązaneWłaściwości = new Dictionary<string, string[]>()
        {

        }
        public void OnPropertyChanged([CallerMemberName] string nazwa = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nazwa));
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
