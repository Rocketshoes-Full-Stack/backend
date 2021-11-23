using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketShoes.Entity;

namespace RocketShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (LojaContext ctx = new LojaContext())
            {
                return base.Ok(ctx.Enderecos.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Endereco endereco = ctx.Enderecos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (endereco == null)
                    return base.NotFound();

                return base.Ok(endereco);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (LojaContext ctx = new LojaContext())
            {
                Endereco endereco = ctx.Enderecos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (endereco == null)
                    return base.NotFound();

                ctx.Enderecos.Remove(endereco);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Endereco endereco)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Enderecos.Add(endereco);
                ctx.SaveChanges();
            }
            return Ok(endereco);
        }

        [HttpPut]
        public ActionResult Put(Endereco endereco)
        {
            using (LojaContext ctx = new LojaContext())
            {
                ctx.Enderecos.Update(endereco);
                ctx.SaveChanges();
            }
            return Ok(endereco);
        }
    }
}