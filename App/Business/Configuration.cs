using Microsoft.Extensions.Configuration;

namespace Gbso.App.Business
{
    public class Confi
    {
        public static string DefoultSqlConnectionName { private get; set; }
        public static IConfiguration Configuration { private get; set; }
        internal static string DefatultConnectionString {
            get {
                return Configuration.GetConnectionString(DefoultSqlConnectionName);
            }
        }
    }
}
