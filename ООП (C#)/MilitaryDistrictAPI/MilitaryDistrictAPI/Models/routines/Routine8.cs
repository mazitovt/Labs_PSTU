using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine8
    {
        public static string SQL_1 = "CALL Show_Units_WithMoreVehiclesThan({0}, {1})";
        public static string SQL_2 = "CALL Show_Units_WithNoVehicle({0})";

        public const string NAME_1 = "routine8.1";
        public const string NAME_2 = "routine8.2";


        [Column("unit_id")]
        [JsonProperty("Номер в/ч")]
        public string BuildingId { get; set; }


        [Column("unit_name")]
        [JsonProperty("Название в/ч")]
        public string UnitName{ get; set; }

        [Column("name")]
        [JsonProperty("Количество дислоцированных подразделений")]
        public string VehicleName { get; set; }

        [Column("amount")]
        [JsonProperty("Количество")]
        public int Amount { get; set; }
        
    }
}