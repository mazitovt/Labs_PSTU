using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine1
    {

        public static readonly string SQL = "CALL Show_ChainOfSubunitsAndLeaders({0})";
        public const string NAME = "routine1";

        [JsonProperty("Номер части")]
        public int UnitId { get; set; }

        [JsonProperty("Название")]
        public string UnitName { get; set; }

        [JsonProperty("Командир")]
        public string LeaderName { get; set; }

        [JsonProperty("Уровень")]
        public int Level { get; set; }
    }
}
