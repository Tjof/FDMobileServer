using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FDServer
{
    [ApiController]
    [Route("[controller]")]
    
    public class FindRoutesController : Controller
    {
        BAZANOWContext db;
        public FindRoutesController(BAZANOWContext context)
        {
            this.db = context;
        }
    
        [HttpGet]
        public IActionResult Get(int id_grud, int id_ost)
        {
            var parameters = new[]
            {
                new SqlParameter("@id_grud", id_grud),
                new SqlParameter("id_ost", id_ost)
            };
           var routes = db.GetRoutes_Result.FromSqlRaw("[dbo].[GetRoutes] @id_grud, @id_ost", parameters);

            if (routes == null)
                return NotFound();
            return new ObjectResult(routes);
        }
    }
}