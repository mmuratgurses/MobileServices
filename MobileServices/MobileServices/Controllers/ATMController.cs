using ATMDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileServices.Controllers
{
    public class ATMController : ApiController
    {
        [Route("api/GetProblems")]
        [System.Web.Http.HttpGet]
        public IEnumerable<PROBLEM_MANAGEMENT> Get() 
        {
            using (ATMEntities entities = new ATMEntities()) 
            {
                return entities.PROBLEM_MANAGEMENT.ToList();
            }
        }

        [Route("api/GetProblem")]
        [System.Web.Http.HttpGet]
        public List<PROBLEM_MANAGEMENT> Get([FromBody] Parameters parameters)
        {
            using (ATMEntities entities = new ATMEntities())
            {
                return entities.PROBLEM_MANAGEMENT.Where(p => p.TERMINAL_ID==parameters.TerminalID && p.PROBLEM_START_TIME>=DateTime.Now ).ToList() ;
            }
        }

    }

    public class Parameters
    {
        public int Day { get; set; }
        public string TerminalID { get; set; }
    }
}
