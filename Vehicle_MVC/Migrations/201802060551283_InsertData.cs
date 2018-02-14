namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData : DbMigration
    {
        public override void Up()
        {
            // insert Features
            Sql("SET IDENTITY_INSERT [dbo].[Features] ON " +
                "INSERT [dbo].[Features] ([Id], [Name]) VALUES (1, N'Feature1') " +
                "INSERT[dbo].[Features]([Id], [Name]) VALUES(2, N'Feature2') " +
                "INSERT[dbo].[Features]([Id], [Name]) VALUES(3, N'Feature3') " +
                "INSERT[dbo].[Features] ([Id], [Name]) VALUES(4, N'Feature4') " +
                "SET IDENTITY_INSERT [dbo].[Features] OFF ");
            // insert Makes
            Sql("SET IDENTITY_INSERT [dbo].[Makes] ON " +
                "INSERT [dbo].[Makes] ([Id], [Name]) VALUES (1, N'Make1') " +
                "INSERT[dbo].[Makes]([Id], [Name]) VALUES(2, N'Make2') " +
                "INSERT[dbo].[Makes]([Id], [Name]) VALUES(3, N'Make3') " +
                "SET IDENTITY_INSERT [dbo].[Makes] OFF ");
            // insert Models
            Sql("SET IDENTITY_INSERT [dbo].[VehicleModels] ON " +
                "INSERT [dbo].[VehicleModels] ([Id], [MakeId], [Name]) VALUES (1, 1, N'Make1-ModelA') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(2, 1, N'Make1-ModelB') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(3, 1, N'Make1-ModelC') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(4, 2, N'Make2-ModelA') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(5, 2, N'Make2-ModelB') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(6, 2, N'Make2-ModelC') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(7, 3, N'Make3-ModelA') " +
                "INSERT[dbo].[VehicleModels]([Id], [MakeId], [Name]) VALUES(8, 3, N'Make3-ModelB') " +
                "INSERT[dbo].[VehicleModels] ([Id], [MakeId], [Name]) VALUES(9, 3, N'Make3-ModelC') " +
                "SET IDENTITY_INSERT [dbo].[VehicleModels] OFF ");
        }
        
        public override void Down()
        {
        }
    }
}
