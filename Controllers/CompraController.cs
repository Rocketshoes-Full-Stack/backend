using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes.Entity;

namespace RocketShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return base.Ok(ctx.Compras.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Compra compra = ctx.Compras.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (compra == null)
                    return base.NotFound();

                return base.Ok(compra);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Compra compra = ctx.Compras.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (compra == null)
                    return base.NotFound();

                ctx.Compras.Remove(compra);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Compra compra)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Compras.Add(compra);
                ctx.SaveChanges();
            }
            return Ok(compra);
        }

        [HttpPut]
        public ActionResult Put(Compra compra)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Compras.Update(compra);
                ctx.SaveChanges();
            }
            return Ok(compra);
        }
    }
}