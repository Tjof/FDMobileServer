using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FDServer.Models;
 
namespace FDServer.Models.Controllers
{
    [Route("api/[controller]")]
    public class АптекиController : Controller
    {
        BAZANOWContext db;
        public АптекиController(BAZANOWContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Аптеки> Get()
        {
            return db.Аптеки.ToList();
        }

        // GET api/аптеки
        [HttpGet("{id}")]
        public IActionResult Get(string na)
        {
            Аптеки drugstores = db.Аптеки.FirstOrDefault(x => x.Название == na);
            if (drugstores == null)
                return NotFound();
            return new ObjectResult(drugstores);
        }
    }
}