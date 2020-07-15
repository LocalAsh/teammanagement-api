using Microsoft.Extensions.Configuration;

namespace TeamManagementAngular.DbModels
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;
    }
}
