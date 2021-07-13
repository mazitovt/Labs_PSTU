using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Unit
    {
        public Unit()
        {
            Buildings = new HashSet<Building>();
            InverseParentUnit = new HashSet<Unit>();
            Soldiers = new HashSet<Soldier>();
            Subunits = new HashSet<Subunit>();
            VehicleCategories = new HashSet<VehicleCategory>();
            WeaponCategories = new HashSet<WeaponCategory>();
        }

        [Display(Name = "№")]
        public int UnitId { get; set; }
        
        [Display(Name = "Тип в/ч")]
        public int UnitTypeId { get; set; }
        
        [Display(Name = "Номер в/ч")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер в/ч не может быть пустым")]
        public string UnitNumber { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "В составе")]
        public int? ParentUnitId { get; set; }
        
        [Display(Name = "Командующий")]
        public int? LeaderId { get; set; }

        [Display(Name = "Командующий")]
        public virtual Soldier Leader { get; set; }
        
        [Display(Name = "В составе")]
        public virtual Unit ParentUnit { get; set; }
        [Display(Name = "Тип")]
        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Unit> InverseParentUnit { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public virtual ICollection<Subunit> Subunits { get; set; }
        public virtual ICollection<VehicleCategory> VehicleCategories { get; set; }
        public virtual ICollection<WeaponCategory> WeaponCategories { get; set; }
    }
}
