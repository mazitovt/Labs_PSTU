using System;
using System.Collections.Generic;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class UnitLocation
    {
        public int UnitId { get; set; }
        public int LocationTypeId { get; set; }
        public string LocationName { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
