using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TallerAPI.API.Models
{
    public class PContext : DbContext
    {
        public PContext(): base("PublicacionConnection")
        {

        }
        public DbSet<Publicacion> Publicaciones { get; set; }
    }
}