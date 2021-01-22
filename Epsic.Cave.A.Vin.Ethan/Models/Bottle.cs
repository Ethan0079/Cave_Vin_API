using System;
using Epsic_Cave_A_Vin_Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic_Cave_A_Vin_Ethan.Models
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
        public int Amount { get; set; }   
        [Required]
        public int PricePerBottle { get; set; }
        [Required]
        public TypeVin Typevin { get; set; }
        public User Owner { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Cave Cave { get; set; }
        [Required]
        public int CaveId { get; set; }
        public string ImageUrl { get; set; }
    }
    public class CreateBottleDto {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TypeVin Typevin { get; set; }
        public int Amount { get; set; }
        public int PricePerBottle { get; set; }   
        public int OwnerId { get; set; }
        public int CaveId { get; set; }
        public string ImageUrl { get; set; }
    }

        public class UpdateBottleDto {
            public string Name { get; set; }

            public DateTime Date { get; set; }
            public TypeVin Typevin { get; set; }
            public int Amount { get; set; }
            public int PricePerBottle { get; set; }
            public int OwnerId { get; set; }
            public int CaveId { get; set; }
            public string ImageUrl { get; set; }
    }
    public class BottleDetailViewModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TypeVin Typevin { get; set; }
        public int Amount { get; set; }
        public int PricePerBottle { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }
        public Cave Cave { get; set; }
        public int CaveId { get; set; }
        public string ImageUrl { get; set; }
    }
    public class BottleSummaryViewModel {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int PricePerBottle { get; set; }
        public string ImageUrl { get; set; }
    }
    
}