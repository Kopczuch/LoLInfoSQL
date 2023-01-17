using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoLInfoSQL.Shared.Models
{
    public partial class KomponentyPrzedmiotow
    {
        public long Id { get; set; }
        public int IdPrzed { get; set; }
        public int IdKomponentu { get; set; }

        [JsonIgnore]
        public virtual Przedmioty IdKomponentuNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Przedmioty IdPrzedNavigation { get; set; } = null!;
    }
}
