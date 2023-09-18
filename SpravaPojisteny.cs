using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektC_
{
    public class SpravaPojisteny
    {
        private List<Pojisteny> pojisteniLide;

        public SpravaPojisteny()
        {
            pojisteniLide = new List<Pojisteny>();
        }

        public void PridatPojisteneho(Pojisteny osoba)
        {
            pojisteniLide.Add(osoba);
        }

        public List<Pojisteny> VratVsechnyPojistene()
        {
            return pojisteniLide;
        }

        public List<string> NajitPojisteneho(string jmeno, string prijmeni)
        {
            List<string> vysledekHledani = new List<string>();
            foreach (Pojisteny osoba in pojisteniLide)
            {
                if (osoba.Jmeno == jmeno && osoba.Prijmeni == prijmeni)
                {
                    vysledekHledani.Add(osoba.ToString());
                }
            }
            return vysledekHledani;
        }
    }
}
