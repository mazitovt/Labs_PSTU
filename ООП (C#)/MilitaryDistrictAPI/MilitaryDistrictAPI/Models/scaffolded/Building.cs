using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Building
    {
        [Display(Name = "Номер здания")]
        public int BuildingId { get; set; }
       
        [Display(Name = "Номер в/ч")]
        public int UnitId { get; set; }

        [Display(Name = "Кол-во дислоцированных подразделений")]
        public int NumberOfLivingSubunits { get; set; }

        [Display(Name = "Войсковая часть")]
        public virtual Unit Unit { get; set; }
    }
}
