using DBAutoLotDaL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAutoLotDaL.models
{
     partial class Order: EntityBase
    {
        public override string ToString()
        {
            return $"Order ->{this.Id}.";
        }
    }
}
