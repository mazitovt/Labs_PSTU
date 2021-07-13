using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MilitaryDistrictAPI.Models.routines
{
    public class Routine10
    {
        public static string SQL_1 = "CALL Show_Occupations_WithMoreSpecialistsThan({0},{1})";
        public static string SQL_2 = "CALL Show_Occupations_WithNoSpecialists({0})";
        
        public const string NAME_1 = "routine10.1";
        public const string NAME_2 = "routine10.2";


        [Column("name")]
        [JsonProperty("Специальность")]
        public string BuildingId { get; set; }


        [Column("specialists")]
        [JsonProperty("Количество специалистов")]
        public string UnitId { get; set; }

    }
}