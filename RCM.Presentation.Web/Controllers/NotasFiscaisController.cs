using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/NotasFiscais")]
    public class NotasFiscaisController : Controller
    {
        // GET: api/NotasFiscais
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NotasFiscais/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/NotasFiscais
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/NotasFiscais/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
