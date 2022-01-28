using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3Gymnasieskola.Models
{
    public partial class TblElev
    {
        public int ElevId { get; set; }
        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Klass { get; set; }
    }
}
