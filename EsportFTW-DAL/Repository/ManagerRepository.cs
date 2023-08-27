using System.Data;
using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using Oracle.ManagedDataAccess.Client;

namespace EsportFTW_DAL.Repository
{
    internal class ManagerRepository : Database, IRepository<Manager, bool>
    {
        public IEnumerable<Manager> Get()
        {
            const string query = "SELECT * FROM Manager";
            return ExecuteReaderQuery(query, MapManager);
        }

        public Manager Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Manager entity)
        {
            const string query = "INSERT INTO Manager (Manager_ID, Manager_Name, Manager_Email, Manager_Password, Manager_Picture, Manager_Hiredate, Admin_ID) " + "VALUES (seq_manager_id.NEXTVAL, :name, :email, :password, :picture, :hiredate, :adminId)";
            var parameters = new[]
            {
                    new OracleParameter(":name", OracleDbType.Varchar2) { Value = entity.Name },
                    new OracleParameter(":email", OracleDbType.Varchar2) { Value = entity.Email },
                    new OracleParameter(":password", OracleDbType.Varchar2) { Value = entity.Password },
                    new OracleParameter(":picture", OracleDbType.Varchar2) { Value = entity.Picture },
                    new OracleParameter(":hiredate", OracleDbType.Date) { Value = entity.HireDate },
                    new OracleParameter(":adminId", OracleDbType.Int32) { Value = entity.Admin.Id },
                };

            var rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool Update(Manager entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        private static Manager MapManager(IDataRecord reader)
        {
            return new Manager
            {
                Id = reader.GetInt32(reader.GetOrdinal("MANAGER_ID")),
                Name = reader.GetString(reader.GetOrdinal("MANAGER_NAME")),
                Email = reader.GetString(reader.GetOrdinal("MANAGER_EMAIL")),
                HireDate = reader.GetDateTime(reader.GetOrdinal("MANAGER_HIREDATE"))
            };
        }
    }
}
