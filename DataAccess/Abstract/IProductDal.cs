using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Sen Ientity repositoryi product icin yapilandirdin
        //interface methodlari default publictir
        List<ProductDetailDto> GetProductDetails();



    }
}
