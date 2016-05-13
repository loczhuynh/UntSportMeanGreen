using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntSportMeanGreen.Models
{
    public interface ISportRepository
    {
        IQueryable<schedule> GetAllSchedule();
        schedule GetSchedule(int scheduleId);

        IQueryable<category> GetAllSportCategory();
        category GetSportCategory(int categoryId);

        tournament GetSportTournament(int tournamentId);

        bool Insert(schedule entity);

        bool SaveAll();

        bool DeleteSchedule(int id);

        bool Update(schedule originalSchedule, schedule updatedSchedule);
    }
}
