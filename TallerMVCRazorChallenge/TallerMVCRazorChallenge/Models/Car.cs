using System;
using System.ComponentModel.DataAnnotations;

namespace TallerMVCRazorChallenge.Models
{
    public class Car
    {
        public Int32 Id { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Make required and the length can't must be more than {1} .")]
        public String Make { get; set; }
        [Required]
        [StringLength(10)]
        public String Model { get; set; }
        [Required]
        [StringLength(4)]
        public Int32 Year { get; set; }
        [Required]
        [StringLength(10)]
        public Int32 Doors { get; set; }
        [Required]
        public String Color { get; set; }
        [Required]
        public Int32 Price { get; set; }
    }
}
