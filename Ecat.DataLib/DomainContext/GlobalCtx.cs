using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Ecat.DataLib.DomainModel.Global;
using Ecat.DataLib.SysUtils.Attributes;

namespace Ecat.DataLib.DomainContext
{
    public class GlobalCtxFactory : IDbContextFactory<GlobalCtx>
    {
        public GlobalCtx Create()
        {
            return new GlobalCtx();
        }
    }

    public class GlobalCtx : BaseCtx<ConfigGlobalContext>
    {
        public GlobalCtx() { }

        public GlobalCtx(string connectionString = null) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.HasDefaultSchema("gbl");
            base.OnModelCreating(mb);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ClientApp> ClientApps { get; set; }
    }
}
