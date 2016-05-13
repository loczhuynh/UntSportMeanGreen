using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UntSportMeanGreen.Models;

namespace UntSportMeanGreen.Controllers
{
    public class ScheduleController : BaseApiController    {

        public ScheduleController(ISportRepository repo)
            : base(repo) 
        { 
        }

        // GET api/schedule
        public IEnumerable<ScheduleModel> Get()
        {
            //ISportRepository repository = new SportRepository(new dbuntsportEntities());
            //var result = repository.GetAllSchedule().ToList();
            //return result;
            IQueryable<schedule> query;
            query = TheRepository.GetAllSchedule();
            var result = query.ToList().Select(c => TheModelFactory.Create(c));

            return result;
        }

        // GET api/schedule/5
        public HttpResponseMessage Get(int id)
        {
            //ISportRepository repository = new SportRepository(new dbuntsportEntities());
            //return repository.GetSchedule(scheduleId);
            try
            {
                var mySchedule = TheRepository.GetSchedule(id);
                if (mySchedule != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(mySchedule));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/schedule
        public HttpResponseMessage Post([FromBody] ScheduleModel scheduleModel)
        {
            try
            {
                var entity = TheModelFactory.Parse(scheduleModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read schedule from body");

                if (TheRepository.Insert(entity) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/schedule/5
        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] ScheduleModel scheduleModel)   
        {
            try
            {

                var updatedSchedule = TheModelFactory.Parse(scheduleModel);
                

                if (updatedSchedule == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read schedule from body");

                var originalSchedule = TheRepository.GetSchedule(id);

                if (originalSchedule == null || originalSchedule.ScheduleId != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Schedule is not found");
                }
                else
                {
                    updatedSchedule.ScheduleId = id;
                }

                if (TheRepository.Update(originalSchedule, updatedSchedule) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedSchedule));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/schedule/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var schedule = TheRepository.GetSchedule(id);

                if (schedule == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (TheRepository.DeleteSchedule(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
