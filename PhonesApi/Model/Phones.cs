using System.ComponentModel.DataAnnotations;

namespace PhonesApi.Model
{

    public class Phones 
    {
        public int Id  { get; set; }
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public decimal Price { get; set; }
    }
}

