using Core.Entities; 
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        //public  Buffer classa diger katmanlarda erisebilsin demek 
        //internal ise  sadece entities erisebilir demek
        //Access urune ulsabilsin 
        //Business urunu kontrol edecek 
        //Console urunu gosterecek 
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice  { get; set; }


    }
}
