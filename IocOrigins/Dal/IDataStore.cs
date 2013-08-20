using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public interface IDataStore
    {
        IList<object> Data { get; }
    }
}
