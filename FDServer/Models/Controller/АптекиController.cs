using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FDServer.Models;
 
namespace FDServer.Models.Controllers
{
    [Route("[controller]")]
    
    public class АптекиController : Controller
    {
        BAZANOWContext db;
        public АптекиController(BAZANOWContext context)
        {
            this.db = context;
        }

        // GET аптеки
        [HttpGet]
        public IActionResult Get()
        {
            var drugstores = db.Аптеки.Include("Улицы").Select(s => (new { НазваниеАптеки = s.Название, Улица = s.Улицы.НазваниеУлицы, s.НомерДома, s.ВремяНачалаРаботы, s.ВремяОкончанияРаботы }));

            if (drugstores == null)
                return NotFound();
            return new ObjectResult(drugstores);
        }

        // GET аптеки/id
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            //Аптеки drugstores = db.Аптеки.FirstOrDefault(x => x.IdАптеки == id);
            var drugstores = db.Аптеки.Select(s => (new {Название = s.Название}));

            if (drugstores == null)
                return NotFound();
            return new ObjectResult(drugstores);
        }
    }
}