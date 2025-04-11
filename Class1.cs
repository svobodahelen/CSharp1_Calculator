using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukol9_class
{
    public class Kalkulacka
    {
        private double Vysledek;
        private int VysledekInt;

        public Kalkulacka()
        {
            Vysledek = 0;
        }

        public static bool JePlatnyOperator(string Operator)
        {
            bool jePlatny = ((Operator == "+") || (Operator == "-") || (Operator == "*") || (Operator == "/") || (Operator == "^"));
            return jePlatny;
        }

        public void Pricti(double nacteneCislo)
        {
            Vysledek += nacteneCislo;
        }

        public void Odecti(double nacteneCislo)
        {
            Vysledek -= nacteneCislo;
        }

        public void Vynasob(double nacteneCislo)
        {
            Vysledek *= nacteneCislo;
        }

        public void Vydel(double nacteneCislo)
        {
            Vysledek /= nacteneCislo;
        }

        public void Umocni(double nacteneCislo) 
        {
            int mocnenec = (int)Vysledek;  //zalezi, jaky je pozadavek na zaokrouhleni
            for (double i = 1; i < nacteneCislo; i++)
                Vysledek = Vysledek * mocnenec;
        }

        public double VratAktualniVysledek()
        {
            return Vysledek;
        }

    }
}

