using demo.IRepository;
using demo.IService;
using demo.mongo.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : MongoModelBase
    {
        private readonly IRepositotyBase<TEntity> _mongoBase;

        public ServiceBase(IRepositotyBase<TEntity> mongoBase)
        {
            _mongoBase = mongoBase;
        }

        public IEnumerable<TEntity> FindAll()
        {
            var result = _mongoBase.Get();
            return result;
        }

        public TEntity FindById(string id)
        {
            TEntity result = _mongoBase.Get(id);
            return result;
        }

        public IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> expression)
        {
            var result = _mongoBase.Get(expression);
            return result;
        }

        public IEnumerable<TEntity> InsertMany(IEnumerable<TEntity> entities)
        {
            return _mongoBase.Post(entities);
        }

        public TEntity InsertOne(TEntity entity)
        {
            return _mongoBase.Post(entity);
        }

        public bool UpdateMany(TEntity entities)
        {
            return _mongoBase.Put(entities);
        }

        public bool UpdateOne(TEntity entity)
        {
            return _mongoBase.Put(entity);
        }
    }
}
