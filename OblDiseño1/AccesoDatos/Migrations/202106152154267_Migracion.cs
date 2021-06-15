namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntidadCategorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(),
                        CredencialId = c.Int(nullable: false),
                        UsuarioNombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioNombre, cascadeDelete: true)
                .Index(t => t.UsuarioNombre);
            
            CreateTable(
                "dbo.EntidadCredencials",
                c => new
                    {
                        CredencialId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        ContraseniaId = c.Int(nullable: false),
                        NombreSitioApp = c.String(),
                        UsuarioGestorNombre = c.String(nullable: false, maxLength: 128),
                        TipoSitioOApp = c.String(),
                        Nota = c.String(),
                        IdCategoria = c.Int(nullable: false),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        Contrasenia_ContraseniaId = c.Int(),
                    })
                .PrimaryKey(t => t.CredencialId)
                .ForeignKey("dbo.EntidadCategorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.EntidadContraseña", t => t.Contrasenia_ContraseniaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioGestorNombre)
                .Index(t => t.UsuarioGestorNombre)
                .Index(t => t.IdCategoria)
                .Index(t => t.Contrasenia_ContraseniaId);
            
            CreateTable(
                "dbo.EntidadContraseña",
                c => new
                    {
                        ContraseniaId = c.Int(nullable: false, identity: true),
                        Contrasenia = c.String(),
                        NivelSeguridadContrasenia = c.Int(nullable: false),
                        CredencialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContraseniaId);
            
            CreateTable(
                "dbo.EntidadUsuarios",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.EntidadTarjetas",
                c => new
                    {
                        TarjetaId = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        UsuarioGestorNombre = c.String(nullable: false, maxLength: 128),
                        NotaOpcional = c.String(),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        UsuarioGestorNombreCategoria = c.String(),
                    })
                .PrimaryKey(t => t.TarjetaId)
                .ForeignKey("dbo.EntidadCategorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioGestorNombre)
                .Index(t => t.UsuarioGestorNombre)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.EntidadDataBreaches",
                c => new
                    {
                        IdDataBrech = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        UsuarioNombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdDataBrech)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioNombre)
                .Index(t => t.UsuarioNombre);
            
            CreateTable(
                "dbo.EntidadDataBrechCredencials",
                c => new
                    {
                        DataBrechId = c.Int(nullable: false),
                        IdCredencial = c.Int(nullable: false),
                        NombreUsuario = c.String(),
                        Contrasenia = c.String(),
                        NombreSitioApp = c.String(),
                        UsuarioGestorNombre = c.String(),
                        Nota = c.String(),
                        Categoria = c.String(),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBrechId, t.IdCredencial })
                .ForeignKey("dbo.EntidadDataBreaches", t => t.DataBrechId, cascadeDelete: true)
                .Index(t => t.DataBrechId);
            
            CreateTable(
                "dbo.EntidadDataBrechTarjetas",
                c => new
                    {
                        DataBrechId = c.Int(nullable: false),
                        TarjetaId = c.Int(nullable: false),
                        Numero = c.String(),
                        UsuarioGestorNombre = c.String(),
                        NotaOpcional = c.String(),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBrechId, t.TarjetaId })
                .ForeignKey("dbo.EntidadDataBreaches", t => t.DataBrechId, cascadeDelete: true)
                .Index(t => t.DataBrechId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntidadDataBreaches", "UsuarioNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadDataBrechTarjetas", "DataBrechId", "dbo.EntidadDataBreaches");
            DropForeignKey("dbo.EntidadDataBrechCredencials", "DataBrechId", "dbo.EntidadDataBreaches");
            DropForeignKey("dbo.EntidadCategorias", "UsuarioNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadCredencials", "UsuarioGestorNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "UsuarioGestorNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "IdCategoria", "dbo.EntidadCategorias");
            DropForeignKey("dbo.EntidadCredencials", "Contrasenia_ContraseniaId", "dbo.EntidadContraseña");
            DropForeignKey("dbo.EntidadCredencials", "IdCategoria", "dbo.EntidadCategorias");
            DropIndex("dbo.EntidadDataBrechTarjetas", new[] { "DataBrechId" });
            DropIndex("dbo.EntidadDataBrechCredencials", new[] { "DataBrechId" });
            DropIndex("dbo.EntidadDataBreaches", new[] { "UsuarioNombre" });
            DropIndex("dbo.EntidadTarjetas", new[] { "IdCategoria" });
            DropIndex("dbo.EntidadTarjetas", new[] { "UsuarioGestorNombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "Contrasenia_ContraseniaId" });
            DropIndex("dbo.EntidadCredencials", new[] { "IdCategoria" });
            DropIndex("dbo.EntidadCredencials", new[] { "UsuarioGestorNombre" });
            DropIndex("dbo.EntidadCategorias", new[] { "UsuarioNombre" });
            DropTable("dbo.EntidadDataBrechTarjetas");
            DropTable("dbo.EntidadDataBrechCredencials");
            DropTable("dbo.EntidadDataBreaches");
            DropTable("dbo.EntidadTarjetas");
            DropTable("dbo.EntidadUsuarios");
            DropTable("dbo.EntidadContraseña");
            DropTable("dbo.EntidadCredencials");
            DropTable("dbo.EntidadCategorias");
        }
    }
}
