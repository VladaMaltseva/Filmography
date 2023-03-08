using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmography.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string Country { get; set; }
        public int Id_film { get; set; }
    }
}
