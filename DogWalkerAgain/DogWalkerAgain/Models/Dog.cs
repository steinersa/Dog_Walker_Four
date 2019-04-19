using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalkerAgain.Models
{

    public class DogBreedViewModel
    {
        public List<Dog> Dogs;
        public SelectList Breeds;
        public string DogBreed { get; set; }
        public string SearchString { get; set; }
    }
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Spayed/Neutered")]
        public bool SpayedNeutered { get; set; }

        [Display(Name = "Rating")]
        public int? Rating { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}