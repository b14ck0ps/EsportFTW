using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportFTW_DAL.DTOs;
using EsportFTW_DAL.Model;

namespace EsportFTW_DAL.Interface
{
    public interface IManagerService
    {
        IEnumerable<Manager> Get();
        Manager Get(int id);
        bool Add(ManagerBase entity);
        bool Update(Manager entity);
        bool Delete(int id);
    }
}
