using System;
using System.Collections.Generic;
using System.Linq;
using OnlineAuction.Common.Interfaces;

namespace OnlineAuction.Business.Components
{
    public class BusinessModel
    {
        protected IModel Model { get; set; }
        protected string GetConnection { get; set; }
    }
}
