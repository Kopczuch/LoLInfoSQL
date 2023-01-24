using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoLInfoSQL.Shared.Models
{
    public partial class Przedmioty
    {
        public Przedmioty()
        {
            KomponentyPrzedmiotowIdKomponentuNavigations = new HashSet<KomponentyPrzedmiotow>();
            KomponentyPrzedmiotowIdPrzedNavigations = new HashSet<KomponentyPrzedmiotow>();
        }

        public int IdPrzed { get; set; }

        [Required (ErrorMessage = "Nazwa jest wymagana.")]
        public string Nazwa { get; set; } = null!;

        [Required(ErrorMessage = "Statystyki są wymagane.")]
        public string Statystyki { get; set; } = null!;

        [Required(ErrorMessage = "Ikona jest wymagana.")]
        public string Ikona { get; set; } = null!;

        [Required, Range(0, int.MaxValue, ErrorMessage = "Cena przyjmuje tylko wartości nieujemne.")]
        public short? Cena { get; set; }

        [Required, Range(0, int.MaxValue, ErrorMessage = "Wartość sprzedaży przyjmuje tylko wartości nieujemne.")]
        public short? WartoscSprzedazy { get; set; }

        public virtual ZakupionePrzedmioty? ZakupionePrzedmioty { get; set; } = null!;

        public virtual ICollection<KomponentyPrzedmiotow> KomponentyPrzedmiotowIdKomponentuNavigations { get; set; }
       
        public virtual ICollection<KomponentyPrzedmiotow> KomponentyPrzedmiotowIdPrzedNavigations { get; set; }
    }
}
