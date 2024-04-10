using KeyNerd.DataTransfer.Settings;

namespace KeyNerd.Api.Extensions
{
    public static class SettingInjectorConfig
    {
        public static WebApplicationBuilder SettingsSetup(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<AWSSettings>(builder.Configuration.GetSection("AWSSettings"));
            builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("StorageSettings"));
            return builder;
        }
    }
}
