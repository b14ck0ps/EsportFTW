using EsportFTW_DAL.DTOs;

namespace EsportFTW_DAL.Interface
{
    public interface IAuth
    {
        bool IsAuthenticated(LoginDto loginDto);
        bool IsEmailUnique(string email);
    }
}
