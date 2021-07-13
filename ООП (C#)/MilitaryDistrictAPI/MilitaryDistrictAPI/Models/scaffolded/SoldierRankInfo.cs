using System;
using System.Collections.Generic;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class SoldierRankInfo
    {
        public SoldierRankInfo()
        {
            Soldiers = new HashSet<Soldier>();
        }

        public int RecordId { get; set; }
        public DateTime DateOfPromotion { get; set; }
        public DateTime? DateOfGraduation { get; set; }

        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
