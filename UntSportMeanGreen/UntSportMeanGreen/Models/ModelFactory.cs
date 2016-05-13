using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace UntSportMeanGreen.Models
{
    public class ModelFactory
    {
        //used for getting URL from client request
        private System.Web.Http.Routing.UrlHelper _UrlHelper;
        private ISportRepository _repo;
        public ModelFactory(HttpRequestMessage request, ISportRepository repo)
        {
            _UrlHelper = new System.Web.Http.Routing.UrlHelper(request);
            _repo = repo;
        }

        public ScheduleModel Create(schedule s)
        {
            return new ScheduleModel()
            {
                Url = _UrlHelper.Link("Schedule", new {ScheduleId = s.ScheduleId}),
                ScheduleId = s.ScheduleId,
                CategoryId = s.CategoryId,
                Category = Create(s.category),
                Tournament = Create(s.tournament),
                Date = s.Date,
                TournamentId = s.TournamentId,
                Description = s.Description,
                Location = s.Location,
                Event = s.Event,
                Season = s.Season,
                Result = s.Result,
                Opponent = s.Opponent,
                Time = s.Time,
            };
        }

        public CategoryModel Create(category c)
        {
            return new CategoryModel()
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            };
        }

        public TournamentModel Create(tournament t)
        {
            return new TournamentModel()
            {
                TournamentId = t.TournamentId,
                Name = t.Name
            };
        }

        internal schedule Parse(ScheduleModel scheduleModel)
        {
            schedule s = new schedule();
            s.CategoryId = scheduleModel.CategoryId;
            s.Date = scheduleModel.Date;
            s.Description = scheduleModel.Description;
            s.Event = scheduleModel.Event;
            s.Location = scheduleModel.Location;
            s.Opponent = scheduleModel.Opponent;
            s.Result = scheduleModel.Result;
            s.Season = scheduleModel.Season;
            s.Time = scheduleModel.Time;
            s.TournamentId = scheduleModel.TournamentId;
            s.category = _repo.GetSportCategory((int)scheduleModel.CategoryId);
            s.tournament = _repo.GetSportTournament((int)scheduleModel.TournamentId);
            return s;
        }
    }
}