using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_League.Entities
{
    public class Fixture
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Fecha N°")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int NFixture { get; set; }
        
        [Display(Name = "Temporada")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Season { get; set; }

        [Display(Name = "Liga")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int LeagueId { get; set; }
        public List<MVC_League.Entities.Match> Matches { get; set; }
    }
}