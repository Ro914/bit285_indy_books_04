using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        IndyBooksDataContext _idbc;

        public WriterController(IndyBooksDataContext db){ _idbc = db;}

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var writers = _idbc.Writers;
            Json(writers);
            return Json(writers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Writer writer = _idbc.Writers.SingleOrDefault(w => w.Id == id);
            if (writer == null)
            {
                return NotFound();
            }
            else
                return Json(writer);
  
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Writer writer)
        {
            _idbc.Writers.Add(writer);
            _idbc.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Writer value)
        {
            Writer writer = _idbc.Writers.Find(id);
            if (writer == null)
            {
                return NotFound();
            }
            else
            {
                writer.Name = value.Name;
                _idbc.Update(writer);
                _idbc.SaveChanges();
                return (Ok());
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
