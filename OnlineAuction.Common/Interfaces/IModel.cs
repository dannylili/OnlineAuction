using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;


namespace OnlineAuction.Common.Interfaces
{
    public interface IModel
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        void Save<EntityType>(EntityType entityType) where EntityType : class,IOnlineAuctionBaseEntity;

        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="ID"></param>
        void Update<EntityType>(EntityType entityType, Nullable<int> ID = 0) where EntityType : class,IOnlineAuctionBaseEntity;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        void Delete<EntityType>(EntityType entityType) where EntityType : class,IOnlineAuctionBaseEntity;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="rowKeyValue"></param>
        void Delete<EntityType>(int rowKeyValue) where EntityType : class,IOnlineAuctionBaseEntity;

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="type"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        EntityType Get<EntityType>(int Id) where EntityType : class,IOnlineAuctionBaseEntity;

        IQueryable<EntityType> ListIsActiveAll<EntityType>() where EntityType : class ,IOnlineAuctionBaseEntity;

        IEnumerable<EntityType> GetSimple<EntityType>(string tabName, string sqlCondition) where EntityType : class,IOnlineAuctionBaseEntity;

        IQueryable<EntityType> ListAll<EntityType>() where EntityType : class, IOnlineAuctionBaseEntity;
    }
}
