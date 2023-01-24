using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoLInfoSQL.Shared.Models
{
    public partial class GraczeZawodowi
    {
        public GraczeZawodowi()
        {
            GryIdMeczus = new HashSet<Gry>();
        }

        [Required (ErrorMessage = "Nick jest wymagany.")]
        public string Nick { get; set; } = null!;

        [Required (ErrorMessage = "Imię i nazwisko są wymagane.")]
        public string ImieINazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Kraj jest wymagany.")]
        public string Kraj { get; set; } = null!;

        [Required(ErrorMessage = "Rola jest wymagana.")]
        public string Rola { get; set; } = null!;

        [Required(ErrorMessage = "Rezydencja jest wymagana.")]
        public string Rezydencja { get; set; } = null!;
        public string? Zdjecie { get; set; }

        [Required(ErrorMessage = "Data urodzin jest wymagana.")]
        public DateTime? DataUrodzin { get; set; }

        [Required(ErrorMessage = "Id drużyny jest wymagana.")]
        public string? IdDruzyny { get; set; } = null!;


        public string? UlubionyBohater { get; set; }

        public virtual Druzyny? IdDruzynyNavigation { get; set; } = null!;
        public virtual Bohaterowie? UlubionyBohaterNavigation { get; set; }

        public virtual ICollection<Gry>? GryIdMeczus { get; set; }
    }
}
