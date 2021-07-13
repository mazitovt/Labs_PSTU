using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Diagnostics;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class SubunitType
    {
        public SubunitType()
        {
            Subunits = new HashSet<Subunit>();
        }

        [Display(Name = "Номер")]
        public int SubunitTypeId { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<Subunit> Subunits { get; set; }
    }
}
