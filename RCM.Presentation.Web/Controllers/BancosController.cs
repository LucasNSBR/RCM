using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RCM.Application.ViewModels;

namespace RCM.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Bancos")]
    public class BancosController : Controller
    {
        [HttpGet]
        public IEnumerable<BancoViewModel> Get()
        {
            return null;
        }
        
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
