using System;
using System.ComponentModel.DataAnnotations;
namespace Domowe1.Models
{
    public class Draw
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data ważności")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}