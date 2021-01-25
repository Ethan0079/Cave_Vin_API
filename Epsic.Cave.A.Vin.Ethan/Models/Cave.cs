
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
        public string ImageUrl { get; set; }
    }

    public class CreateCaveDto {
       public int Id { get; set; }
       public string Location { get; set; }
       public int Degree { get; set; }
       public string ImageUrl { get; set; }
    }

    public class UpdateCaveDto {
        public string Location { get; set; }
        public int Degree { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CaveSummaryViewModel {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Degree { get; set; }
        public string ImageUrl { get; set; }
    }
}