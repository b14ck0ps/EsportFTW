using Oracle.ManagedDataAccess.Client;

namespace EsportFTW_DAL.Repository
{
    internal abstract class Database
    {
        private const string ConnectionString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=49161))(CONNECT_DATA=(SID=xe)));User ID=EsportFTW;Password=EsportFTW;";

        /// <author>Azran Hossain</author>
        /// <summary>
        /// Executes a data reader query , such as a SELECT statement
        /// </summary>
        /// <typeparam name="T">The type to execute with</typeparam>
        /// <param name="query">The query to execute</param>
        /// <param name="mapFunc">The mapping function for the data reader</param>
        /// <param name="parameters">The query parameters, if any</param>
        /// <returns>The collection of mapped entities</returns>

        private protected static IEnumerable<T> ExecuteReaderQuery<T>(string query, Func<OracleDataReader, T> mapFunc, OracleParameter[]? parameters = null)
        {
            var result = new List<T>();

            using var connection = new OracleConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = query;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = mapFunc(reader);
                result.Add(item);
            }

            connection.Close();

            return result;
        }

        /// <author>Azran Hossain</author>
        /// <summary>
        /// Executes a non-query SQL statement against the database, such as an INSERT, UPDATE, or DELETE statement
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        /// <param name="parameters">The parameter values for the query, if any</param>
        /// <returns>The number of rows affected</returns>
        private protected static int ExecuteNonQuery(string query, OracleParameter[]? parameters = null)
        {
            using var connection = new OracleConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = query;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            var rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }

    }
}
