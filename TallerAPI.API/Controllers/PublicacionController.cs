using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TallerAPI.API.Models;

namespace TallerAPI.API.Controllers
{
    public class PublicacionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Publicacion> Get()
        {
            using (var context = new PContext())
            {
                var a = context.Publicaciones.ToList();
                return a;
            }
        }

        [HttpGet]
        public Publicacion Get(int id)
        {
            using (var context = new PContext())
            {
                return context.Publicaciones.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Publicacion publicacion)
        {

            using (var context = new PContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges();
                return Ok(publicacion);
            }
        }

        [HttpPut]
        public Publicacion Put(Publicacion publicacion)
        {
            using (var context = new PContext())
            {
                var publicacionActualizar = context.Publicaciones.FirstOrDefault(x => x.Id == publicacion.Id);
                publicacionActualizar.Usuario = publicacion.Usuario;
                publicacionActualizar.Descripcion = publicacion.Descripcion;
                publicacionActualizar.FechaPublicacion = publicacion.FechaPublicacion;
                publicacionActualizar.MeGusta = publicacion.MeGusta;
                publicacionActualizar.MeDisgusta = publicacion.MeDisgusta;
                publicacionActualizar.VecesCompartido = publicacion.VecesCompartido;
                publicacionActualizar.EsPrivada = publicacion.EsPrivada;
                context.SaveChanges();
                return publicacion;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new PContext())
            {
                var publicacionEliminar = context.Publicaciones.FirstOrDefault(x => x.Id == id);
                context.Publicaciones.Remove(publicacionEliminar);
                context.SaveChanges();
                return true;
            }
        }

        private List<Publicacion> publicacions()
        {
            var listado = new List<Publicacion>();
            listado.Add(new Publicacion { Id = 1, Usuario = "nombredelusuario", Descripcion = "descripcionsobrelapublicacion", MeGusta = 15, MeDisgusta = 5, VecesCompartido = 10, EsPrivada = true });


            return listado;
        }
    }
}
