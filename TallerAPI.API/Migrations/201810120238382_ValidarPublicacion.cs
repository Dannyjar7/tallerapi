namespace TallerAPI.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidarPublicacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publicacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 200),
                        FechaPublicacion = c.DateTime(nullable: false),
                        MeGusta = c.Int(nullable: false),
                        MeDisgusta = c.Int(nullable: false),
                        VecesCompartido = c.Int(nullable: false),
                        EsPrivada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publicacion");
        }
    }
}
