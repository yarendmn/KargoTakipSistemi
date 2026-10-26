using KargoSistemi.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using KargoSistemi;

namespace KargoSistemi
{
    class Program
    {
        static List<Kargo> kargolar = new List<Kargo>();

        static void Main(string[] args)
        {
            bool calisiyor = true;

            while (calisiyor)
            {
                Console.WriteLine("\n=== Kargo Takip ve Ücret Hesaplama Sistemi ===");
                Console.WriteLine("1- Kargo Ekle");
                Console.WriteLine("2- Kargoları Listele");
                Console.WriteLine("3- Takip Numarasıyla Kargo Ara");
                Console.WriteLine("4- Kargo Durumunu Güncelle");
                Console.WriteLine("5- Toplam Geliri Göster");
                Console.WriteLine("6- Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();
                Console.WriteLine("------------------------------------------------");

                switch (secim)
                {
                    case "1":
                        KargoEkle();
                        break;
                    case "2":
                        KargolariListele();
                        break;
                    case "3":
                        KargoAra();
                        break;
                    case "4":
                        DurumGuncelle();
                        break;
                    case "5":
                        ToplamGelirGoster();
                        break;
                    case "6":
                        calisiyor = false;
                        Console.WriteLine("Sistemden çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        
        }

        static void KargoEkle()
        {
            Console.Write("Takip No: ");
            string takipNo = Console.ReadLine();

            Console.Write("Gönderici: ");
            string gonderici = Console.ReadLine();

            Console.Write("Alıcı: ");
            string alici = Console.ReadLine();

            Console.Write("Ağırlık (kg): ");
            double agirlik = Convert.ToDouble(Console.ReadLine());

            Console.Write("Mesafe (km): ");
            double mesafe = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nKargo Türü Seçin:");
            Console.WriteLine("1- Standart Kargo");
            Console.WriteLine("2- Hızlı Kargo");
            Console.WriteLine("3- Uluslararası Kargo");
            Console.Write("Seçiminiz: ");
            string turSecim = Console.ReadLine();

            Kargo yeniKargo = null;

            switch (turSecim)
            {
                case "1":
                    yeniKargo = new StandartKargo(takipNo, gonderici, alici, agirlik, mesafe);
                    break;
                case "2":
                    yeniKargo = new HizliKargo(takipNo, gonderici, alici, agirlik, mesafe);
                    break;
                case "3":
                    yeniKargo = new UluslararasiKargo(takipNo, gonderici, alici, agirlik, mesafe);
                    break;
                default:
                    Console.WriteLine("Geçersiz tür seçimi! Kargo eklenemedi.");
                    return;
            }

            kargolar.Add(yeniKargo);
            Console.WriteLine("\nKargo başarıyla eklendi!");
            Console.WriteLine($"Hesaplanan Ücret: {yeniKargo.UcretHesapla():C2}");
            Console.WriteLine($"Tahmini Teslimat: {yeniKargo.TahminiTeslimSüresiHesapla()}");
        }

        static void KargolariListele()
        {
            if (kargolar.Count == 0)
            {
                Console.WriteLine("Sistemde kayıtlı kargo bulunmamaktadır.");
                return;
            }

            foreach (var kargo in kargolar)
            {
                kargo.DurumGoster();
                Console.WriteLine($"Ücret: {kargo.UcretHesapla():C2} | Teslimat: {kargo.TahminiTeslimSüresiHesapla()}");
                Console.WriteLine("-");
            }
        }

        static void KargoAra()
        {
            Console.Write("Aranacak Takip No: ");
            string arananNo = Console.ReadLine();

            var kargo = kargolar.FirstOrDefault(k => k.TakipNo == arananNo);

            if (kargo != null)
            {
                Console.WriteLine("\nKargo Bulundu:");
                kargo.DurumGoster();
                Console.WriteLine($"Tür: {kargo.GetType().Name}");
                Console.WriteLine($"Ağırlık: {kargo.Agirlik} kg | Mesafe: {kargo.Mesafe} km");
                Console.WriteLine($"Ücret: {kargo.UcretHesapla():C2} | Tahmini Teslimat: {kargo.TahminiTeslimSüresiHesapla()}");
            }
            else
            {
                Console.WriteLine("Bu takip numarasına ait kargo bulunamadı.");
            }
        }

        static void DurumGuncelle()
        {
            Console.Write("Durumu güncellenecek Takip No: ");
            string no = Console.ReadLine();

            var kargo = kargolar.FirstOrDefault(k => k.TakipNo == no);

            if (kargo != null)
            {
                Console.Write("Yeni Konum/Durum bilgisini girin: ");
                string yeniDurum = Console.ReadLine();
                kargo.KonumGuncelle(yeniDurum);
            }
            else
            {
                Console.WriteLine("Kargo bulunamadı.");
            }
        }

        static void ToplamGelirGoster()
        {
            double toplamGelir = 0;
            foreach (var kargo in kargolar)
            {
                toplamGelir += kargo.UcretHesapla(); // Polymorphism sayesinde her kargo kendi ücretini hesaplar
            }

            Console.WriteLine($"Sistemdeki tüm kargolardan beklenen toplam gelir: {toplamGelir:C2}");
        }
    }
}


