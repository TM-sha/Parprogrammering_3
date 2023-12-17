using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parprogrammering_3
{
    internal class Bil
    {
        private string _merker;
        public int _årsmodell;
        private string _registreringsNummer;
        public int Kilometerstand;
        private double _pris;

        public Bil(string type, int årsmodell, string regnr, int kilometerstand, double pris)
        {
            _merker = type;
            _årsmodell = årsmodell;
            _registreringsNummer = regnr;
            Kilometerstand = kilometerstand;
            _pris = pris;
        }

        public void GetCarInfo()
        {
            Console.WriteLine($"Bilmerker: {_merker}\n" +
                              $"Årsmodell: {_årsmodell}\n" +
                              $"Registreringsnummer: {_registreringsNummer}\n" +
                              $"Kilometerstand: {Kilometerstand}\n" +
                              $"Pris: {_pris}\n");
        }
    }
}
