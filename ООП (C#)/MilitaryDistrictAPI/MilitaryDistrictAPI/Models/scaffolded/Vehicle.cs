using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Org.BouncyCastle.Crypto.Tls;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        
        [Display(Name = "Номер категории")]
        public int VehicleCategoryId { get; set; }
        
        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Название не может быть пустым")]
        public string Name { get; set; }
        
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Укажите количество")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Только положительные числа")]
        [Range(typeof(int), "0", "100", ErrorMessage = "Только положительные числа")]
        public int Amount { get; set; }

        [Display(Name = "Категория техники")]
        public virtual VehicleCategory VehicleCategory { get; set; }
    }
}
