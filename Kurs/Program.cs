using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> KisiListesi = new List<Kisi>
            {
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null},
                new Kisi{ KisiId= new Guid("guid"), Isim="name",HediyeAlınacakKisi=null}
            };

            Random random = new();

            for (int i = 0; i < KisiListesi.Count; i++)
            {
                var hediyeAlınabilecekKisiListesi = KisiListesi.Where(k => k.KisiId != KisiListesi[i].KisiId && !KisiListesi.Select(x => x.HediyeAlınacakKisi).Contains(k)).ToList();
                KisiListesi[i].HediyeAlınacakKisi = hediyeAlınabilecekKisiListesi[random.Next(0, hediyeAlınabilecekKisiListesi.Count)];
            }


            foreach (var item in KisiListesi)
            {
                string result = item.KisiId.ToString() + "," + item.Isim + "," + item.HediyeAlınacakKisi.Isim;
                File.WriteAllLines(("Path_to_file" + item.KisiId.ToString() + ".txt"), new string[] { result });
            }
            Console.WriteLine("Tamamlandı");
            Console.ReadKey();
        }
    }

    class Kisi
    {
        public Kisi()
        {

        }
        public Guid KisiId { get; set; }
        public string Isim { get; set; }
        public Kisi HediyeAlınacakKisi { get; set; }
    }
}


