/*  třída Kalkulacka neobsahuje příkazy Console
 *  
 - Vytvoř nový soubor Kalkulacka.cs, do které přesuň svou třídu Kalkulacka z minulého týdne.

- Doplň veškeré funkce parsování, výpisů do konzole, načítání z konzole, kontroly správného zadání, opakovací logiku a uživatelské ukončování programu (z Kalkulačky v5), 
ale nech je v souboru Program.cs. Třída Kalkulacka má opravdu držet jen matematické operace, poslední výsledek a to je vše

- Načítání desetinného čísla a operátoru ale nenechávej přímo v Main. Vytvoř si pro ně statické metody (public static …) 
v souboru Program.cs v již existující třídě internal class Program.

- - Metody by se mohly jmenovat např. takto:
NactiDesetinneCisloZKonzole(), která bude vracet double
NactiOperatorZKonzole(), která bude vracet string
Následně budeš tyto metody volat v Main, který se ti tak výrazně zpřehlední 
 */

using System;
using Ukol9_class;

namespace Ukol9
{
    internal class Program
    {
        private static object operace;

        public static void Exit()
        {
            Console.WriteLine("Kalkulacka konci.");
            Environment.Exit(0);
        }

        public static double NactiDesetinneCisloZKonzole()
        {
            Console.WriteLine("Zadej desetinne cislo: ");
            string vstup = Console.ReadLine();
            double DesetinneCislo = 0;

            if (vstup == "x")
            {
                Exit();
                return DesetinneCislo; //jde to i bez return
            }

            else
            {
                while (!double.TryParse(vstup, out DesetinneCislo))
                {
                    Console.WriteLine("Nezadal jsi platne desetinne cislo, zkus to znovu: ");
                    vstup = Console.ReadLine();
                    if (vstup == "x")
                    {
                        Exit();
                        return DesetinneCislo; //jde to i bez return
                    }
                }
                return DesetinneCislo;
            }

        }


        public static string NactiOperatorZKonzole()
        {
            Console.Write("Zadejte jeden z operatoru pro scitani (+), odcitani (-), nasobeni (*), deleni (/), mocneni (^) = Alt+94, pro ukonceni (x):  ");
            string znakOperatoru = Console.ReadLine();

            if (znakOperatoru == "x")
            {
                Exit();
                return znakOperatoru; //jde to i bez return
            }

            else
            {
                while (!Kalkulacka.JePlatnyOperator(znakOperatoru))
                {
                    Console.WriteLine("Nezadali jste platny operator, zkuste to znovu, na vyber: scitani (+), odcitani (-), nasobeni (*), deleni (/), mocneni (^) = Alt+94, pro ukonceni (x): ");
                    znakOperatoru = Console.ReadLine();

                    if (znakOperatoru == "x")
                    {
                        Exit();
                        return znakOperatoru; //jde to i bez return
                    }

                }
                return znakOperatoru;
            }
        }

        static void Main(string[] args)
        {
            Kalkulacka kalkulacka = new Kalkulacka();
            double vypisZMainu = kalkulacka.VratAktualniVysledek();
            Console.WriteLine($"Zaciname od: {vypisZMainu}. Kalkulacku muzete ukoncit znakem 'x'.");

            double nacteneCislo = NactiDesetinneCisloZKonzole();
            Console.WriteLine($"Zadane cislo: {nacteneCislo}");

            kalkulacka.Pricti(nacteneCislo);

            while (true)
            {
                string operace = NactiOperatorZKonzole();
                Console.WriteLine($"Zadany operator: {operace}");

                
                    nacteneCislo = NactiDesetinneCisloZKonzole();
                    Console.WriteLine($"Zadane cislo: {nacteneCislo}");
                

                switch (operace)
                {
                    case "+":
                        kalkulacka.Pricti(nacteneCislo);
                        break;

                    case "-":
                        kalkulacka.Odecti(nacteneCislo);
                        break;
                    case "*":
                        kalkulacka.Vynasob(nacteneCislo);
                        break;
                    case "/":
                        kalkulacka.Vydel(nacteneCislo);
                        break;
                    case "^":
                        kalkulacka.Umocni((int)nacteneCislo);
                        break;

                }
                vypisZMainu = kalkulacka.VratAktualniVysledek();
                Console.WriteLine("Vysledek: " + vypisZMainu);

            }

        }
    }


}

