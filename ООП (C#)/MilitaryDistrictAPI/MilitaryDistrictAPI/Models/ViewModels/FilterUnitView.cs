using System.Collections.Generic;
using MilitaryDistrictAPI.Models.Filter;
using MilitaryDistrictAPI.Models.scaffolded;

namespace MilitaryDistrictAPI.Models.ViewModels
{
    public class FilterUnitView
    {
        public FilterUnit Filter { get; set; }
        public IEnumerable<Unit> Units { get; set; }
    }
}