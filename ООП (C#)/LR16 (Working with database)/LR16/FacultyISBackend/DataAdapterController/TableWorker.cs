using MySql.Data.MySqlClient;

namespace FacultyISBackend.DataAdapterController
{
    public class TableWorker : DataWorker
    {
        public TableWorker(string queryToTable, MySqlConnection connection)
        {
            _query = queryToTable;
            _dataAdapter = new MySqlDataAdapter(_query, connection);
            new MySqlCommandBuilder(_dataAdapter);
        }
        public void UpdateDataBase()
        {
            _dataAdapter.Update(_dataTable);
        }
    }
}