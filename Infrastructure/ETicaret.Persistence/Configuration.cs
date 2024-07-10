using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class Configuration
    {
        static public string ConnectionString 
        {
            get 
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsetting.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
