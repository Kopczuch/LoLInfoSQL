using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Gracze
    {
        public Gracze()
        {
            GryIdMeczus = new HashSet<Gry>();
        }

        public string Nick { get; set; } = null!;
        public string Dywizja { get; set; } = null!;
        public short Poziom { get; set; }
        public string? UlubionyBohater { get; set; }

        public virtual Bohaterowie? UlubionyBohaterNavigation { get; set; }
        public virtual DaneLogowanium DaneLogowanium { get; set; } = null!;

        public virtual ICollection<Gry> GryIdMeczus { get; set; }
    }
}
