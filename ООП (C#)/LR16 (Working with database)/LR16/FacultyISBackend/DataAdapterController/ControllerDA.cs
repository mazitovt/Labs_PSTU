using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace FacultyISBackend.DataAdapterController 
{
    public class ControllerDA: IFacultyISController
    {
        private MySqlConnection _connection = new(ConnectionHelper.GetConnectionString("MySQL"));
 
        private bool _dataTableChanged;
        
        private TableWorker _tableWorkerStudents;
        private TableWorker _tableWorkerGroups;
        private QueryWorker _queryWorkerStudentsWithYear;
        private DataWorker _lastDataWorkerToUpdate;

        public IList Students
        {
            get
            {
                PerformDataWorkerQuery(_tableWorkerStudents);
                return ((IListSource)_tableWorkerStudents.DataTable).GetList();
            }   
        }
        public IList Groups
        {
            get
            {
                PerformDataWorkerQuery(_tableWorkerGroups);
                return ((IListSource)_tableWorkerGroups.DataTable).GetList();
            }   
        }
        
        public bool GetAndEraseDataTableChange
        {
            get {
                if (!_dataTableChanged) return false;
                _dataTableChanged = false;
                return true;
            }
        }
        
        public DataTable DataTable => _lastDataWorkerToUpdate.DataTable;
        
        public ControllerDA()
        {
            OpenConnection();
            InitializeDataWorkers();
            _dataTableChanged = false;
        }
        
        private void InitializeDataWorkers()
        {
            _tableWorkerStudents = new TableWorker("SELECT * FROM student", _connection);
            _tableWorkerGroups = new TableWorker("SELECT * FROM `group`", _connection);
            _queryWorkerStudentsWithYear = new QueryWorker(
                "select g.name group_name, student_id, s.name student_name " +
                "from student s join `group` g " +
                "on g.group_id = s.group_id where g.year = @year " +
                "order by s.name"
                , _connection);
        }
        private void OpenConnection()
        {
            _connection.Open();
        }
        private void CloseConnection()
        {
            _connection.Close();
        }
        public void UpdateDataTable()
        {
            if (_lastDataWorkerToUpdate is TableWorker worker)
                worker.UpdateDataBase();
        }

        public void PerformDataWorkerQuery(DataWorker dataWorker)
        {
            if (_lastDataWorkerToUpdate == null || _lastDataWorkerToUpdate != dataWorker)
            {
                _dataTableChanged = true;
                _lastDataWorkerToUpdate = dataWorker;
            }
            
            dataWorker.ClearAndFillTable();
        }

        public IList QueryStudentsWithYear(int year)
        {
            _queryWorkerStudentsWithYear.QueryParam = year;
            PerformDataWorkerQuery(_queryWorkerStudentsWithYear);
            
            var dataTable = _queryWorkerStudentsWithYear.DataTable;
            
            // return  r.AsEnumerable().Select(row => row.ItemArray).ToList();
            
            return ((IListSource)dataTable).GetList();
        }

        public void SaveChanges()
        {
            _tableWorkerGroups.UpdateDataBase();
            _tableWorkerStudents.UpdateDataBase();
        }
    }
}
