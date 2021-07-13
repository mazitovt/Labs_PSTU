using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class MilitaryRank
    {
        public MilitaryRank()
        {
            Soldiers = new HashSet<Soldier>();
        }

        [Display(Name = "Номер")]
        public int MilitaryRankId { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Группа званий")]
        public string RankGroup { get; set; }

        [Display(Name = "Может командовать высшими формированиями")]
        public bool CommandHigherUnit { get; set; }

        public virtual ICollection<Soldier> Soldiers { get; set; }
    }
}
