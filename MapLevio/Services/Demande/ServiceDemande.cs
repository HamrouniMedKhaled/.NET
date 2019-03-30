using Domaine;
using MapLevio.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demande
{
    public class ServiceDemande: Service<demande> ,IServiceDemande
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        public ServiceDemande() : base(UOW)
        {
        }


    }
}
