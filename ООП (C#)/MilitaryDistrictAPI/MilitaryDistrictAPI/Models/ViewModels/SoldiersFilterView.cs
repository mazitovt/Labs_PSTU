using System.Collections;
using System.Collections.Generic;
using MilitaryDistrictAPI.Models.Filter;
using MilitaryDistrictAPI.Models.scaffolded;

namespace MilitaryDistrictAPI.Models.ViewModels
{
    public class SoldiersFilterView
    {
        public FilterSoldier Filter { get; set; }
        public IEnumerable<Soldier> Soldiers { get; set; }
    }
}