using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalAPIProject.DAL.Context;
using TraversalAPIProject.DAL.Entities;

namespace TraversalAPIProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var C = new VisitorContext())
            {
                var values = C.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var C = new VisitorContext())
            {
                C.Visitors.Add(visitor);
                C.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using(var C = new VisitorContext())
            {
                var values = C.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var C = new VisitorContext())
            {
                var values = C.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    C.Remove(values);
                    C.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using(var C = new VisitorContext()) 
            {
                var values = C.Visitors.Find(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                { 
                    values.VisitorName = visitor.VisitorName;
                    values.VisitorSurname = visitor.VisitorSurname;
                    values.VisitorCity = visitor.VisitorCity;
                    values.VisitorCountry = visitor.VisitorCountry;
                    values.VisitorMail = visitor.VisitorMail;
                    C.Update(values);
                    C.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
