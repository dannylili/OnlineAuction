using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using OnlineAuction.Model.Common;

namespace OnlineAuction.EF
{
    public interface IModel
    {
        void SaveEntity<EntityType>(EntityType entityType) where EntityType : class,OnlineAuctionBaseEntity;
        void UpdateEntity<EntityType>(EntityType entityType, Nullable<int> ID=0) where EntityType : class,OnlineAuctionBaseEntity;
        void DeleteEntity<EntityType>(EntityType entityType) where EntityType : class,OnlineAuctionBaseEntity;
        void DeleteEntity<EntityType>(int rowKeyValue) where EntityType : class,OnlineAuctionBaseEntity;

        EntityType GetEntity<EntityType>(EntityType type, int Id) where EntityType : class,OnlineAuctionBaseEntity;
        IQueryable<EntityType> GetEntityQueryable<EntityType>() where EntityType : class, OnlineAuctionBaseEntity;
    }
}
