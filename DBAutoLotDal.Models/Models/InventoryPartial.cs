using DBAutoLotDaL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAutoLotDaL.models
{
    partial class Inventory: EntityBase
    {
        public override string ToString()
        {
            return $"{this.PetName ?? "**No Name**"} is a {this.Color}"+ $" Model { this.Model}"+$" with ID { this.Id}.";
        }
    }
}
