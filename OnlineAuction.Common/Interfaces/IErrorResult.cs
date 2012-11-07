using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAuction.Common.Interfaces
{
    public interface IErrorResult
    {
        void AddMessage();
        bool IsValid();
        
    }
}
