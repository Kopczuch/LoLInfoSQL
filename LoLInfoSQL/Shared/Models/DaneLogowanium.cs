using System;
using System.Collections.Generic;

namespace LoLInfoSQL.Shared.Models
{
    public partial class DaneLogowanium
    {
        public string Nick { get; set; } = null!;
        public string Haslo { get; set; } = null!;
        public DateTime DataOstatniegoZalogowania { get; set; }

        public virtual Gracze NickNavigation { get; set; } = null!;
    }
}
