using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UntSportMeanGreen.Models
{
    public class ScheduleModel
    {
        public string Url { get; set; }
        public long ScheduleId { get; set; }
        public long CategoryId { get; set; }
        public int TournamentId { get; set; }
        public string Opponent { get; set; }
        public string Location { get; set; }
        public string Result { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Event { get; set; }
        public string Season { get; set; }
        public string Description { get; set; }
        public CategoryModel Category {get; set;}
        public TournamentModel Tournament { get; set; }
    }

    public class CategoryModel
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class TournamentModel
    {
        public long TournamentId { get; set; }
        public string Name { get; set; }
    }
}