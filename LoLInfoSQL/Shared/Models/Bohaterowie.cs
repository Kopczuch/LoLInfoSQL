using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required (ErrorMessage = "Nazwa jest wymagana.")]
        public string? Nazwa { get; set; } = null!;

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        public string Tytuł { get; set; } = null!;

        [Required (ErrorMessage = "Opis jest wymagany.")]
        public string KrotkiOpis { get; set; } = null!;

        [Required, Range(0, 10, ErrorMessage="Atak przyjmuje wartości od 0 do 10.")]
        public int Atak { get; set; }

        [Required, Range(0, 10, ErrorMessage = "Obrona przyjmuje wartości od 0 do 10.")]
        public int Obrona { get; set; }

        [Required, Range(0, 10, ErrorMessage = "Magia przyjmuje wartości od 0 do 10.")]
        public int Magia { get; set; }

        [Required, Range(0, 10, ErrorMessage = "Trudność przyjmuje wartości od 0 do 10.")]
        public int Trudnosc { get; set; }

        [Required(ErrorMessage = "Obraz jest wymagany.")]
        public string Obraz { get; set; } = null!;

        [Required(ErrorMessage = "Ikona jest wymagana.")]
        public string Ikona { get; set; } = null!;

        [Required (ErrorMessage = "Klasa jest wymagana.")]
        public string Klasa { get; set; } = null!;

        [JsonIgnore]
        public virtual Gry? Gry { get; set; } = null!;
        public virtual ICollection<GraczeZawodowi> GraczeZawodowis { get; set; }
        public virtual ICollection<Gracze> Graczes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Bohaterowie> Bohaters { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Bohaterowie>? Kontras { get; set; }
    }
}
