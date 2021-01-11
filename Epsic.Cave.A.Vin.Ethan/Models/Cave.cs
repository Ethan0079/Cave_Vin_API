using System;
using Epsic.Cave.A.Vin.Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic.Cave.A.Vin.Ethan.Models
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
}