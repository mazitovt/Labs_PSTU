using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine5
    {
        public static string SQL = "CALL Show_Locations({0})";
        public const string NAME = "routine5";


        [Column("unit_id")]
        [JsonProperty("Номер в/ч")]
        public int UnitId { get; set; }


        [Column("name")]
        [JsonProperty("Полное название")]
        public string UnitName { get; set; }

        [Column("location_name")]
        [JsonProperty("Место дислокации")]
        public string Location { get; set; }
        
        [Column("level")]
        [JsonProperty("Уровень")]
        public int Level { get; set; }
    }
}