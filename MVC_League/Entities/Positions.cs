using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_League.Entities
{
    public class Positions
    {
        [Key]
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public int Pos { get; set; }
        public int TeamId { get; set; }
        public int LJ { get; set; }
        public int LG { get; set; }
        public int LE { get; set; }
        public int LP { get; set; }
        public int LGF { get; set; }
        public int LGC { get; set; }
        public int LDG { get; set; }
        public int LPts { get; set; }
        public int VJ { get; set; }
        public int VG { get; set; }
        public int VE { get; set; }
        public int VP { get; set; }
        public int VGF { get; set; }
        public int VGC { get; set; }
        public int VDG { get; set; }
        public int VPts { get; set; }
        public int TJ { get; set; }
        public int TG { get; set; }
        public int TE { get; set; }
        public int TP { get; set; }
        public int TGF { get; set; }
        public int TGC { get; set; }
        public int TDG { get; set; }
        public int TPts { get; set; }
    }
}