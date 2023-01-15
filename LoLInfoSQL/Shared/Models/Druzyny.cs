using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Druzyny
    {
        public Druzyny()
        {
            GraczeZawodowis = new HashSet<GraczeZawodowi>();
            Turniejes = new HashSet<Turnieje>();
        }

        public string IdDruzyny { get; set; } = null!;
        public string Nazwa { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public string Liga { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string? ZdjecieZawodnikow { get; set; }

        public virtual ICollection<GraczeZawodowi> GraczeZawodowis { get; set; }
        public virtual ICollection<Turnieje> Turniejes { get; set; }
    }
}
