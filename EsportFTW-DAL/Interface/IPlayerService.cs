using EsportFTW_DAL.Model;
using EsportFTW_DAL.DTOs;

namespace EsportFTW_DAL.Interface
{
    public interface IPlayerService : IAuth
    {
        IEnumerable<Player> Get();
        Player Get(int id);
        bool Add(PlayerBaseInfo entity);
        bool RegisterWithAddress(PlayerRegistrationDto entity);
        bool UpdatePlayerBasicInfo(PlayerUpdateDto entity);
        bool Update(PlayerUpdateDto entity);
        bool Delete(int id);
        int GetPlayerByEmail(string email);
    }
}
