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
        readonly Dictionary<string, (string L, string P)> działaniaJednoargumentowe
            = new Dictionary<string, (string L, string P)>()
            {
                ["x²"] = ("", "²")
            };
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
        public string Bufory
        {
            get
            {
                if (buforDziałania == null)
                    return "";
                if (flagaDziałania == false)
                    return $"{LiczbaA} {BuforDziałania}";
                if (działaniaJednoargumentowe.ContainsKey(BuforDziałania))
                    return
                        działaniaJednoargumentowe[BuforDziałania].L +
                        LiczbaA +
                        działaniaJednoargumentowe[BuforDziałania].P
                        ;
                return $"{LiczbaA} {BuforDziałania} {LiczbaB}";
            }
        }

        public double LiczbaA {
            get => liczbaA;
            set { 
                liczbaA = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bufory"));
            }
        }
        public double LiczbaB {
            get => liczbaB;
            set
            {
                liczbaB = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bufory"));
            }
        }
        public string BuforDziałania {
            get => buforDziałania;
            set
            {
                buforDziałania = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bufory"));
            }
        }

        internal void DziałanieZwykłe(string znak)
        {
            if (flagaDziałania == true)
                ;
            else if (BuforDziałania == null)
            {
                LiczbaA = double.Parse(buforIO);
                BuforDziałania = znak;
                flagaDziałania = true;
            }
            else
            {
                BuforDziałania = znak;
                LiczbaB = double.Parse(buforIO);
                flagaDziałania = true;
                LiczbaA = WykonajDziałanie();
                IO = LiczbaA.ToString();
            }
        }

        internal void Procent()
        {
            flagaDziałania = true;
            LiczbaB = double.Parse(buforIO)/100 * liczbaA;
            PodajWynik();
        }

        internal void DziałanieJednoargumentowe(string działanie)
        {
            LiczbaA = double.Parse(buforIO);
            BuforDziałania = działanie;
            flagaDziałania = true;
            IO = WykonajDziałanie().ToString();
        }

        internal void PodajWynik()
        {
            if (flagaDziałania == false) { 
                LiczbaB = double.Parse(buforIO);
                flagaDziałania = true;
            }
            IO = WykonajDziałanie().ToString();
            liczbaA = double.Parse(IO);
        }

        private double WykonajDziałanie()
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bufory"));
            double wynik;
            if (BuforDziałania == "+")
                wynik = LiczbaA + LiczbaB;
            else if (BuforDziałania == "x²")
                wynik = LiczbaA * LiczbaA;
            else
                wynik = 0;
            LiczbaA = wynik;
            return wynik;
        }

        internal void Resetuj()
        {
            Zeruj();
            BuforDziałania = default;
            LiczbaA = default;
            LiczbaB = default;
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
