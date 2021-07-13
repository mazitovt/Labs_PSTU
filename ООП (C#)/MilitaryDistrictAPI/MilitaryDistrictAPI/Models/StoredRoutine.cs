using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDistrictAPI.Models
{
    public class StoredRoutine
    {
        public string Name { get; set; }
        public double QueryNumber { get; set; }
        public string Description { get; set; }
        public int NumberOfAgrs { get; set; }
        public string[] AgrsDescription { get; set; }
        public bool ComplexResponse { get; set; }
        public string RoutineName { get; set; }
        public string ShortDescription { get; set; }
    }
}
