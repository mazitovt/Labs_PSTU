using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class LocationType
    {
        
        [Display(Name =  "Номер")]
        public int LocationTypeId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
