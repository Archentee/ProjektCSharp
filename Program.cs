using ProjektC_;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SpravaPojisteny sprava_pojisteny = new SpravaPojisteny();

        Console.WriteLine("==========================");
        Console.WriteLine("   Evidence Pojištěných ");
        Console.WriteLine("==========================");

        while (true)
        {
            Console.WriteLine("\n1 - Přidat pojištěného");
            Console.WriteLine("2 - Zobrazit všechny pojištěné");
            Console.WriteLine("3 - Hledat pojištěného");
            Console.WriteLine("4 - Konec");

            List<int> validChoices = new List<int> { 1, 2, 3, 4 };

            int volba;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out volba) && validChoices.Contains(volba))
                    break;
                Console.WriteLine("\nNeplatná volba. Zadejte prosím číslo 1, 2, 3 nebo 4.\n");
            }

            if (volba == 1)
            {
                string jmeno, prijmeni;
                int vek;
                string telefon;

                while (true)
                {
                    Console.Write("Zadejte jméno: ");
                    jmeno = Console.ReadLine();
                    Console.Write("Zadejte příjmení: ");
                    prijmeni = Console.ReadLine();

                    if (!string.IsNullOrEmpty(jmeno) && !string.IsNullOrEmpty(prijmeni))
                        break;
                    else
                        Console.WriteLine("\nJméno a příjmení nesmí být prázdné.\n");
                }

                while (true)
                {
                    Console.Write("Zadejte věk: ");
                    if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
                        break;
                    else
                        Console.WriteLine("Neplatný formát věku. Zadejte prosím správný formát.");
                }

                Console.Write("Zadejte telefonní číslo: ");
                telefon = Console.ReadLine();
                Pojisteny osoba = new Pojisteny(jmeno, prijmeni, vek, telefon);
                sprava_pojisteny.PridatPojisteneho(osoba);
                Console.WriteLine("\nData byla uložena.\n");
            }
            else if (volba == 2)
            {
                List<Pojisteny> vsechnyOsoby = sprava_pojisteny.VratVsechnyPojistene();
                foreach (Pojisteny osoba in vsechnyOsoby)
                {
                    Console.WriteLine(osoba); // Vytiskne informace o každé osobě
                }
            }
            else if (volba == 3)
            {
                Console.Write("Zadejte jméno: ");
                string hledaneJmeno = Console.ReadLine();
                Console.Write("Zadejte příjmení: ");
                string hledanePrijmeni = Console.ReadLine();
                List<string> nalezenaOsoba = sprava_pojisteny.NajitPojisteneho(hledaneJmeno, hledanePrijmeni);
                if (nalezenaOsoba.Count > 0)
                {
                    Console.WriteLine("\nNalezeno:");
                    foreach (string osoba in nalezenaOsoba)
                    {
                        Console.WriteLine(osoba); // Samostatný řádek
                    }
                }
                else
                {
                    Console.WriteLine("\nOsoba nenalezena (Zkontrolujte velká, malá písmena a mezery).\n");
                }
            }
            else if (volba == 4)
            {
                Console.WriteLine("Ukončuji...");
                break;
            }
            else
            {
                Console.WriteLine("\nNeplatná volba. Prosím vyberte znovu.\n");
            }
        }
    }
}
