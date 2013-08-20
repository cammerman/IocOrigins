using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class InMemoryDataStore : IDataStore
    {
        public IList<object> Data { get; private set; }

        public InMemoryDataStore(IEnumerable<object> data)
        {
            Data = data.ToList();
        }
    }
}
