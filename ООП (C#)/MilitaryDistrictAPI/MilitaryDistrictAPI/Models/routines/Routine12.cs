using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine12
    {
        public static string SQL_1 = "CALL Show_Units_WithMoreWeaponsThan({0},{1})";
        public static string SQL_2 = "CALL Show_Units_WithNoWeapon({0})";
        
        public const string NAME_1 = "routine12.1";
        public const string NAME_2 = "routine12.2";


        [Column("unit_id")]
        [JsonProperty("Номер в/ч")]
        public string UnitId { get; set; }

        [Column("name")]
        [JsonProperty("Вооружение")]
        public string WeaponName { get; set; }
        
        [Column("amount")]
        [JsonProperty("Количество")]
        public string Amount { get; set; }
    }
}