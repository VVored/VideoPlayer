using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayer.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public TimeSpan Duration { get; set; }
        public string VideoPath { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public int YearOfCreation { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual string FullVideoPath { get { return AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"), 26) + VideoPath; } }
    }
}
