using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UntSportMeanGreen.Models;

namespace UntSportMeanGreen.Controllers
{
    
    public class BaseApiController : ApiController
    {
        //implement DI Constructor Injection Pattern
        private ISportRepository _repo;
        public BaseApiController(ISportRepository repo)
        {
            _repo = repo;
        }

        protected ISportRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        //implement Model Factory
        private ModelFactory _modelFactory;
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request, _repo);
                }
                return _modelFactory;
            }
        }
    }
}
