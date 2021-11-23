using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes.Entity;

namespace RocketShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return base.Ok(ctx.Categorias.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Categoria categoria = ctx.Categorias.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    return base.NotFound();

                return base.Ok(categoria);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Categoria categoria = ctx.Categorias.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    return base.NotFound();

                ctx.Categorias.Remove(categoria);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }

        [HttpPut]
        public ActionResult Put(Categoria categoria)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Categorias.Update(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }
    }
}