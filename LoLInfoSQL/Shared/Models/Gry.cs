using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Gry
    {
        public Gry()
        {
            GraczeNicks = new HashSet<Gracze>();
            GraczeZawodowiNicks = new HashSet<GraczeZawodowi>();
            IdZakupionegoPrzedmiotus = new HashSet<ZakupionePrzedmioty>();
        }

        public long IdMeczu { get; set; }
        public string Rezultat { get; set; } = null!;
        public sbyte Zabojstwa { get; set; }
        public sbyte Smierci { get; set; }
        public sbyte Asysty { get; set; }
        public short Creep_score { get; set; }
        public int ZdobyteZloto { get; set; }
        public TimeSpan CzasGry { get; set; }
        public int ZadaneObrazenia { get; set; }
        public short? ZabojstwaDruzyny { get; set; }
        public short? ZgonyDruzyny { get; set; }
        public string? Strona { get; set; }
        public string BohaterowieNazwa { get; set; } = null!;

        
        public virtual Bohaterowie? BohaterowieNazwaNavigation { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Gracze> GraczeNicks { get; set; }
        [JsonIgnore]
        public virtual ICollection<GraczeZawodowi> GraczeZawodowiNicks { get; set; }
        public virtual ICollection<ZakupionePrzedmioty> IdZakupionegoPrzedmiotus { get; set; }
    }
}
