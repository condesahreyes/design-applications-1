namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BddD1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntidadCategorias",
                c => new
                    {
                        NombreCategoria = c.String(nullable: false, maxLength: 128),
                        UsuarioNombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NombreCategoria)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioNombre, cascadeDelete: true)
                .Index(t => t.UsuarioNombre);
            
            CreateTable(
                "dbo.EntidadUsuarios",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.EntidadCredencials",
                c => new
                    {
                        CredencialId = c.Int(nullable: false),
                        NombreUsuario = c.String(nullable: false, maxLength: 128),
                        NombreSitioApp = c.String(nullable: false, maxLength: 128),
                        TipoSitioOApp = c.String(),
                        Nota = c.String(),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        Categoria_NombreCategoria = c.String(maxLength: 128),
                        Contrasenia_ContraseñaId = c.Int(),
                        Usuario_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CredencialId, t.NombreUsuario, t.NombreSitioApp })
                .ForeignKey("dbo.EntidadCategorias", t => t.Categoria_NombreCategoria)
                .ForeignKey("dbo.EntidadContraseña", t => t.Contrasenia_ContraseñaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.Usuario_Nombre)
                .Index(t => t.Categoria_NombreCategoria)
                .Index(t => t.Contrasenia_ContraseñaId)
                .Index(t => t.Usuario_Nombre);
            
            CreateTable(
                "dbo.EntidadContraseña",
                c => new
                    {
                        ContraseñaId = c.Int(nullable: false, identity: true),
                        Contrasenia = c.String(),
                        NivelSeguridadContrasenia = c.Int(nullable: false),
                        Usuario_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContraseñaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.Usuario_Nombre)
                .Index(t => t.Usuario_Nombre);
            
            CreateTable(
                "dbo.EntidadTarjetas",
                c => new
                    {
                        Numero = c.Int(nullable: false),
                        EntidadTarjetaId = c.Int(nullable: false),
                        NotaOpcional = c.String(),
                        Nombre = c.String(maxLength: 128),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Categoria_NombreCategoria = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Numero, t.EntidadTarjetaId })
                .ForeignKey("dbo.EntidadCategorias", t => t.Categoria_NombreCategoria)
                .ForeignKey("dbo.EntidadUsuarios", t => t.Nombre)
                .Index(t => t.Nombre)
                .Index(t => t.Categoria_NombreCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntidadCategorias", "UsuarioNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "Nombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "Categoria_NombreCategoria", "dbo.EntidadCategorias");
            DropForeignKey("dbo.EntidadCredencials", "Usuario_Nombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadCredencials", "Contrasenia_ContraseñaId", "dbo.EntidadContraseña");
            DropForeignKey("dbo.EntidadContraseña", "Usuario_Nombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadCredencials", "Categoria_NombreCategoria", "dbo.EntidadCategorias");
            DropIndex("dbo.EntidadTarjetas", new[] { "Categoria_NombreCategoria" });
            DropIndex("dbo.EntidadTarjetas", new[] { "Nombre" });
            DropIndex("dbo.EntidadContraseña", new[] { "Usuario_Nombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "Usuario_Nombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "Contrasenia_ContraseñaId" });
            DropIndex("dbo.EntidadCredencials", new[] { "Categoria_NombreCategoria" });
            DropIndex("dbo.EntidadCategorias", new[] { "UsuarioNombre" });
            DropTable("dbo.EntidadTarjetas");
            DropTable("dbo.EntidadContraseña");
            DropTable("dbo.EntidadCredencials");
            DropTable("dbo.EntidadUsuarios");
            DropTable("dbo.EntidadCategorias");
        }
    }
}
