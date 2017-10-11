using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNoSql.Context
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database;
        public IConfigurationRoot iConfigurationRoot;

    }
}



