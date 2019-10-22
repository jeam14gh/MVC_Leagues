using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_League.Entities
{
    public class League
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Display(Name = "Liga")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Name { get; set; }

        public List<Team> Teams { get; set; }
    }
}