using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class ZakupionePrzedmioty
    {
        public ZakupionePrzedmioty()
        {
            IdMeczus = new HashSet<Gry>();
        }

        public long Id { get; set; }
        public int IdPrzed { get; set; }

        public virtual Przedmioty IdPrzedNavigation { get; set; } = null!;

        public virtual ICollection<Gry> IdMeczus { get; set; }
    }
}
