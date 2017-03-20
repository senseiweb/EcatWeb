using Breeze.Persistence.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecat.DataLib.DomainContext
{
    public class BaseEfPersistMgr<T> : EFPersistenceManager<T> where T : class, new()
    {
        private readonly string _connectionString;

        public BaseEfPersistMgr(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override T CreateContext()
        {
            return (T)Activator.CreateInstance(typeof(T), _connectionString);
        }
    }
}
