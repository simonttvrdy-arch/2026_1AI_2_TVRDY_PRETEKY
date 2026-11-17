using System;
using System.Collections.Generic;
using System.Text;

namespace _2026_1AI_2_TVRDY_PRETEKY
{
    public class Auto
    {
        public double Rychlost {  get; set; }
        public double VelkosNadrze { get; set; }
        public double Spotreba { get; set; }
        public int IdAuta {  get; set; }
        public double StavPaliva { get; set; }

        public Auto(double rychlost, double velkosNadrze, double spotreba, int idAuta)
        {
            Rychlost = rychlost;
            VelkosNadrze = velkosNadrze;
            Spotreba = spotreba;
            IdAuta = idAuta;
            StavPaliva = velkosNadrze;
        }
        public void Nacapuj()
        {
            // naplnim nadrz na zaciatku pretekov
            StavPaliva = VelkosNadrze;
        }

        public string ToString()
        {
            string vypis = "Auto " + IdAuta + ", rýchlosť: " + Rychlost + " km/h, velkosť nádrže: " + VelkosNadrze + " litrov, spotreba: " + Spotreba + " l/100km";
            return vypis;
        }
    }
}
