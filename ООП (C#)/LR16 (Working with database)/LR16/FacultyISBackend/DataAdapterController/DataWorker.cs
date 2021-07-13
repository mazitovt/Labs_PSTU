using System.Data;
using MySql.Data.MySqlClient;

namespace FacultyISBackend.DataAdapterController
{
    public abstract class DataWorker
    {
        protected string _query;
        protected MySqlDataAdapter _dataAdapter;
        protected DataTable _dataTable = new();
        
        public DataTable DataTable => _dataTable;

        public void ClearAndFillTable()
        {
            _dataTable.Clear();
            _dataAdapter.Fill(_dataTable);
        }
    }
}