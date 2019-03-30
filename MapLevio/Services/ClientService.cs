using Domaine;
using MapLevio.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientService : Service<client>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ClientService(IUnitOfWork utwk) : base(utwk)
        {
        }

        public ClientService() : base(utwk)
        {

        }
        public client GetuserById(int id)
        {
            return utwk.getRepository<client>().GetById(id);
        }
        public client GetuserByEmail(string email, string password)
        {
            return utwk.getRepository<client>().Get(m => m.email == email);
        }

        public IEnumerable<client> ListUser()
        {

            return utwk.getRepository<client>().GetAll();
        }
        public client Delete(int id)
        {
            client p = utwk.getRepository<client>().GetById(id);
            utwk.getRepository<client>().Delete(p);
            return p;
        }

        public void add(client c)
        {
            utwk.getRepository<client>().Add(c);
            utwk.Commit();


        }


    }
}
