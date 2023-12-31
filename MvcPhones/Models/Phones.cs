using System.ComponentModel.DataAnnotations;

namespace MvcPhones.Models
{

    public class Phones 
    {
        public int Id  { get; set; }
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal Price { get; set; }
    
        public string? ImageUrl { get; set;}

        public string? Description { get; set;}
    
    }
}