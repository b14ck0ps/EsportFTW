using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Service;

namespace EsportFTW_DAL
{
    public static class DataFactory
    {
        public static IAdminService AdminService => new AdminService();
        public static IPlayerService PlayerService => new PlayerService();
        public static IManagerService ManagerService => new ManagerService();
    }
}
