namespace A_Contraluz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataanotations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarritoCompras",
                c => new
                    {
                        CarritoCompraId = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                        Modelo = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Single(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarritoCompraId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarritoCompras");
        }
    }
}
