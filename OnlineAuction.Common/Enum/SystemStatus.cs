using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAuction.Common.Enum
{
    public enum SystemStatus : byte
    {
        Active = 0,
        Deleted = 1,
        Purged = 2
    }
}
