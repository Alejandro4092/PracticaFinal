using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetAppAdoNet.Helpers
{
    public class HelperConfiguration
    {
        //tenemos varias opciones
        //dependiendo del tipo de logica podremos pensar de una forma o de otra
        //queremos recuperar el objeto configuration
        public static IConfigurationRoot GetConfiguration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
    }
}
