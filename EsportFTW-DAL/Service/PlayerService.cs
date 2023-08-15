using EsportFTW_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsportFTW_DAL.Model;
using EsportFTW_DAL.Repository;

namespace EsportFTW_DAL.Service
{
    internal class PlayerService : IPlayerService
    {
        private readonly PlayerRepository _playerRepository = new();
        public IEnumerable<Player> Get()
        {
            return _playerRepository.Get();
        }

        public Player Get(int id)
        {
            return _playerRepository.Get(id);
        }

        public bool Add(Player entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Player entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
