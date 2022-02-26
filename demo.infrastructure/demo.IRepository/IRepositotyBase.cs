using demo.mongo.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.IRepository
{
    public interface IRepositotyBase<TEntity>
        where TEntity : MongoModelBase
    {
        void Connection(string tablename);

        TEntity Get(string id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> Get();

        TEntity Post(TEntity element);

        IEnumerable<TEntity> Post(IEnumerable<TEntity> elements);

        bool Put(TEntity element);

        bool Put(IEnumerable<TEntity> elements);

        //public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> conditions = null)
        //{
        //    var collection = _database.GetCollection<TEntity>(typeof(TEntity).Name);
        //    if (conditions != null)
        //    {
        //        return collection.Find(conditions).ToList();
        //    }
        //    return collection.Find(_ => true).ToList();
        //}
    }
}
