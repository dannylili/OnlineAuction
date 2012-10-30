using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace OnlineAuction.Business.Components
{
    public class TenantProvider
    {
        public string GetOnlineAuctionConnectionString()
        {
            return (ConfigurationManager.ConnectionStrings["OnlineAuctionDbContent"].ConnectionString);
            //return ("数据库连接字符串");
        }
    }
}
