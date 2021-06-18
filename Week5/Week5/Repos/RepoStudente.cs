using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.Entities;

namespace Week5.Repos
{
    class RepoStudente:IRepoStudenti
    {
        public IList<Studente> GetAll()
        {
            DisconnectedMode.DisconnectedSelect();
            return null;
        }
        public bool Add()
        {
            DisconnectedMode.DisconnectedInsertStudente();
            return true;
        }
    }
}
