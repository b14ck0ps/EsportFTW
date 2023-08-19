using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportFTW_DAL.Repository
{
    internal class ManagerRepository : Database, IRepository<Manager, bool>
    {
        public bool Add(Manager entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> Get()
        {
            throw new NotImplementedException();
        }

        public Manager Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}
