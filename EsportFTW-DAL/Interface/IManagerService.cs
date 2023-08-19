using EsportFTW_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportFTW_DAL.Interface
{
    public interface IManagerService
    {
        IEnumerable<Manager> Get();
        Manager Get(int id);
        bool Add(Manager entity);
        bool Update(Manager entity);
        bool Delete(int id);
    }
}
