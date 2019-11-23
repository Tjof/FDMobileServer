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
    public class DrugsController : Controller
    {
        private readonly BAZANOWContext db;

        public DrugsController(BAZANOWContext context)
        {
            db = context;
        }

        // GET: Drugs
        [HttpGet]
        public ActionResult Get()
        {
            var drugs = db.Лекарство.Select(e=>new { Название = e.НазваниеЛекарства, id = e.IdЛекарство });

            if (drugs == null)
                return NotFound();
            return new ObjectResult(drugs);
        }

        // GET: Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Лекарство>> Get(int id)
        {
            var drug = await db.Лекарство.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }
    }
}
