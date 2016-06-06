using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace IMDb3._0.Models
{
    public class Actors
    {
        public int ActorsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string LinkUrl { get; set; }
        public int TVSeriesID { get; set; }
        public virtual TVSeries TVSeries { get; set; }
    }
}
