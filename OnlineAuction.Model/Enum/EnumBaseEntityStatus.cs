using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAuction.Model.Enum
{
    public enum EnumBaseEntityStatus : byte
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal=0,

        /// <summary>
        /// 已经删除
        /// </summary>
        Deleted = 1,

        /// <summary>
        /// 被锁定
        /// </summary>
        Locked = 2,
    }
}
