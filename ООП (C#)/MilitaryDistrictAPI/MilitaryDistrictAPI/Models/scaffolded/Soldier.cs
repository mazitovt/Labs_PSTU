using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Google.Protobuf.WellKnownTypes;

#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class Soldier
    {
        public Soldier()
        {
            InverseLeader = new HashSet<Soldier>();
            Subunits = new HashSet<Subunit>();
            Units = new HashSet<Unit>();
            Occupations = new List<Occupation>();
        }

        [Display(Name = "№")]
        public int SoldierId { get; set; }
        
        [Display(Name = "Номер в/ч")]
        public int ServingUnitId { get; set; }
        
        [Display(Name = "Номер подразделения")]
        public int? ServingSubunitId { get; set; }
        
        [Display(Name = "Номер звания")]
        public int MilitaryRankId { get; set; }
        
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не может быть пустым")]
        public string Name { get; set; }
        
        [Display(Name = "Номер записи о звании")]
        public int? RankInfoId { get; set; }
        
        [Display(Name = "Номер командующего")]
        public int? LeaderId { get; set; }

        [Display(Name = "Командир")]
        public virtual Soldier Leader { get; set; }
        
        [Display(Name = "Звание")]
        public virtual MilitaryRank MilitaryRank { get; set; }
        
        [Display(Name = "Запись о звании")]
        public virtual SoldierRankInfo RankInfo { get; set; }
        
        [Display(Name = "Подразделение")]
        public virtual Subunit ServingSubunit { get; set; }
        
        [Display(Name = "Войсковая часть")]
        public virtual Unit ServingUnit { get; set; }
        
        [Display(Name = "InverseLeader")]
        public virtual ICollection<Soldier> InverseLeader { get; set; }
        
        [Display(Name = "Subunits")]
        public virtual ICollection<Subunit> Subunits { get; set; }
        
        [Display(Name = "Units")]
        public virtual ICollection<Unit> Units { get; set; }
        
        [Display(Name = "Специальности")]
        public virtual List<Occupation> Occupations { get; set; }

        [NotMapped]
        public string Occop { get; set; }
    }
}
