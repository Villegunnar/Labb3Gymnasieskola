using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3Gymnasieskola.Models
{
    public partial class TblKurs
    {
        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public int? LärareId { get; set; }

        public virtual TblPersonal Lärare { get; set; }
    }
}
