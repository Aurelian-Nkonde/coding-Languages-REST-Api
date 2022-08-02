using System;
using System.ComponentModel.DataAnnotations;


namespace codingLanguages.Models
{
    public class Language
    {
        [Key]
        public int Id {get;set;}
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(60)]
        public string? Name {get;set;}
        [Required(ErrorMessage = "Platform is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string? Platform {get;set;}
        [Required(ErrorMessage = "Uses is required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Uses {get;set;}
    }
}