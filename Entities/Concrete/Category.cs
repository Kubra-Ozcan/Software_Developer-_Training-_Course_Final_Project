using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //ciplak Class Kalmasin 
    //Hic bir ifade iinterface abstract class inheritance alamamis bir class senin basina sonra bela olur
    public class Category:IEntity
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
