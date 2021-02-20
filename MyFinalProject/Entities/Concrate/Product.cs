using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock{ get; set; } //16 bit signed integer (intin bir küçüğü)
        public decimal UnitPrice { get; set; }
    }
}
