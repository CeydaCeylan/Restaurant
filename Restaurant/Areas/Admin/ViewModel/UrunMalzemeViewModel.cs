using Restaurant.Data;
using System.Collections;

namespace Restaurant.Areas.Admin.ViewModel
{
    public class UrunMalzemeViewModel
    {
        public UrunMalzeme? UrunMalzeme { get; set; }

        public IEnumerable<Urun>? Urunler { get; set; }

        public IEnumerable<Malzeme>? Malzemeler { get; set; }

    }
}
