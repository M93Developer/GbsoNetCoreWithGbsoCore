using Gbso.App.Model.General;
using Gbso.Core.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Gbso.App.NetMvc
{
    public static class AppUtils
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList(Type enumType, Func<Enum, string> text, Enum selected = null)
        {
            if (!enumType.IsEnum) throw new ApplicationException("enumType debe ser enum");
            if (!(selected?.GetType().IsEnum ?? true)) throw new ApplicationException("selected debe ser enum");
            if (text == null) throw new ApplicationException("La expresión del tecto no puede ser null");
            var values = Enum.GetValues(enumType).Cast<Enum>();
            return values.Select(e => new SelectListItem(text(e), e.GetHashCode().ToString(), e == selected ? true : false));
        }
    }
}
