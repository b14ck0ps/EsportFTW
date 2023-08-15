using EsportFTW_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportFTW_DAL.Interface
{
    public interface IPlayerService
    {
        IEnumerable<Player> Get();
        Player Get(int id);
        bool Add(Player entity);
        bool Update(Player entity);
        bool Delete(int id);
    }
}
