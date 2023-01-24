using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Druzyny
    {
        public Druzyny()
        {
            GraczeZawodowis = new HashSet<GraczeZawodowi>();
            Turniejes = new HashSet<Turnieje>();
        }

        [Required (ErrorMessage = "ID jest wymagane.")]
        public string IdDruzyny { get; set; } = null!;

        [Required (ErrorMessage = "Nazwa jest wymagana.")]
        public string Nazwa { get; set; } = null!;

        [Required (ErrorMessage = "Opis jest wymagany.")]
        public string Opis { get; set; } = null!;

        [Required (ErrorMessage = "Liga jest wymagana.")]
        public string Liga { get; set; } = null!;

        [Required(ErrorMessage = "Logo jest wymagane.")]
        public string Logo { get; set; } = null!;


        public string? ZdjecieZawodnikow { get; set; }

        [JsonIgnore]
        public virtual ICollection<GraczeZawodowi> GraczeZawodowis { get; set; }
        public virtual ICollection<Turnieje> Turniejes { get; set; }
    }
}
