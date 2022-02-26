using demo.mongo.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.IService
{
    public interface IPersonService : IServiceBase<Person>
    {
        IEnumerable<Person> Find(Person person);
    }
}
