
using System.Reflection;

namespace Gbso.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetCode(this System.Enum enumerator)
        {
            var enumDescriptionAttributes = (DatabaseItemEnumInfo)enumerator?.GetType().GetCustomAttribute(typeof(DatabaseItemEnumInfo));
            return  enumDescriptionAttributes?.Code;
        }

        public static string GetDescription(this System.Enum enumerator)
        {
            var enumDescriptionAttributes = (DatabaseItemEnumInfo)enumerator?.GetType().GetCustomAttribute(typeof(DatabaseItemEnumInfo));
            return enumDescriptionAttributes?.Description ?? enumerator?.ToString();
        }
    }
}
