using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine6
    {
        public static string SQL_1 = "CALL Show_Vehicles({0})";
        public static string SQL_2 = "CALL Show_Vehicles_WithCategory({0},{1})";
        public static string SQL_3 = "CALL Show_Vehicle_WithName({0},{1})";
        
        public const string NAME_1 = "routine6.1";
        public const string NAME_2 = "routine6.2";
        public const string NAME_3 = "routine6.3";


        [Column("category_name")]
        [JsonProperty("Категория")]
        public string Category { get; set; }


        [Column("vehicle_name")]
        [JsonProperty("Техника")]
        public string Name { get; set; }

        [Column("amount")]
        [JsonProperty("Количество")]
        public int Amount { get; set; }
    }
}