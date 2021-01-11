using System;
using Epsic.Cave.A.Vin.Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic.Cave.A.Vin.Ethan.Models
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TypeVin Typevin { get; set; }
        
        [Required]
        public User Owner { get; set; }

        [Required]
        public Cave Cave { get; set; }
    }
    public class CreateBottleDto {

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TypeVin Typevin { get; set; }
        
        public User Owner { get; set; }
        public Cave Cave { get; set; }
    }

        public class UpdateBottleDto {

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TypeVin Typevin { get; set; }
        
        public User Owner { get; set; }
        public Cave Cave { get; set; }
    }
    public class BottleDetailViewModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TypeVin Typevin { get; set; }
        
        public User Owner { get; set; }
        public Cave Cave { get; set; }
    }
    public class BottleSummaryViewModel {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
    
}