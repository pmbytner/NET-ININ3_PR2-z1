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

        double
            liczbaA,
            liczbaB
            ;
        string buforDziałania = null;
        bool
            flagaUłamka = false,
            flagaDziałania = false
            ;
        string buforIO = "0";
        public string IO
        {
            get { return buforIO; }
            set
            {
                buforIO = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IO"));
            }
        }
        
        internal void DziałanieZwykłe(string znak)
        {
            if(buforDziałania == null)
            {
                buforDziałania = znak;
                liczbaA = double.Parse(buforIO);
                flagaDziałania = true;
            }
            else
            {
                liczbaB = double.Parse(buforIO);
                liczbaA = WykonajDziałanie(buforDziałania, liczbaA, liczbaB);
                flagaDziałania = true;
                buforDziałania = znak;
            }
        }
        private double WykonajDziałanie(string buforDziałania, double liczbaA, double liczbaB)
        {
            throw new NotImplementedException();
        }

        internal void Resetuj()
        {
            Zeruj();
        }
        internal void Zeruj() {
            flagaUłamka = false;
            flagaDziałania = false;
            IO = "0";
        }
        internal void Cofnij()
        {
            if (buforIO == "0")
                return;
            else if (
                buforIO == "0,"
                ||
                buforIO == "-0,"
                ||
                (buforIO[0] == '-' && buforIO.Length == 2)
                )
                Zeruj();
            else
            {
                char usuwanyZnak = buforIO[buforIO.Length-1];
                IO = buforIO.Substring(0, buforIO.Length - 1);
                if(usuwanyZnak == ',')
                    flagaUłamka = false;
            }
        }
        internal void DopiszCyfrę(string cyfra)
        {
            if (flagaDziałania)
                Zeruj();
            if (buforIO == "0")
                buforIO = "";
            IO += cyfra;
        }
        internal void ZmieńZnak()
        {
            flagaDziałania = false;
            if (buforIO == "0")
                return;
            else if (buforIO[0] == '-')
                IO = buforIO.Substring(1);
            else
                IO = '-' + IO;
        }
        internal void PostawPrzecinek()
        {
            if (flagaDziałania)
                Zeruj();
            if (flagaUłamka || buforIO[buforIO.Length - 1] == ',')
                return;
            else
            {
                IO += ',';
                flagaUłamka = true;
            }
        }
    }
}
