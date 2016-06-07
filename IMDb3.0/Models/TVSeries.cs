using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDb3._0.Models
{
    public class TVSeries
    {
        public int TVSeriesID { get; set; }
        public string PosterUlr { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int NumberSeasons { get; set; }
        public virtual ICollection<Actors> Actors { get; set; }


    }

    public class TVSeriesDBContext : DbContext
    {
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<Actors> Actors { get; set; }
    }
}