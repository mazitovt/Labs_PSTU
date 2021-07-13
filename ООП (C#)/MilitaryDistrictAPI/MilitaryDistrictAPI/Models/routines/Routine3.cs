using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine3
    {
        public static string SQL = "CALL Show_Soldiers_WithRank({0}, {1})";
        public const string NAME = "routine3";


        [Column("soldier_name")]
        [JsonProperty("Военнослужащий")]
        public string SoldierName { get; set; }


        [Column("rank_name")]
        [JsonProperty("Звание")]
        public string RankName { get; set; }


        [Column("unit_name")]
        [JsonProperty("Войсковая часть")]
        public string UnitName { get; set; }
    }
}
