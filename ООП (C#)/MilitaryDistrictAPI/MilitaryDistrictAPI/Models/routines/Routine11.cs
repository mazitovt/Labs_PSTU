using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine11
    {
        public static string SQL_1 = "CALL Show_Soldiers_WithOccupation({0},{1})";
        public static string SQL_2 = "CALL Show_SoldiersSubunit_WithOccupation({0},{1})";
        
        public const string NAME_1 = "routine11.1";
        public const string NAME_2 = "routine11.2";


        [Column("soldier_id")]
        [JsonProperty("Номер в/с")]
        public int SoldierId { get; set; }


        [Column("soldier_name")]
        [JsonProperty("Имя в/с")]
        public string SoldierName { get; set; }
        
        [Column("serving_unit_id")]
        [JsonProperty("Номер в/ч")]
        public int ServingUnitId { get; set; }


        [Column("occupation_id")]
        [JsonProperty("Номер специальности")]
        public int OccupationId { get; set; }
    }
}