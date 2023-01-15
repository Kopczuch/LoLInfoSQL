using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Turnieje
    {
        public string NazwaTurnieju { get; set; } = null!;
        public string Rodzaj { get; set; } = null!;
        public DateTime Data { get; set; }
        public short ZajeteMiejsce { get; set; }
        public string OstatniWynik { get; set; } = null!;
        public decimal? Nagroda { get; set; }
        public string DruzynyIdDruzyny { get; set; } = null!;

        public virtual Druzyny DruzynyIdDruzynyNavigation { get; set; } = null!;
    }
}
