using EsportFTW_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportFTW_DAL.DTOs;

namespace EsportFTW_DAL.Interface
{
    public interface IPlayerService
    {
        IEnumerable<Player> Get();
        Player Get(int id);
        bool Add(PlayerBaseInfo entity);
        bool Update(PlayerBaseInfo entity);
        bool Delete(int id);
    }
}
