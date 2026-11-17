using System;
using System.Collections.Generic;
using System.Text;

namespace _2026_1AI_2_TVRDY_PRETEKY
{
    public class Preteky
    {
        public int PocetKol {  get; set; }
        public double DlzkaTrate { get; set; }
        public List<Auto> Pretekari = new List<Auto>();
        public Auto Auto1 { get; set; }
        public Auto Auto2 { get; set; }

        public Preteky()
        {
        }

        public Preteky(int pocetKol, double dlzkaTrate)
        {
            PocetKol = pocetKol;
            DlzkaTrate = dlzkaTrate;
        }

        public Preteky(int pocetKol, double dlzkaTrate, List<Auto> pretekari)
        {
            PocetKol = pocetKol;
            DlzkaTrate = dlzkaTrate;
            Pretekari = pretekari;
        }


    }
}
