using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Bohaterowie
    {
        public Bohaterowie()
        {
            GraczeZawodowis = new HashSet<GraczeZawodowi>();
            Graczes = new HashSet<Gracze>();
            Bohaters = new HashSet<Bohaterowie>();
            Kontras = new HashSet<Bohaterowie>();
        }

        public string Nazwa { get; set; } = null!;
        public string Tytuł { get; set; } = null!;
        public string KrotkiOpis { get; set; } = null!;
        public sbyte Atak { get; set; }
        public sbyte Obrona { get; set; }
        public sbyte Magia { get; set; }
        public sbyte Trudnosc { get; set; }
        public string Obraz { get; set; } = null!;
        public string Ikona { get; set; } = null!;
        public string Klasa { get; set; } = null!;

        public virtual Gry Gry { get; set; } = null!;
        public virtual ICollection<GraczeZawodowi> GraczeZawodowis { get; set; }
        public virtual ICollection<Gracze> Graczes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Bohaterowie> Bohaters { get; set; }
     
        public virtual ICollection<Bohaterowie> Kontras { get; set; }
    }
}
