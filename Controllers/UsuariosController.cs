using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes.Entity;

namespace RocketShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return base.Ok(ctx.Usuarios.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Usuario Usuario = ctx.Usuarios.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (Usuario == null)
                    return base.NotFound();

                return base.Ok(Usuario);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Usuario Usuario = ctx.Usuarios.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (Usuario == null)
                    return base.NotFound();

                ctx.Usuarios.Remove(Usuario);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Usuario Usuario)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Usuarios.Add(Usuario);
                ctx.SaveChanges();
            }
            return Ok(Usuario);
        }

        [HttpPut]
        public ActionResult Put(Usuario Usuario)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Usuarios.Update(Usuario);
                ctx.SaveChanges();
            }
            return Ok(Usuario);
        }
    }
}
