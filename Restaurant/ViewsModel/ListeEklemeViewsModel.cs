using Restaurant.Data;

namespace Restaurant.ViewsModel
{
    public class ListeEklemeViewsModel
    {

        public IEnumerable<Menu>? Menuler { get; set; }

        public IEnumerable<Urun>? Urunler { get; set; }

        public IEnumerable <Personel>? Personeller { get; set; }
    }
}
