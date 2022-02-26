using demo.IRepository;
using demo.IService;
using demo.mongo.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        private const string _tableName = "person";
        public PersonService(IRepositotyBase<Person> mongoBase) : base(mongoBase)
        {
            mongoBase.Connection(_tableName);
        }

        public IEnumerable<Person> Find(Person person)
        {
            IEnumerable<Person> result;

            result = this.FindAll();

            if (person.Id != null)
            {
                result = result.Where(o => o.Id == person.Id);
            }
            if (person.Age != null)
            {
                result = result.Where(o => o.Age == person.Age);
            }
            if (person.Score != null)
            {
                result = result.Where(o => o.Score == person.Score);
            }
            if (person.Nation != null)
            {
                result = result.Where(o => o.Nation == person.Nation);
            }
            return result;
        }
    }
}
