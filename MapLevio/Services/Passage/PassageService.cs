using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLevio.Data.Infrastructure;

namespace Services.Passage
{
   public  class PassageService : Service<passage>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public PassageService() : base(ut)
        {
        }
        public IEnumerable<passage> allpasage()
        {
            IEnumerable<passage> pas = ut.getRepository<passage>().GetAll().ToList();
            return pas;
                }
       public void affecterDateTech(int c , DateTime d)
        {
            candidate cc = ut.getRepository<candidate>().GetById(c);
            List<test> tt = ut.getRepository<test>().GetMany(x => x.type == 1).ToList();
            Random rnd = new Random();
            int r = rnd.Next(tt.Count);
            test t = tt[r];
            passage p = new passage();
            p.TestId = t.testId;
            p.candidateId = cc.userId;
            p.test = t;
            p.test1.Add(t);
            p.candidate = cc;
            p.candidate1.Add(cc);
            
            
            
            p.dateOfPassing = d;
            ut.getRepository<passage>().Add(p);
            ut.Commit();
        }
        public void affecterDateFr(int c, DateTime d)
        {
            candidate cc = ut.getRepository<candidate>().GetById(c);
            List<test> tt = ut.getRepository<test>().GetMany(x => x.type == 1).ToList();
            Random rnd = new Random();
            int r=  rnd.Next(tt.Count);
            test t = tt[r];
            passage p = new passage();
            p.TestId = t.testId;
            p.candidateId = cc.userId;
            p.test = t;
            p.test1.Add(t);
            p.candidate = cc;
            p.candidate1.Add(cc);
            ut.getRepository<passage>().Add(p);
            ut.Commit();
        }
        public test findTest(int id)
        {
            passage pp = ut.getRepository<passage>().GetMany(x => x.candidateId == id).FirstOrDefault();
            test tt = ut.getRepository<test>().GetById(pp.TestId);
            return tt;
        }
        public bool verification(int id)
        {
            candidate cc = ut.getRepository<candidate>().GetById(id);
            passage  pp = ut.getRepository<passage>().GetMany(x => x.candidateId == id).FirstOrDefault();
            DateTime d = DateTime.Now;
            int result = DateTime.Compare(pp.dateOfPassing, d);
            if (result < 0)
            {
                return true;
            }
                
            else
            {
                return false;

            }



        }
        public bool passgeTest(passage p)
        {
            ut.getRepository<passage>().Update(p);
            test t = ut.getRepository<test>().GetMany(x => x.type == p.TestId).FirstOrDefault();
            int m = 0;
            if(t.answer1 == p.answer1)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer2 == p.answer2)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer3 == p.answer3)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer4 == p.answer4)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer5 == p.answer5)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer6 == p.answer6)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer7 == p.answer7)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer8 == p.answer8)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer9 == p.answer9)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer9 == p.answer9)
            {
                m = m + 2;
            }
            else
            {
                m = m - 1;
            }
            if (t.answer10 == p.answer10)
            {
                m = m +2;
            }
            else
            {
                m = m - 1;
            }
            p.mark = m;
            ut.getRepository<passage>().Update(p);
           int  iduser = p.candidateId;
            candidate c = ut.getRepository<candidate>().GetById(iduser);
            if (m < 10)
            {
                return false;
              //  c.etat = "Refuse";
                //ut.getRepository<candidate>().Update(c);

            }else
            {
                return true;
                //c.etat = "Attente_fr";
                //ut.getRepository<candidate>().Update(c);
            }

        }
    }
}
