using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecat.DataLib.DomainModel.Global;
using Ecat.DataLib.SysUtils.Attributes;

namespace Ecat.DataLib.Config
{
    [ConfigGlobalContext]
    public class CfgPersonApp : EntityTypeConfiguration<PersonApp>
    {
        public CfgPersonApp()
        {
            HasKey(p => new { p.PersonId, p.ClientAppId });
        }
    }
}
