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
            if (entity.Salary != 0) return _playerRepository.RegisterPlayer(entity);

            var random = new Random();
            entity.Salary = random.Next(1000, 10000);
            return _playerRepository.RegisterPlayer(entity);
        }

        public bool UpdatePlayerBasicInfo(PlayerUpdateDto entity)
        {
            return _playerRepository.UpdatePlayerBasicInfo(entity);
        }

        public bool Update(PlayerUpdateDto entity)
        {
            var player = Get(entity.Id);

            player.Name = entity.Name;
            player.DOB = entity.Dob;
            player.PlayHours = entity.PlayHours;
            player.Address.Street = entity.Street;
            player.Address.City = entity.City;
            player.Address.ZipCode = entity.ZipCode;

            return _playerRepository.Update(player);
        }

        public bool Delete(int id)
        {
            return _playerRepository.Delete(id);
        }

        public bool IsAuthenticated(LoginDto loginDto)
        {
            return _playerRepository.IsAuthenticated(loginDto);
        }

        public bool IsEmailUnique(string email)
        {
            return _playerRepository.IsEmailUnique(email);
        }
    }
}
