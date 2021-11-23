using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes.Entity;

namespace RocketShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return Ok(ctx.Compras.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Compra Compra = ctx.Compras.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (Compra == null)
                    return base.NotFound();

                return base.Ok(Compra);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Compra Compra = ctx.Compras.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (Compra == null)
                    return base.NotFound();

                ctx.Compras.Remove(Compra);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Compra Compra)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Compras.Add(Compra);
                ctx.SaveChanges();
            }
            return Ok(Compra);
        }

        [HttpPut]
        public ActionResult Put(Compra Compra)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Compras.Update(Compra);
                ctx.SaveChanges();
            }
            return Ok(Compra);
        }
    }
}
