using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogWalkerAgain.Models
{
    public class Walk
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Walker's Status")]
        public string WalkerApprovalStatus { get; set; }

        [Display(Name = "Owners's Status")]
        public string OwnersApprovalStatus { get; set; }

        [Display(Name = "Walk's Status")]
        public bool WalkComplete { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("Walker")]
        public int ? WalkerId { get; set; }
        public Walker Walker { get; set; }
    }
}