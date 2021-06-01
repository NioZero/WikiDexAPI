using Microsoft.Extensions.Configuration;

namespace WikiDexAPI
{
    public class AppSettingUtil
    {
        public AppSettingUtil(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; private set; }
    }
}
