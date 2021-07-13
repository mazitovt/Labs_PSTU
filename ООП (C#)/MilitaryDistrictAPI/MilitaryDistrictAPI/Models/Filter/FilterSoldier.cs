using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MilitaryDistrictAPI.Models.scaffolded;

namespace MilitaryDistrictAPI.Models.Filter
{
    public class FilterSoldier
    {
        public string? UnitName { get; set; }
        public int? SubUnitId{ get; set; } 
        public string? LeaderName { get; set; } 
        public string? RankName { get; set; } 

    }
}