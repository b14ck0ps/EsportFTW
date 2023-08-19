using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using EsportFTW_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportFTW_DAL.Service
{
    internal class ManagerService : IManagerService
    {
        private readonly ManagerRepository _managerRepository = new();
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
