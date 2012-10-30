using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Common.Interfaces;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Enum;

namespace OnlineAuction.Common.Extension
{
    /// <summary>
    /// 对IBaseEntity类的扩展
    /// Linq的扩展必须是static类的非泛型方法
    /// </summary>
    public static class ExtensionIBaseEntity
    {
        /// <summary>
        /// IQueryable的扩展方法
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<TType> IsActive<TType>(this IQueryable<TType> source) where TType : class, IOnlineAuctionBaseEntity
        {
            return source.Where(t => t.SystemStatus.Value == (int)SystemStatus.Active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<TType> Deleted<TType>(this IQueryable<TType> source) where TType : class, IOnlineAuctionBaseEntity
        {
            return source.Where(t=>t.SystemStatus.Value==(int)SystemStatus.Deleted);
        }
    }
}
