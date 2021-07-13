using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class WeaponCategory
    {
        public WeaponCategory()
        {
            Weapons = new HashSet<Weapon>();
        }

        public int WeaponCategoryId { get; set; }
        
        [Display(Name = "Номер в/ч")]
        public int UnitId { get; set; }
        
        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Название не может быть пустым")]
        public string Name { get; set; }

        [Display(Name = "Войсковая часть")]
        public virtual Unit Unit { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
