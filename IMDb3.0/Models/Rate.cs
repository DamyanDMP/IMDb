using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb3._0.Models
{
    public class Rate
    {
        public int RateID { get; set; }
        public int Vote { get; set; }
        public int VotesCount { get; set; }
        public double Rating { get; set; }
        public int UserID { get; set; }
        public int TVSeriesID { get; set; }
    }
}