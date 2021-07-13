using System.Data;
using MySql.Data.MySqlClient;

namespace FacultyISBackend.DataAdapterController
{
    public class QueryWorker: DataWorker
    {
        private MySqlConnection _connection;

        public int QueryParam
        {
            set
            {
                var command = new MySqlCommand(_query, _connection);
                command.Parameters.Add(new MySqlParameter("@year", value.ToString()));
                _dataAdapter = new MySqlDataAdapter(command);
            }
        }

        public QueryWorker(string query, MySqlConnection connection)
        {
            _query = query;
            _connection = connection;
        }
    }
}

