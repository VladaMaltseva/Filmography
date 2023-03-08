using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmography.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role_type { get; set; }
        public int Id_actor { get; set; }
        public int Id_film { get; set; }
    }
}
