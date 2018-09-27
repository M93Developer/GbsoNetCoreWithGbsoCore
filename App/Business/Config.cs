using Microsoft.Extensions.Configuration;

namespace Gbso.App.Business
{
    public class Config
    {
        public static string DefoultSqlConnectionName { private get; set; }

        public static IConfiguration Configuration { private get; set; }

        internal static string GetDefatultConnectionString {
            get {
                return Configuration.GetConnectionString(DefoultSqlConnectionName);
            }
        }
    }
}
