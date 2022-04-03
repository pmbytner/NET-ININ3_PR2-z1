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

        string imię;
        public string Imię {
            get { return imię; }
            set
            {
                imię = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs("Imię")
                    );
            }
        }

        internal void Klik()
        {
            Imię = "Nemo";
        }
    }
}
