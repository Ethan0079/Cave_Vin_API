using Epsic.Cave.A.Vin.Ethan.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Epsic.Cave.A.Vin.Ethan.Models
{

    public class Bottle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public TypeVin Type { get; set; }
        
    }
}