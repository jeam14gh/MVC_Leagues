using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_League.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Display(Name ="Equipo")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Name { get; set; }
        
        [Display(Name = "Liga")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int LeagueId { get; set; }
        [ForeignKey("LeagueId")]        
        public League League { get; set; }
    }
}