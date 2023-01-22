using System;
using System.Collections.Generic;
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
        public string Nazwa { get; set; } = null!;
        public string Statystyki { get; set; } = null!;
        public string Ikona { get; set; } = null!;
        public short? Cena { get; set; }
        public short? WartoscSprzedazy { get; set; }

        public virtual ZakupionePrzedmioty? ZakupionePrzedmioty { get; set; } = null!;

        public virtual ICollection<KomponentyPrzedmiotow> KomponentyPrzedmiotowIdKomponentuNavigations { get; set; }
       
        public virtual ICollection<KomponentyPrzedmiotow> KomponentyPrzedmiotowIdPrzedNavigations { get; set; }
    }
}
