using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.mongo.common.Model
{
    public class Person : MongoModelBase
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public int ?Age { get; set; }
        [BsonElement("score")]
        public int ?Score { get; set; }
        [BsonElement("nation")]
        public string Nation { get; set; }
    }
}
