using Epsic.Cave.A.Vin.Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic.Cave.A.Vin.Ethan.Models
{
    // [ClassPointsValidator]
    public class User
    {
        public int Id { get; set; }
        // [Required]
        // [StringLength(15)]
        public string Name { get; set; }
        public int Age { get; set; }
        public TypeUser Type { get; set; }
        
    }
}