using System;
using System.Collections.Generic;
using System.Text;

namespace Gbso.Core
{
    public static partial class Utils
    {
        public static bool IsSubclassOfRawGeneric(Type tGeneric, Type tCheck)
        {
            while (tCheck != null && tCheck != typeof(object))
            {
                var cur = tCheck.IsGenericType ? tCheck.GetGenericTypeDefinition() : tCheck;
                if (tGeneric == cur)
                {
                    return true;
                }
                tCheck = tCheck.BaseType;
            }
            return false;
        }
    }
}
