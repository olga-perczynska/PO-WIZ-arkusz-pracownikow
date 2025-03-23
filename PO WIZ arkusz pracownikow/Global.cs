using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_WIZ_arkusz_pracownikow
{
    public class Global
    {
        private static int nextId = 1;

        public int Id { get; set; }
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";
        public string Etat { get; set; } = "";
        public int Wiek { get; set; } = 0;

        public Global()
        {
            Id = nextId++; 
        }
    }

    public static class StaticData
    {
        public static List<Global> ListaOsob = new List<Global>();
    }

}
