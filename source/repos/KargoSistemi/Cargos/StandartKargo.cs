using System;
using System.Collections.Generic;
using System.Text;
using KargoSistemi;


namespace KargoSistemi.Cargos
{
    public class StandartKargo : Kargo
    {
        public StandartKargo(string takipNo, string gonderici, string alici, double agirlik, double mesafe)
            : base(takipNo, gonderici, alici, agirlik, mesafe) { }

        public override double UcretHesapla()
        {
            return (Agirlik * 15) + (Mesafe * 0.50);
        }

        public override string TahminiTeslimSüresiHesapla()
        {
            int gun = (int)(Mesafe / 300) + 1;
            return $"{gun} - {gun + 2} İş Günü";
        }
    }
}
