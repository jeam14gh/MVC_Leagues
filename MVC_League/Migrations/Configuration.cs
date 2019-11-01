namespace MVC_League.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_League.Models.Data.ChampionshipContext>
    {
        public Configuration()
        {
            // Si está en true, permite actualizar la BD cuando hay cambios hechos en las entidades (modelos)
            AutomaticMigrationsEnabled = true;
            // PM> update-database, esto indica que permite hacer cambios automaticos en la BD y modifique sus datos. Puede provocar datos corructos
            //AutomaticMigrationDataLossAllowed = true; 

            //PM > Update-database -force, esta seria la mejor opcion para actualizar la estructura en base de datos.
        }

        protected override void Seed(MVC_League.Models.Data.ChampionshipContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
