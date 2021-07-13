using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Occupation
    {
        public Occupation()
        {
            Soldiers = new List<Soldier>();
        }
        
        [Column("occupation_id")]
        [Display(Name = "Номер")]
        public int OccupationId { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        
        public ICollection<Soldier> Soldiers { get; set; }
    }
}
