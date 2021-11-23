using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes;
using RocketShoes.Entity;

namespace Aereo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioMasterController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return base.Ok(ctx.UsuariosMaster.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                UsuarioMaster usuarioMaster = ctx.UsuariosMaster.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return base.NotFound();

                return base.Ok(usuarioMaster);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                UsuarioMaster usuarioMaster = ctx.UsuariosMaster.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return base.NotFound();

                ctx.UsuariosMaster.Remove(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(UsuarioMaster usuarioMaster)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.UsuariosMaster.Add(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok(usuarioMaster);
        }

        [HttpPut]
        public ActionResult Put(UsuarioMaster usuarioMaster)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.UsuariosMaster.Update(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok(usuarioMaster);
        }
    }
}