using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.Dal
{
    public class DbTransaction
    {
        private string _name;
        
        public bool Committed { get; set; }
        public bool Cancelled { get; set; }

        public DbTransaction(string name)
        {
            _name = name;
            Console.WriteLine("Transaction {0} opened.", _name);
        }

        public void Commit()
        {
            Committed = true;
            Console.WriteLine("Transaction {0} committed.", _name);
        }

        public void Cancel()
        {
            Cancelled = true;
            Console.WriteLine("Transaction {0} cancelled.", _name);
        }
    }
}
