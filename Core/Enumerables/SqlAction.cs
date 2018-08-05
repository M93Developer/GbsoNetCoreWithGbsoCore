using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.Core.Enum
{
    public enum SqlAction
    {
        Register = 1,
        Get = 2,
        Update = 3,
        Delete = 4,
        RegisterAndReturnEntity = 5,
        UpdateAndReturnEntity = 6,
    }
}
