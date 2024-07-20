using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayer.Model
{
    public class Director
    {
        public Director()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public virtual List<Movie> Movies { get; set;}
    }
}
