
using Gbso.Core.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace Gbso.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetCode(this Enum enumerator)
        {
            var attr = enumerator.GetAttribute<DatabaseItemEnumInfo>();
            return  attr?.Code;
        }

        public static string GetDescription(this Enum enumerator)
        {
            var attr = enumerator.GetAttribute<DatabaseItemEnumInfo>();
            return attr?.Description;
        }

        public static Tattribute GetAttribute<Tattribute>(this Enum enumerator)
            where Tattribute: Attribute
        {
            var attribute = (Tattribute)enumerator?.GetType().GetMember(enumerator.ToString())?.FirstOrDefault()?.GetCustomAttribute(typeof(Tattribute), false);
            return attribute;
        }
    }
}
