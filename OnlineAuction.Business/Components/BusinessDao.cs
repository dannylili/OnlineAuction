using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;


namespace OnlineAuction.Business.Components
{
    /// <summary>
    /// 数据库操作抽象类，可用BusilessModel.cs替换
    /// 该类要调用OnlineAuctionDao.cs的所有方法
    /// </summary>
    public abstract class BusinessDao<T> where T : class,OnlineAuctionBaseEntity
    {
       
    }
}
