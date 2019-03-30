using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLevio.Data.Infrastructure;

namespace Services
{
    public class Serviceconge : Service<conge>, Iserviceconge
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        public Serviceconge() : base(UOW)
        {
        }
    }
}
