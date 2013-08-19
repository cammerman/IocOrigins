using IocOrigins.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Domain
{
    public class User : IEntity
    {
        public User(int id) 
        {
            Id = id;
        }

        public int Id { get; private set; }

        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
