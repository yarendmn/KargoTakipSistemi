using System;
using System.Collections.Generic;
using System.Text;

namespace KargoSistemi.Interface
{
    public interface ITakipEdilebilir
    {
        void DurumGoster();
        void KonumGuncelle(string yeniKonum);
    }
}
