using demo.mongo.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.IService
{
    public interface IServiceBase<TEntity> where TEntity : MongoModelBase
    {
        public TEntity FindById(string id);

        public IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> expression);

        public IEnumerable<TEntity> FindAll();

        public TEntity InsertOne(TEntity entity);
        public IEnumerable<TEntity> InsertMany(IEnumerable<TEntity> entities);

        public bool UpdateOne(TEntity entity);
        public bool UpdateMany(TEntity entities);
    }
}
