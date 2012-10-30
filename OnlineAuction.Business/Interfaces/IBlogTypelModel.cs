using System;
using System.Collections.Generic;
using OnlineAuction.Model;
using System.Linq;

namespace OnlineAuction.Business.Interfaces
{
    public interface IBlogTypelModel
    {
        void SaveEntity(BlogType entityType);
        void UpdateEntity(BlogType entityType, Nullable<int> ID = 0);
        void DeleteEntity(BlogType entityType);
        void DeleteEntity(int rowKeyValue);

        BlogType GetEntity(BlogType entityType, int Id);
        IQueryable<BlogType> GetEntityQueryable();
        IEnumerable<BlogType> GetSimpleEntries(string tabName, string sqlCondition);
    }
}
