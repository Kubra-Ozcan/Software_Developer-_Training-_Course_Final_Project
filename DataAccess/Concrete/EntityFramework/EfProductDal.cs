using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal

    {

        //NuGet baskalarinin yazdigi kodlari da kullaniriz
        //Context: Vertabani ile kendi kodumuzu iliskilendirdigimiz classin ta kendisi
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);                              //Referansi yakala veritabaniyla eslestir
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added; //O aslinda eklenecek bir nesne 
                context.SaveChanges();                                              //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);                                //Referansi yakala veritabaniyla eslestir
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted; //O aslinda eklenecek bir nesne 
                context.SaveChanges();                                                  //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // tek data getirecek 
                //Standart gorudgumuz yerde onu generic basehale getiriyourz ama ona daha cok var
 
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // getirilecek datayi hangi kosullara gore getiriyoruz arama cubugunu dusun 
                return filter == null  ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                //filtre null mi ? :degilse
                //arkaplanda bizim icin select from product donduruyor bizim icin
                //Egerkosul verirse
                //Veritababindaki butun tabloyu listeye cevir onu bana ver
            }
        }

        public void Update(Product entity)
        {
        
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Referansi yakala veritabaniyla eslestir
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //O aslinda eklenecek bir nesne 
                context.SaveChanges(); //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }
    }
}
