using System;
using System.Collections.Generic;

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
        public short Cs { get; set; }
        public int ZdobyteZloto { get; set; }
        public DateTime CzasGry { get; set; }
        public decimal ZadaneObrazenia { get; set; }
        public short? ZabojstwaDruzyny { get; set; }
        public short? ZgonyDruzyny { get; set; }
        public string? Strona { get; set; }
        public string BohaterowieNazwa { get; set; } = null!;

        public virtual Bohaterowie BohaterowieNazwaNavigation { get; set; } = null!;

        public virtual ICollection<Gracze> GraczeNicks { get; set; }
        public virtual ICollection<GraczeZawodowi> GraczeZawodowiNicks { get; set; }
        public virtual ICollection<ZakupionePrzedmioty> IdZakupionegoPrzedmiotus { get; set; }
    }
}
