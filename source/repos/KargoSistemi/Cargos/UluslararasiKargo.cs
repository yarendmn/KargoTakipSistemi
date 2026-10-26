using System;
using System.Collections.Generic;
using System.Text;
using KargoSistemi;

namespace KargoSistemi.Cargos
{
    public class UluslararasiKargo : Kargo
    {
        public UluslararasiKargo(string takipNo, string gonderici, string alici, double agirlik, double mesafe)
            : base(takipNo, gonderici, alici, agirlik, mesafe) { }

        public override double UcretHesapla()
        {
            // Gümrük ve uçak masrafları dahil sabit ek ücret + yüksek çarpan
            return 500 + (Agirlik * 50) + (Mesafe * 1.2);
        }

      

        public override string TahminiTeslimSüresiHesapla()
        {
            return "7 - 14 İş Günü (Gümrük süreçlerine bağlıdır)";
        }
    }
}
