using demo.common;
using demo.IRepository;
using demo.mongo.common;
using demo.mongo.common.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class RepositoryBase<TEntity> : IRepositotyBase<TEntity> where TEntity : MongoModelBase
    {
        private IMongoCollection<TEntity> _collection;
        private readonly MongoConnectionInfo _mongodb;

        private readonly MongoClient _client;
        public RepositoryBase(MongoConnectionInfo mongodb)
        {
            _mongodb = mongodb;

            _client = new MongoClient(mongodb.ConnectionString);
        }        

        public void Connection(string tablename)
        {
            var database = _client.GetDatabase(_mongodb.Database);

            _collection = database.GetCollection<TEntity>(tablename);
        }

        #region Get
        public TEntity Get(string id)
        {
            //todo DTO
            
            TEntity res = _collection.Find<TEntity>(a => a.Id == id).FirstOrDefault();
            return res;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _collection.Find<TEntity>(expression).ToEnumerable();
        }

        public IEnumerable<TEntity> Get()
        {
            var result = _collection.Find<TEntity>(a => true).ToEnumerable();
            return result;
        }
        #endregion

        #region Post
        public TEntity Post(TEntity element)
        {
            //todo DTO
            _collection.InsertOne(element);
            var id = element.Id;
            return element;
        }

        public IEnumerable<TEntity> Post(IEnumerable<TEntity> elements)
        {
            //todo DTO
            _collection.InsertMany(elements);
            return elements;
        }
        #endregion

        public bool Put(TEntity element)
        {
            //todo DTO
            _collection.ReplaceOne<TEntity>(a => a.Id == element.Id, element);
            return true;
        }

        public bool Put(IEnumerable<TEntity> elements)
        {
            //todo DTO
            foreach (TEntity item in elements)
            {
                this.Put(item);
            }
            return true;
        }

    }
}
