using ConfigurationAppSettingsTest.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationAppSettingsTest.BindConfigurations
{
    public class Level1BindConfiguration
    {

        public Level1 BindConfiguration(IConfiguration _configuration)
        {
            Level1 lvl1 = new();
            _configuration.Bind("Level1", lvl1);
            return lvl1;
        }
    }
}
