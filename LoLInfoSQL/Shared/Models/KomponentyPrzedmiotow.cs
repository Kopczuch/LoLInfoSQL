using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class KomponentyPrzedmiotow
    {
        public long Id { get; set; }
        public int IdPrzed { get; set; }
        public int IdKomponentu { get; set; }

        public virtual Przedmioty IdKomponentuNavigation { get; set; } = null!;
        public virtual Przedmioty IdPrzedNavigation { get; set; } = null!;
    }
}
