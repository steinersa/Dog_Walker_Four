using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogWalkerAgain.Models
{
    public class Health
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Heart Condition")]
        public bool HeartCondition { get; set; }

        [Required]
        [Display(Name = "Seizure Condition")]
        public bool SeizureCondition { get; set; }

        [Required]
        [Display(Name = "Allergies")]
        public bool Allergies { get; set; }

        [Required]
        [Display(Name = "Blind")]
        public bool Blind { get; set; }

        [Required]
        [Display(Name = "Deaf")]
        public bool Deaf { get; set; }

        [Required]
        [Display(Name = "Physical Limitations")]
        public bool PhysicalLimitations { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}