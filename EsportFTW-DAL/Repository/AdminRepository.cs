using System.Data;
using EsportFTW_DAL.DTOs;
using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using Oracle.ManagedDataAccess.Client;

namespace EsportFTW_DAL.Repository
{
    internal class AdminRepository : Database, IRepository<Admin, bool>
    {
        public IEnumerable<Admin> Get()
        {
            const string query = "SELECT * FROM Admin";
            return ExecuteReaderQuery(query, MapAdmin);
        }

        public Admin Get(int id)
        {
            const string query = "SELECT * FROM Admin WHERE admin_id = :id";
            var parameter = new OracleParameter(":id", OracleDbType.Int32) { Value = id };
            return ExecuteReaderQuery(query, MapAdmin, new[] { parameter }).FirstOrDefault()!;

        }

        public bool Add(Admin entity)
        {
            const string query = "INSERT INTO Admin (Admin_ID, Admin_Name, Admin_Email, Admin_Password, Admin_Picture) VALUES (seq_admin_id.NEXTVAL, :name, :email, :password, :picture)";
            var parameters = new[]
            {
                new OracleParameter(":name", OracleDbType.Varchar2) { Value = entity.Name},
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = entity.Email},
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = entity.Password},
                new OracleParameter(":picture", OracleDbType.Varchar2) { Value = entity.Picture},
            };

            var rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool Update(Admin entity)
        {
            const string query = "UPDATE Admin SET admin_name = :name, admin_email = :email, admin_password = :password, admin_picture = :picture WHERE admin_id = :id";
            var parameters = new[]
            {
                new OracleParameter(":name", OracleDbType.Varchar2) { Value = entity.Name},
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = entity.Email},
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = entity.Password},
                new OracleParameter(":picture", OracleDbType.Varchar2) { Value = entity.Picture},
                new OracleParameter(":id", OracleDbType.Int32) { Value = entity.Id},
            };
            var rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            const string query = "DELETE FROM Admin WHERE admin_id = :id";
            var parameter = new OracleParameter(":id", OracleDbType.Int32) { Value = id };

            var rowsAffected = ExecuteNonQuery(query, new[] { parameter });
            return rowsAffected > 0;
        }

        public bool IsAuthenticated(LoginDto loginDto)
        {
            const string query = "SELECT * FROM Admin WHERE admin_email = :email AND admin_password = :password";
            var parameters = new[]
            {
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = loginDto.Email},
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = loginDto.Password},
            };

            var rowsAffected = ExecuteReaderQuery(query, MapAdmin, parameters).Count();
            return rowsAffected > 0;
        }
        public int GetAdminByIdEmail(string email)
        {
            const string query = "SELECT admin_id FROM Admin WHERE admin_email = :email";
            var parameter = new OracleParameter(":email", OracleDbType.Varchar2) { Value = email };
            return ExecuteScalarQuery(query, new[] { parameter });
        }
        /*Custom mapper for the Admin entity*/
        private static Admin MapAdmin(IDataRecord reader)
        {
            return new Admin
            {
                Id = reader.GetInt32(reader.GetOrdinal("admin_id")),
                Name = reader.GetString(reader.GetOrdinal("admin_name")),
                Email = reader.GetString(reader.GetOrdinal("admin_email")),
                Password = reader.GetString(reader.GetOrdinal("admin_password")),
                Picture = reader.GetString(reader.GetOrdinal("admin_picture")),
            };
        }
    }
}