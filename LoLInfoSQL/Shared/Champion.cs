using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LoLInfoSQL.Shared
{
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Role? Role { get; set; }
        public int RoleId { get; set; }

        public int Attack { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int Magic { get; set; } = 0;
        public int Difficulty { get; set; }

        public string Image { get; set; } = string.Empty;


    }
}
