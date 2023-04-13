using ECO.EnvironmentConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Configuration
{
    public class EcoServerConfiguration
    {
        public string ConnectionString { get => EnvironmentConfig.GetAppSetting("ConnectionStrings:ECODB"); }
    }
}
