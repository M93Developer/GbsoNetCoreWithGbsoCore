
using Gbso.Core.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace Gbso.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetShortDescription(this Enum enumerator)
        {
            var attr = enumerator.GetAttribute<EnumDescription>();
            return  attr?.ShortDescription ?? enumerator.ToString();
        }

        public static string GetDescription(this Enum enumerator)
        {
            var attr = enumerator.GetAttribute<EnumDescription>();
            return attr?.Description ?? GetShortDescription(enumerator);
        }

        public static Tattribute GetAttribute<Tattribute>(this Enum enumerator)
            where Tattribute: Attribute
        {
            if (!(enumerator?.GetType().IsEnum ?? true)) throw new ApplicationException("selected debe ser enum");
            var attribute = (Tattribute)enumerator?.GetType().GetMember(enumerator.ToString())?.FirstOrDefault()?.GetCustomAttribute(typeof(Tattribute), false);
            return attribute;
        }
    }
}
