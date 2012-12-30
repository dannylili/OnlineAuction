using System.Collections;
using System.Collections.Generic;
using OnlineAuction.Model.Common;

namespace OnlineAuction.Business.Components.GridConfig
{
    /// <summary>
    /// 配置Grid的<c>colNames</c>
    /// </summary>
    public class BaseGridConfig<Tentity> where Tentity : IOnlineAuctionBaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public IList DataField { get; set; }
    }
}
