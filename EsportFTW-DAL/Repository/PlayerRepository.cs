using System.Data;
using EsportFTW_DAL.DTOs;
using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using Oracle.ManagedDataAccess.Client;

namespace EsportFTW_DAL.Repository
{
    internal class PlayerRepository : Database, IRepository<Player, bool>, IAuth
    {
        public IEnumerable<Player> Get()
        {
            return ExecuteReaderQuery(AllPlayerDataQuery, MapPlayer);
        }

        public Player Get(int id)
        {
            const string query = AllPlayerDataQuery + " WHERE player_id = :id";
            var parameter = new OracleParameter(":id", OracleDbType.Int32) { Value = id };
            return ExecuteReaderQuery(query, MapPlayer, new[] { parameter }).FirstOrDefault()!;
        }

        public bool Add(Player entity)
        {
            const string query = "INSERT INTO Player (Player_ID, Player_Name, Player_Email, Player_Password, Player_Picture, Player_JoinDate, Player_Play_Hours, Player_Salary, Player_DOB) " +
                                 "VALUES (seq_player_id.NEXTVAL, :name, :email, :password, :picture, :joinDate, :playHours, :salary, :dob)";

            var parameters = new[]
            {
                new OracleParameter(":name", OracleDbType.Varchar2) { Value = entity.Name },
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = entity.Email },
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = entity.Password },
                new OracleParameter(":picture", OracleDbType.Varchar2) { Value = entity.Picture },
                new OracleParameter(":joinDate", OracleDbType.Date) { Value = entity.JoinDate },
                new OracleParameter(":playHours", OracleDbType.Double) { Value = entity.PlayHours },
                new OracleParameter(":salary", OracleDbType.Decimal) { Value = entity.Salary },
                new OracleParameter(":dob", OracleDbType.Date) { Value = entity.DOB }
            };

            var rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool Update(Player entity)
        {
            const string query = "UPDATE Player SET player_name = :name, player_email = :email, player_password = :password, player_picture = :picture, " +
                                 "player_joindate = :joinDate, player_salary = :salary, player_play_hours = :playHours, player_dob = :dob WHERE player_id = :id";

            var parameters = new[]
            {
                new OracleParameter(":name", OracleDbType.Varchar2) { Value = entity.Name },
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = entity.Email },
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = entity.Password },
                new OracleParameter(":picture", OracleDbType.Varchar2) { Value = entity.Picture },
                new OracleParameter(":joinDate", OracleDbType.Date) { Value = entity.JoinDate },
                new OracleParameter(":salary", OracleDbType.Decimal) { Value = entity.Salary },
                new OracleParameter(":playHours", OracleDbType.Int32) { Value = entity.PlayHours },
                new OracleParameter(":dob", OracleDbType.Date) { Value = entity.DOB },
                new OracleParameter(":id", OracleDbType.Int32) { Value = entity.Id }
            };

            var rowsAffected = ExecuteNonQuery(query, parameters.ToArray());
            return rowsAffected > 0;
        }

        public bool UpdatePlayerBasicInfo(PlayerUpdateDto playerUpdateDto)
        {
            var parameters = new[]
            {
                new OracleParameter("p_Player_ID", OracleDbType.Int32) { Value = playerUpdateDto.Id },
                new OracleParameter("p_Name", OracleDbType.Varchar2) { Value = playerUpdateDto.Name },
                new OracleParameter("p_Play_Hours", OracleDbType.Int32) { Value = playerUpdateDto.PlayHours },
                new OracleParameter("p_DOB", OracleDbType.Date) { Value = playerUpdateDto.Dob },
                new OracleParameter("p_City", OracleDbType.Varchar2) { Value = playerUpdateDto.City },
                new OracleParameter("p_Street", OracleDbType.Varchar2) { Value = playerUpdateDto.Street },
                new OracleParameter("p_Zip_Code", OracleDbType.Varchar2) { Value = playerUpdateDto.ZipCode }
            };
            const string procedureName = "Update_Player_Data";
            var rowsAffected = ExecuteNonQuery(procedureName, parameters, isProcedure: true);

            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            const string query = "DELETE FROM player WHERE player_id = :id";
            var parameter = new OracleParameter(":id", OracleDbType.Int32) { Value = id };

            var rowsAffected = ExecuteNonQuery(query, new[] { parameter });
            return rowsAffected > 0;
        }

        public bool RegisterPlayer(PlayerRegistrationDto playerDto)
        {
            var parameters = new[]
            {
                new OracleParameter("p_Ign", OracleDbType.Varchar2) { Value = playerDto.IGN },
                new OracleParameter("p_Name", OracleDbType.Varchar2) { Value = playerDto.Name },
                new OracleParameter("p_Email", OracleDbType.Varchar2) { Value = playerDto.Email },
                new OracleParameter("p_Password", OracleDbType.Varchar2) { Value = playerDto.Password },
                new OracleParameter("p_Picture", OracleDbType.Varchar2) { Value = playerDto.Picture },
                new OracleParameter("p_JoinDate", OracleDbType.Date) { Value = playerDto.JoinDate },
                new OracleParameter("p_Salary", OracleDbType.Decimal) { Value = playerDto.Salary },
                new OracleParameter("p_Play_Hours", OracleDbType.Int32) { Value = playerDto.PlayHours },
                new OracleParameter("p_DOB", OracleDbType.Date) { Value = playerDto.DOB },
                new OracleParameter("p_Country", OracleDbType.Varchar2) { Value = playerDto.SelectedCountry },
                new OracleParameter("p_City", OracleDbType.Varchar2) { Value = playerDto.City },
                new OracleParameter("p_Street", OracleDbType.Varchar2) { Value = playerDto.Street },
                new OracleParameter("p_Zip_Code", OracleDbType.Varchar2) { Value = playerDto.ZipCode }
            };

            const string procedureName = "Insert_Player_Data";
            var rowsAffected = ExecuteNonQuery(procedureName, parameters, isProcedure: true);

            return rowsAffected > 0;
        }


        private static Player MapPlayer(IDataRecord reader)
        {
            var player = new Player
            {
                Id = reader.GetInt32(reader.GetOrdinal("player_id")),
                Ign = reader.GetString(reader.GetOrdinal("player_ign")),
                Name = reader.GetString(reader.GetOrdinal("player_name")),
                Email = reader.GetString(reader.GetOrdinal("player_email")),
                Password = reader.GetString(reader.GetOrdinal("player_password")),
                Picture = reader.GetString(reader.GetOrdinal("player_picture")),
                JoinDate = reader.GetDateTime(reader.GetOrdinal("player_joindate")),
                PlayHours = reader.GetInt32(reader.GetOrdinal("player_play_hours")),
                Salary = reader.GetDecimal(reader.GetOrdinal("player_salary")),
                DOB = reader.GetDateTime(reader.GetOrdinal("player_dob"))
            };

            if (!reader.IsDBNull(reader.GetOrdinal("pa_id")))
            {
                player.Address = new PlayerAddress
                {
                    ID = reader.GetInt32(reader.GetOrdinal("pa_id")),
                    Country = reader.GetString(reader.GetOrdinal("player_country")),
                    City = reader.GetString(reader.GetOrdinal("player_city")),
                    Street = reader.GetString(reader.GetOrdinal("player_street")),
                    ZipCode = reader.GetString(reader.GetOrdinal("player_zip_code")),
                };
            }

            if (!reader.IsDBNull(reader.GetOrdinal("psl_id")))
            {
                player.SocialLinks = new PlayerSocialLink
                {
                    ID = reader.GetInt32(reader.GetOrdinal("psl_id")),
                    FacebookLink = reader.GetString(reader.GetOrdinal("player_facebook_link")),
                    InstagramLink = reader.GetString(reader.GetOrdinal("player_instagram_link")),
                    TwitterLink = reader.GetString(reader.GetOrdinal("player_twitter_link")),
                    YoutubeLink = reader.GetString(reader.GetOrdinal("player_youtube_link")),
                };
            }

            if (!reader.IsDBNull(reader.GetOrdinal("pp_id")))
            {
                player.PlayerPhones = new List<PlayerPhone>
                {
                    new PlayerPhone
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("pp_id")),
                        Phone = reader.GetString(reader.GetOrdinal("player_phone")),
                    },
                };
            }

            if (!reader.IsDBNull(reader.GetOrdinal("team_id")))
            {
                player.Team = new Team
                {
                    ID = reader.GetInt32(reader.GetOrdinal("team_id")),
                    Name = reader.GetString(reader.GetOrdinal("team_name")),
                };
            }

            return player;
        }

        public bool IsAuthenticated(LoginDto loginDto)
        {
            const string query = "SELECT COUNT(*) FROM player WHERE player_email = :email AND player_password = :password";
            var parameter = new[]
            {
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = loginDto.Email },
                new OracleParameter(":password", OracleDbType.Varchar2) { Value = loginDto.Password }
            };

            var count = ExecuteScalarQuery(query, parameter);

            return count > 0;
        }

        public bool IsEmailUnique(string email)
        {
            const string query = "SELECT COUNT(*) FROM player WHERE player_email = :email";
            var parameter = new OracleParameter(":email", OracleDbType.Varchar2) { Value = email };

            var count = ExecuteScalarQuery(query, new[] { parameter });

            return count > 0;
        }


        private const string AllPlayerDataQuery = "select * from player_detail_view";

    }
}
