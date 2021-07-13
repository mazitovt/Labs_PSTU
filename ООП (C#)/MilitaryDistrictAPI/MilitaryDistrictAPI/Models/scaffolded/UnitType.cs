using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class UnitType
    {
        public UnitType()
        {
            Units = new HashSet<Unit>();
        }

        [Display(Name = "Номер")]
        public int UnitTypeId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
