using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3Gymnasieskola.Models
{
    public partial class TblBetyg
    {
        public string Betyg { get; set; }
        public int? ElevId { get; set; }
        public int? KursId { get; set; }
        public int? LärareId { get; set; }
        public DateTime? Datum { get; set; }

        public virtual TblElev Elev { get; set; }
        public virtual TblKurs Kurs { get; set; }
        public virtual TblPersonal Lärare { get; set; }
    }
}
