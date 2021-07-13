using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine13
    {
        public static string SQL_1 = "CALL Show_Units_WithMostSubunits({0})";
        public static string SQL_2 = "CALL Show_Units_WithLeastSubunits({0})";
        
        public const string NAME_1 = "routine13.1";
        public const string NAME_2 = "routine13.2";


        [Column("unit_id")]
        [JsonProperty("Номер в/ч")]
        public string UnitId { get; set; }

        [Column("name")]
        [JsonProperty("Название в/ч")]
        public string UnitName { get; set; }
        
        [Column("subunits")]
        [JsonProperty("Количество входящих в/Ч")]
        public string Sununits { get; set; }
    }
}