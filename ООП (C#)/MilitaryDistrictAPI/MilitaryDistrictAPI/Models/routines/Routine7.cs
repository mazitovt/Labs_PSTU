using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine7
    {
        public static string SQL_1 = "CALL Show_Buildings({0})";
        public static string SQL_2 = "CALL Show_Buildings_LivingMoreThan({0},{1})";
        public static string SQL_3 = "CALL Show_Buildings_NonLiving({0})";
        
        public const string NAME_1 = "routine7.1";
        public const string NAME_2 = "routine7.2";
        public const string NAME_3 = "routine7.3";


        [Column("building_id")]
        [JsonProperty("Номер здания")]
        public string BuildingId { get; set; }


        [Column("unit_id")]
        [JsonProperty("Номер подразделения")]
        public string UnitId { get; set; }

        [Column("number_of_living_subunits")]
        [JsonProperty("Количество дислоцированных подразделений")]
        public int Amount { get; set; }
    }
}