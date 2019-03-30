using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLevio.Data.Infrastructure;

namespace Services.Candidat
{
   public  class CandidatService : Service<candidate>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public CandidatService() : base(ut)
        {
        }
    }
}
