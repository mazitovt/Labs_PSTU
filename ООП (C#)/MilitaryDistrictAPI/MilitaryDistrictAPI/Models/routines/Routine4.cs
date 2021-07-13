using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine4
    {
        public static string SQL = "CALL Show_ChainOfSoldierLeaders({0})";
        public const string NAME = "routine4";


        [JsonProperty("Номер в/ч")]
        public int SoldierId { get; set; }
        
        [JsonProperty("Военнослужащий")]
        public string Name { get; set; }
        
        [JsonProperty("Номер командира")]
        public int? LeaderId { get; set; }
    }
}
