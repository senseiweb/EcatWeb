using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Ecat.DataLib.DomainContext
{
    public abstract class BaseCtx<TConfigType> : DbContext where TConfigType : class
    {
        private const string LocalDb = "Server=(localdb)\\mssqllocaldb;Database=ecat-local-dev;Trusted_Connection=True;MultipleActiveResultSets=true";
        //public string ConnectionString { get; set; }


        protected BaseCtx(string connectionString = LocalDb) : base(connectionString)
        {
            Database.Log = s => Debug.WriteLine(s);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Conventions.Remove<PluralizingTableNameConvention>();

            mb.Properties<string>().Configure(s => s.HasMaxLength(50));

            mb.Properties()
                .Where(p => p.Name.StartsWith("Mp") || p.Name.StartsWith("En"))
                .Configure(x => x.HasColumnName(x.ClrPropertyInfo.Name.Substring(2)));

            mb.Types()
                .Where(type => type.Name.StartsWith("Ec"))
                .Configure(type => type.ToTable(type.ClrType.Name.Substring(2)));


            foreach (var ctxConfig in Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.GetCustomAttributes(typeof(TConfigType)).Any())
                .Select(Activator.CreateInstance))
            {

                mb.Configurations.Add((dynamic)ctxConfig);
            }


            mb.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
