using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _CorePersonelTakibi.Models
{
    public static class PersonelRepository
    {
        private static List<Kisi> _Kisis;
        static PersonelRepository()
        {
            _Kisis = new List<Kisi>();
        }
        public static List<Kisi> Kisis
        {
            get
            {
                return _Kisis;
            }
        } 
        public static void Add(Kisi kisi)
        {
            kisi.KisiId = _Kisis.Count + 1;
            _Kisis.Add(kisi);
        }
        public static void Delete(Kisi kisi)
        {
            _Kisis.Remove(kisi);
        }
        public static Kisi GetByKisiId(int id)
        {
            return _Kisis.FirstOrDefault(x => x.KisiId == id);
        }

     



    }
}
