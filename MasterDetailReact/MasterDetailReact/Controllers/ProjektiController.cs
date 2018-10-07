using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterDetailReact.Models.DB;

namespace MasterDetailReact.Controllers
{
    //[Route("api/[controller]")]
    //public class ProjektiController : Controller
    //{
    //    [HttpGet("[action")]
    //    public IEnumerable<Projektit> Projekti()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new Projektit
    //        {

    //            Nimi = Projektit,
    //            Status = Projektit
    //        });
    //    }

        [Route("api/[controller]")]
    public class ProjektiController : Controller
    {
        private HarjoitustietokantaContext db = new HarjoitustietokantaContext();
        public ActionResult Index()
        {

            List<Projektit> plista = new List<Projektit>();
            HarjoitustietokantaContext malli = new HarjoitustietokantaContext();
            try
            {
                List<Projektit> projekti = malli.Projektit.OrderByDescending(Projektit => Projektit.ProjektiId).ToList();
                foreach (Projektit p in projekti)
                {
                    Projektit pro = new Projektit();
                    pro.ProjektiId = p.ProjektiId;
                    pro.Nimi = p.Nimi;
                    pro.Status = p.Status;

                    plista.Add(pro);
                }
                return View(plista);
            }
            finally
            {
                malli.Dispose();
            }
        }
    }
}


//namespace MasterDetailReact.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProjektiController : ControllerBase
//    {
//        private readonly HarjoitustietokantaContext _context;

//        public ProjektiController(HarjoitustietokantaContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Projekti
//        [HttpGet]
//        public IEnumerable<Projektit> GetProjektit()
//        {
//            return _context.Projektit;
//        }

//        // GET: api/Projekti/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProjektit([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var projektit = await _context.Projektit.FindAsync(id);

//            if (projektit == null)
//            {
//                return NotFound();
//            }

//            return Ok(projektit);
//        }

//        // PUT: api/Projekti/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProjektit([FromRoute] int id, [FromBody] Projektit projektit)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != projektit.ProjektiId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(projektit).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ProjektitExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Projekti
//        [HttpPost]
//        public async Task<IActionResult> PostProjektit([FromBody] Projektit projektit)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Projektit.Add(projektit);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetProjektit", new { id = projektit.ProjektiId }, projektit);
//        }

//        // DELETE: api/Projekti/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProjektit([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var projektit = await _context.Projektit.FindAsync(id);
//            if (projektit == null)
//            {
//                return NotFound();
//            }

//            _context.Projektit.Remove(projektit);
//            await _context.SaveChangesAsync();

//            return Ok(projektit);
//        }

//        private bool ProjektitExists(int id)
//        {
//            return _context.Projektit.Any(e => e.ProjektiId == id);
//        }
//    }
//}