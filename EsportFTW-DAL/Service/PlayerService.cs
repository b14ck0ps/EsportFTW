using EsportFTW_DAL.Interface;
using EsportFTW_DAL.DTOs;
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

        public bool Add(PlayerBaseInfo entity)
        {
            var newPlayer = new Player()
            {
                Ign = entity.Ign,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                DOB = entity.DOB,
                Picture = entity.Picture,
                JoinDate = DateTime.Now,
                PlayHours = 0,
            };

            return _playerRepository.Add(newPlayer);
        }

        public bool RegisterWithAddress(PlayerRegistrationDto entity)
        {
            return _playerRepository.RegisterPlayer(entity);
        }

        public bool Update(PlayerRegistrationDto entity)
        {
            /*            var updatedPlayer = new Player()
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            Email = entity.Email,
                            Password = entity.Password,
                            DOB = entity.DOB,
                            Picture = entity.Picture,
                            JoinDate = DateTime.Now,
                            PlayHours = entity.PlayHours,
                            Salary = entity.Salary
                        };
            */
            //return _playerRepository.Update(updatedPlayer);
            return false;
        }

        public bool Delete(int id)
        {
            return _playerRepository.Delete(id);
        }

        public bool IsEmailUnique(string email)
        {
            return _playerRepository.EmailExists(email);
        }
    }
}
