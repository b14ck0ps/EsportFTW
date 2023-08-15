using System.Data;
using EsportFTW_DAL.Interface;
using EsportFTW_DAL.Model;
using Oracle.ManagedDataAccess.Client;

namespace EsportFTW_DAL.Repository
{
    internal class PlayerRepository : Database, IRepository<Player, bool>
    {
        public IEnumerable<Player> Get()
        {
            return ExecuteReaderQuery(AllPlayerDataQuery, MapPlayer);
        }

        public Player Get(int id)
        {
            const string query = AllPlayerDataQuery + " WHERE p.player_id = :id";
            var parameter = new OracleParameter(":id", OracleDbType.Int32) { Value = id };
            return ExecuteReaderQuery(query, MapPlayer, new[] { parameter }).FirstOrDefault()!;
        }

        public bool Add(Player entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Player entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        private static Player MapPlayer(IDataRecord reader)
        {
            return new Player
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                Password = reader.GetString(3),
                Picture = reader.GetString(4),
                JoinDate = reader.GetDateTime(5),
                Salary = reader.GetDecimal(6),
                PlayHours = reader.GetInt32(7),
                DOB = reader.GetDateTime(8),
                Address = new PlayerAddress
                {
                    ID = reader.GetInt32(9),
                    Country = reader.GetString(10),
                    City = reader.GetString(11),
                    Street = reader.GetString(12),
                    ZipCode = reader.GetString(13),
                },
                SocialLinks = new PlayerSocialLink
                {
                    ID = reader.GetInt32(14),
                    FacebookLink = reader.GetString(15),
                    InstagramLink = reader.GetString(16),
                    TwitterLink = reader.GetString(17),
                    YoutubeLink = reader.GetString(18),
                },

                PlayerPhones = new List<PlayerPhone>()
                {
                    new PlayerPhone
                    {
                        ID = reader.GetInt32(19),
                        Phone = reader.GetString(20),
                    },
                },
                team = new Team
                {
                    ID = reader.GetInt32(21),
                    Name = reader.GetString(22),
                }
            };
        }

        private const string AllPlayerDataQuery = @"SELECT
                                    p.player_id, p.player_name, p.player_email, p.player_password, p.player_picture, p.player_joindate, p.player_play_hours,    p.player_salary,             p.player_dob,
                                    pa.pa_id, pa.player_country, pa.player_city, pa.player_street, player_zip_code,
                                    psl.psl_id, psl.player_facebook_link, psl.player_instagram_link, psl.player_twitter_link, psl.player_instagram_link,
                                    pp.pp_id, pp.player_phone,
                                    t.team_id, t.team_name
                            FROM player p
                                   JOIN player_address pa ON p.player_id = pa.pa_id
                                   JOIN player_social_link psl ON p.player_id = psl.player_id
                                   JOIN player_phone pp ON p.player_id = pp.player_id
                                   JOIN player_team pt ON p.player_id = pt.player_id
                                   JOIN team t ON pt.team_id = t.team_id
                                   JOIN player_winning pw ON p.player_id = pw.player_id";
    }
}
