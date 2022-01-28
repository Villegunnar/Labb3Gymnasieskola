using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3Gymnasieskola.Models
{
    public partial class TblPersonal
    {
        public TblPersonal()
        {
            TblKurs = new HashSet<TblKurs>();
        }

        public int PersonalId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Befattning { get; set; }

        public virtual ICollection<TblKurs> TblKurs { get; set; }
    }
}
