using EsportFTW_DAL.Model;
using EsportFTW_DAL.DTOs;

namespace EsportFTW_DAL.Interface
{
    public interface IPlayerService
    {
        IEnumerable<Player> Get();
        Player Get(int id);
        bool Add(PlayerBaseInfo entity);
        bool RegisterWithAddress(PlayerRegistrationDto entity);
        bool Update(PlayerRegistrationDto entity);
        bool Delete(int id);
        bool IsEmailUnique(string email);
    }
}
