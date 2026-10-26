using System;
using System.Collections.Generic;
using System.Text;
using KargoSistemi;

namespace KargoSistemi.Cargos
{
    public class HizliKargo : Kargo
    {
        public HizliKargo(string takipNo, string gonderici, string alici, double agirlik, double mesafe)
            : base(takipNo, gonderici, alici, agirlik, mesafe) { }

        public override double UcretHesapla()
        {
            return ((Agirlik * 15) + (Mesafe * 0.50)) * 1.5;
        }

        public override string TahminiTeslimSüresiHesapla()
        {
            int gun = (int)(Mesafe / 600) + 1; // Daha hızlı teslimat
            return $"{gun} İş Günü";
        }
    }
}
