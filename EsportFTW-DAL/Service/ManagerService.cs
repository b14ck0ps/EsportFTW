using EsportFTW_DAL.DTOs;
using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using EsportFTW_DAL.Repository;

namespace EsportFTW_DAL.Service
{
    internal class ManagerService : IManagerService
    {
        private readonly IRepository<Manager, bool> _managerRepository;

        public ManagerService()
        {
            _managerRepository = new ManagerRepository();
        }

        public IEnumerable<Manager> Get()
        {
            return _managerRepository.Get();
        }

        public Manager Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(ManagerBase entity)
        {
            var manager = new Manager()
            {
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                Picture = "default.png",
                HireDate = DateTime.Now,
                Admin = new Admin() { Id = entity.AdminId }
            };
            return _managerRepository.Add(manager);
        }

        public bool Update(Manager entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
