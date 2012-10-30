using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Extension;

namespace OnlineAuction.Model
{
    public class BlogType : IOnlineAuctionBaseEntity
    {
        public BlogType()
        {
        }

        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string BlogShortName { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string BlogBrief { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public int BlogUsreID { get; set; }

        #region Complex Propert

        public SystemStatusWrapper SystemStatus { get; set; }

        #endregion

    }
}
