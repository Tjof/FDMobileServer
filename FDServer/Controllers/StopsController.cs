using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FDServer;

namespace FDServer
{
    [Route("[controller]")]
    [ApiController]
    public class StopsController : Controller
    {
        private readonly BAZANOWContext db;

        public StopsController(BAZANOWContext context)
        {
            db = context;
        }

        // GET: Drugs
        [HttpGet]
        public ActionResult Get()
        {
            var stops = db.Остановки.Select(e => new { Название = e.НазваниеОстановки, id = e.IdОстановки });

            if (stops == null)
                return NotFound();
            return new ObjectResult(stops);
        }

        // GET: Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Остановки>> Get(int id)
        {
            var stop = await db.Остановки.FindAsync(id);

            if (stop == null)
            {
                return NotFound();
            }

            return stop;
        }
    }
}
