using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UntSportMeanGreen.Models
{
    public class SportRepository : ISportRepository
    {
        dbuntsportEntities _dbContext;
        public SportRepository(dbuntsportEntities dbContext)
        {
            _dbContext = dbContext;
        }

        //return all sport schedule from DB
        public IQueryable<schedule> GetAllSchedule()
        {
            return _dbContext.schedules.AsQueryable();
        }

        //return specific schedule by id
        public schedule GetSchedule(int scheduleId)
        {
            return _dbContext.schedules.Find(scheduleId);
        }

        //insert new schedule to db
        public bool Insert(schedule entity)
        {
            try
            {
                _dbContext.schedules.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //delete schedule from db
        public bool DeleteSchedule(int scheduleId)
        {
            try
            {
                var entity = _dbContext.schedules.Find(scheduleId);
                if (entity == null)
                    return false;

                _dbContext.schedules.Remove(entity);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        //update schedule
        public bool Update(schedule originalSchedule, schedule updatedSchedule)
        {
            try
            {
                _dbContext.Entry(originalSchedule).CurrentValues.SetValues(updatedSchedule);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool SaveAll()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<category> GetAllSportCategory()
        {
            return _dbContext.categories.AsQueryable();
        }

        public category GetSportCategory(int categoryId)
        {
            return _dbContext.categories.Find(categoryId);
        }

        public tournament GetSportTournament(int tournamentId)
        {
            return _dbContext.tournaments.Find(tournamentId);
        }
    }
}