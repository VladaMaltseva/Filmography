using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmography.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year_of_release{ get; set; }
        public int Id_actor { get; set; }
        public int Id_studio { get; set; }

    }
}
