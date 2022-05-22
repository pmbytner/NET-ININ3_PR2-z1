using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ3_PR2_z1
{
    class Model
    {
        public LinkedList<Osoba> ListaOsób { get; set; } = new LinkedList<Osoba>(new Osoba[]{
            new Osoba(){Imię="Jan", Nazwisko="Sosnowski"},
            new Osoba(){Imię="Adam",Nazwisko="Dąbrowski"},
            new Osoba(){Imię="Anna",Nazwisko="Wiśniewska"},
            new Osoba(){Imię="Julia",Nazwisko="Jabłońska"}
        });
    }
}
