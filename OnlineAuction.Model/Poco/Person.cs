using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Extension;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Model
{
    public class Person : IOnlineAuctionBaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<int> AddressID { get; set; } 

        #region 复杂类型

        public PersonAddress Address { get; set; }
        public SystemStatusWrapper SystemStatus { get; set; }

        #endregion

    }
}
