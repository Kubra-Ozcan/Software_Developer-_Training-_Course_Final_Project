using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity :class ,IEntity,new()
        where TContext :DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);                              //Referansi yakala veritabaniyla eslestir
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added; //O aslinda eklenecek bir nesne 
                context.SaveChanges();                                              //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);                                //Referansi yakala veritabaniyla eslestir
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted; //O aslinda eklenecek bir nesne 
                context.SaveChanges();                                                  //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // tek data getirecek 
                                                                       //Standart gorudgumuz yerde onu generic basehale getiriyourz ama ona daha cok var

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // getirilecek datayi hangi kosullara gore getiriyoruz arama cubugunu dusun 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //filtre null mi ? :degilse
                //arkaplanda bizim icin select from product donduruyor bizim icin
                //Egerkosul verirse
                //Veritababindaki butun tabloyu listeye cevir onu bana ver
            }
        }

        public void Update(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Referansi yakala veritabaniyla eslestir
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //O aslinda eklenecek bir nesne 
                context.SaveChanges(); //ve simdi ekle SaveChanges : buradaki butun islemleri pit pit pit gerceklestirir.
            }
        }
    }
}
