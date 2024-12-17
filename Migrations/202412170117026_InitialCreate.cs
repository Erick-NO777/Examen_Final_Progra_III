namespace ConstructoraUH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignacions",
                c => new
                    {
                        IdAsignacion = c.Int(nullable: false, identity: true),
                        CarnetUnico = c.Int(nullable: false),
                        CodigoProyecto = c.Int(nullable: false),
                        FechaAsignacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsignacion)
                .ForeignKey("dbo.Empleadoes", t => t.CarnetUnico, cascadeDelete: true)
                .ForeignKey("dbo.Proyectoes", t => t.CodigoProyecto, cascadeDelete: true)
                .Index(t => t.CarnetUnico)
                .Index(t => t.CodigoProyecto);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        CarnetUnico = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriaLaboral = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CarnetUnico);
            
            CreateTable(
                "dbo.Proyectoes",
                c => new
                    {
                        CodigoProyecto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(),
                    })
                .PrimaryKey(t => t.CodigoProyecto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asignacions", "CodigoProyecto", "dbo.Proyectoes");
            DropForeignKey("dbo.Asignacions", "CarnetUnico", "dbo.Empleadoes");
            DropIndex("dbo.Asignacions", new[] { "CodigoProyecto" });
            DropIndex("dbo.Asignacions", new[] { "CarnetUnico" });
            DropTable("dbo.Proyectoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Asignacions");
        }
    }
}
