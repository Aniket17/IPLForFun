using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPLForFun.Models
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }
        [Required]
        [ForeignKey("HostTeamId")]
        public virtual Team Host { get; set; }
        [Required]
        [ForeignKey("GuestTeamId")]
        public virtual Team Guest { get; set; }
        public int HostTeamId { get; set; }
        public int GuestTeamId { get; set; }

        [NotMapped]
        public string MatchDescription
        {
            get
            {
                return Host.Code + " vs " + Guest.Code;
            }
        }

        public bool IsApproved { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}