using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Gracze
    {
        public Gracze()
        {
            GryIdMeczus = new HashSet<Gry>();
        }

        [Required]
        public string Nick { get; set; } = null!;

        [Required (ErrorMessage = "Dywizja jest wymagana.")]
        public string Dywizja { get; set; } = null!;

        [Required, Range(1, short.MaxValue, ErrorMessage = "Poziom jest wymagany.")]
        public short Poziom { get; set; }

        public string? UlubionyBohater { get; set; }

        public virtual Bohaterowie? UlubionyBohaterNavigation { get; set; }
        public virtual DaneLogowanium DaneLogowanium { get; set; } = null!;

        public virtual ICollection<Gry> GryIdMeczus { get; set; }
    }
}
