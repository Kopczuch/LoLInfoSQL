using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public string IdDruzyny { get; set; } = null!;
        [JsonIgnore]
        public virtual Druzyny? DruzynyIdDruzynyNavigation { get; set; } = null!;
    }
}
