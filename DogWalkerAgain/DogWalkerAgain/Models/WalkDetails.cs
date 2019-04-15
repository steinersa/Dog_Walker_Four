using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogWalkerAgain.Models
{
    public class WalkDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Distance")]
        public double Distance { get; set; }

        [Required]
        [Display(Name = "Number of Dogs")]
        public int NumberOfDogs { get; set; }

        [ForeignKey("Walk")]
        public int WalkId { get; set; }
        public Walk Walk { get; set; }
    }
}