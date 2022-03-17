using ConfigurationAppSettingsTest.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigurationAppSettingsTest.OptionPatterns
{
    static public class OptionPattern
    {
        static public void LoadOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Level1>(configuration.GetSection("Level1"))
                .PostConfigure<Level1>(configValidate =>
                {
                    if (string.IsNullOrEmpty(configValidate.Level1String))
                        throw new Exception("Level1String is null or Empty");
                });
        }
    }
}
