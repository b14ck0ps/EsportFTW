using EsportFTW_DAL.Model;

namespace EsportFTW_DAL.Interface
{
    public interface IAdminService : IAuth
    {
        IEnumerable<Admin> Get();
        Admin Get(int id);
        bool Add(Admin entity);
        bool Update(Admin entity);
        bool Delete(int id);
        int GetAdminByEmail(string email);
    }
}
