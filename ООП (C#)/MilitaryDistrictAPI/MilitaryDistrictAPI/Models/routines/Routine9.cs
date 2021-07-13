using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine9
    {
        public static string SQL_1 = "CALL Show_Weapons({0})";
        public static string SQL_2 = "CALL Show_Weapons_WithCategory({0},{1})";
        public static string SQL_3 = "CALL Show_Weapon_WithName({0}, {1})";
        
        public const string NAME_1 = "routine9.1";
        public const string NAME_2 = "routine9.2";
        public const string NAME_3 = "routine9.3";


        [Column("category_name")]
        [JsonProperty("Категория вооружения")]
        public string BuildingId { get; set; }


        [Column("weapon_name")]
        [JsonProperty("Вооружение")]
        public string UnitId { get; set; }

        [Column("amount")]
        [JsonProperty("Количество")]
        public int Amount { get; set; }
    }
}