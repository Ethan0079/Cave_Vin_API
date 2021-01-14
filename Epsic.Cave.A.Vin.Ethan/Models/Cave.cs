using System;
using Epsic_Cave_A_Vin_Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic_Cave_A_Vin_Ethan.Models
{
    public class Cave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Degree { get; set; }
        
    }
    public class CreateCaveDto {
       public int Id { get; set; }
       public string Location { get; set; }
       public int Degree { get; set; }
    }
    public class UpdateCaveDto {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Degree { get; set; }
    }
    public class CaveSummaryViewModel {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Degree { get; set; }
    }
}