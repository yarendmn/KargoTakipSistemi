using KargoSistemi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KargoSistemi
{
    public abstract class Kargo : ITakipEdilebilir
    {
        public string TakipNo { get; set; }
        public string Gonderici { get; set; }
        public string Alici { get; set; }
        public double Agirlik { get; set; }
        public double Mesafe { get; set; }
        public string MevcutKonum { get; protected set; }

        public Kargo(string takipNo, string gonderici, string alici, double agirlik, double mesafe)
        {
            TakipNo = takipNo;
            Gonderici = gonderici;
            Alici = alici;
            Agirlik = agirlik;
            Mesafe = mesafe;
            MevcutKonum = "Hazırlanıyor (Çıkış Şubesi)";
        }

        public abstract double UcretHesapla();
        public abstract string TahminiTeslimSüresiHesapla();

        public virtual void DurumGoster()
        {
            Console.WriteLine($"Takip No: {TakipNo} | Gönderici: {Gonderici} -> Alıcı: {Alici}");

        }

        public virtual void KonumGuncelle(string yeniKonum)
        {
            MevcutKonum = yeniKonum;
            Console.WriteLine($"{TakipNo} numaralı kargonun konumu güncellendi: {MevcutKonum}");
        }

    }
}
