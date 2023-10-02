using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{


    
    //Generic calss
    //class: referans tip 

    //T IEntity ya  da  IEntity implemente eden baska bir nesne  olabilir

    public interface IEntityRepository<T> where T:class,IEntity,new()
    {

        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        //filtreleme islemi ici kullanilir null donduru deger dondurmez demek 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
