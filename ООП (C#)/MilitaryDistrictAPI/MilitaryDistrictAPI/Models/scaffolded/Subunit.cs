using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Subunit
    {
        public Subunit()
        {
            Soldiers = new HashSet<Soldier>();
        }

        [Display(Name = "№")]
        public int SubunitId { get; set; }
        
        [Display(Name = "Командир")]
        public int? LeaderId { get; set; }
        
        [Display(Name = "Номер типа")]
        public int SubunitTypeId { get; set; }
        
        [Display(Name = "B составе")]
        public int ParentUnitId { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Display(Name = "Командир")]
        public virtual Soldier Leader { get; set; }
        
        [Display(Name = "В составе")]
        public virtual Unit ParentUnit { get; set; }
        
        [Display(Name = "Тип")]
        public virtual SubunitType SubunitType { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
