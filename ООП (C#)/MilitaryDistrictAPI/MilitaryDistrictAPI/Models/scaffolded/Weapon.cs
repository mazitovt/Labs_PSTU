using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Weapon
    {

        public int WeaponId { get; set; }
        
        [Display(Name = "Номер категории")]
        public int WeaponCategoryId { get; set; }
        
        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Название не может быть пустым")]
        public string Name { get; set; }
        
        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Укажите количество")]
        [Range(typeof(int), "0", "100", ErrorMessage = "Только положительные числа")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Только положительные числа")]
        public int Amount { get; set; }

        [Display(Name = "Категория вооружения")]
        public virtual WeaponCategory WeaponCategory { get; set; }
    }
}
