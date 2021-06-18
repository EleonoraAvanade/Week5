using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.Entities
{
    class Esame
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int CFU { get; set; }
        public string Datas { get; set; }
        public Studente st { get; set; }
        public int Votazione { get; set; }
        public bool Passato { get; set; }
    }
}
