using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAutoLotDaL.EF;
using System.Data.Entity;
using DBAutoLotDaL;
using DBAutoLotDaL.models;
using DBAutoLotDaL.Repos;
using System.Runtime.Remoting.Contexts;

namespace AutoLotTestDrive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MyDatalnitializer());
            using (var context =new BaseRepo<Inventory>())
            {
                foreach(var c in context.GetAll())
                {
                    Console.WriteLine(c);
                }
                context.Add(new Inventory { Model = "Honda", Color="Black", PetName = "Civic" });
                foreach (var c in context.GetAll())
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadKey();
        }
    }

    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll()
        {
            return context.Inventory.OrderBy(x => x.PetName).ToList();
        }
        private static void AddNewRecord(Inventory car)
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }

        private static void UpdateRecord(int carld)
        {
            using (var repo = new InventoryRepo())
            {
                // Извлечь запись об автомобиле, изменить ее и сохранить.
                var carToUpdate = repo.GetOne(carld);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }
        private static void RemoveRecordByld(int carld, byte[] timestamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carld, timestamp);
            }
        }
    }
}
