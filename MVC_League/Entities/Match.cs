using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_League.Entities
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public int FixtureId { get; set; }
        [Required]
        public int TeamIdLocal { get; set; }
        [Required]
        public int GoalsLocal { get; set; }
        [Required]
        public int TeamIdVisitor { get; set; }
        [Required]
        public int GoalsVisitor { get; set; }
        [ForeignKey("FixtureId")]
        public Fixture Fixture { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool Played { get; set; }
    }
}