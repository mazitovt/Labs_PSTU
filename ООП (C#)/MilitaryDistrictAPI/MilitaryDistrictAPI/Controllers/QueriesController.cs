using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models;
using MilitaryDistrictAPI.Models.scaffolded;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDistrictAPI.Controllers
{


    public class QueriesController : Controller
    {

        private readonly MilitaryDistrict2Context _context;

        public QueriesController(MilitaryDistrict2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string sqlGetRoutines = "SELECT routine_name FROM information_schema.routines WHERE routine_type in ('PROCEDURE', 'FUNCTION') and routine_name not like 'Insert%' AND routine_schema = 'military_district_2'; ";

            sqlGetRoutines = "SELECT * FROM storedroutines;";

            var connection = _context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new MySqlCommand(sqlGetRoutines, (MySqlConnection)connection);

            DataTable table = new DataTable();

            using (var dataAdapter = new MySqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                dataAdapter.Fill(table);
            }

            var routines = GetStoredRoutines(table);
            
            return View(routines);
        }


        private IList<StoredRoutine> GetStoredRoutines(DataTable table)
        {
            return table.AsEnumerable().Select(row => new StoredRoutine
            {
                Name = (string)row[0],
                QueryNumber = (double)row[1],
                Description = (string)row[2],
                NumberOfAgrs = (int)row[3],
                AgrsDescription = ((string)row[4]).Split(':'),
                ComplexResponse = (bool)row[5],
                RoutineName = (string)row[6],
                ShortDescription = (string)row[7]
            }).ToList();
        }
    }
}
