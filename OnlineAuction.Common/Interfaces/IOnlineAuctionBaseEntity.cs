using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Common.Extension;


namespace OnlineAuction.Model.Common
{
    /// <summary>
    /// 从 Code First 的名字可以猜到，使用 Code-First，你需要从代码开始数据的工作，你可以直接通过代码生成相应的数据库，也可以使用已经存在的数据库。使用 Code First 的好处在于，你的实体类不需要任何 EF 的内容：不需要派生自某个特定的基类，也不需要任何讨厌的标签附加在其上
    /// </summary>
    public interface IOnlineAuctionBaseEntity
    {
        int ID { get; set; }
        SystemStatusWrapper SystemStatus { get; set; }
    }

}
