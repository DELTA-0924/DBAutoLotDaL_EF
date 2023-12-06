using DBAutoLotDaL.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
namespace DBAutoLotDaL.EF
{
    public class MyDatalnitializer:DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var customers = new List<Customer>
    {
        new Customer { FirstName = "Dave", LastName = "Brenner" },
        new Customer { FirstName = "Matt", LastName = "Walton" },
        new Customer { FirstName = "Steve", LastName = "Hagen" },
        new Customer { FirstName = "Pat", LastName = "Walton" },
        new Customer { FirstName = "Bad", LastName = "Customer" }
    };
            customers.ForEach(customer =>
            {
                context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, customer);
            });

            var cars = new List<Inventory>
    {
        new Inventory { Model = "VW", Color = "Black", PetName = "Zippy" },
        new Inventory { Model = "Ford", Color = "Rust", PetName = "Rusty" },
        new Inventory { Model = "Saab", Color = "Black", PetName = "Mel" },
        new Inventory { Model = "Yugo", Color = "Yellow", PetName = "Clunker" },
        new Inventory { Model = "BMW", Color = "Black", PetName = "Bimmer" },
        new Inventory { Model = "BMW", Color = "Green", PetName = "Hank" },
        new Inventory { Model = "BMW", Color = "Pink", PetName = "Pinky" },
        new Inventory { Model = "Pinto", Color = "Black", PetName = "Pete" },
        new Inventory { Model = "Yugo", Color = "Brown", PetName = "Brownie" }
    };

            context.Inventory.AddOrUpdate(c => new { c.Model, c.Color }, cars.ToArray());

            var orders = new List<Order>
    {
        new Order { Inventory = cars[0], Customer = customers[0] },
        new Order { Inventory = cars[1], Customer = customers[1] },
        new Order { Inventory = cars[2], Customer = customers[2] },
        new Order { Inventory = cars[3], Customer = customers[3] }
    };

            context.Orders.AddOrUpdate(o => new { o.CarId, o.Id }, orders.ToArray());

            var creditRisk = new CreditsRisk
            {
                Id = customers[4].Id,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName
            };

            context.CreditsRisks.AddOrUpdate(c => new { c.FirstName, c.LastName }, creditRisk);

            context.SaveChanges();
        }

    }
}
