using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Entities;

namespace Week5.Repos
{
    class RepoEsame:IRepoEsami
    {
        public IList<Esame> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Add()
        {
            Console.WriteLine("Immetti l'id dell'utente :  ");
            string id = Console.ReadLine();
            DisconnectedMode.DisconnectedInsertEsame(id);
            return true;
        }
    }
}
