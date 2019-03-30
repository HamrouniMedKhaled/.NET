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
    public class UserService : Service<candidate>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public UserService(IUnitOfWork utwk) : base(utwk)
        {
        }

        public UserService() : base(utwk)
        {

        }
        public candidate GetuserById(int id)
        {
            return utwk.getRepository<candidate>().GetById(id);
        }
        public candidate GetuserByEmail(string email, string password)
        {
            return utwk.getRepository<candidate>().Get(m => m.email == email );
        }
        public resource GetuserrById(int id)
        {
            return utwk.getRepository<resource>().GetById(id);
        }
        public resource GetuserByEmailr(string email, string password)
        {
            return utwk.getRepository<resource>().Get(m => m.email == email);
        }

        public IEnumerable<candidate> ListUser()
        {

            return utwk.getRepository<candidate>().GetAll();
        }
        public candidate Delete(int id)
        {
            candidate p = utwk.getRepository<candidate>().GetById(id);
            utwk.getRepository<candidate>().Delete(p);
            return p;
        }

        public void add(candidate c)
        {
            utwk.getRepository<candidate>().Add(c);
            utwk.Commit();
           

        }


    }
}
