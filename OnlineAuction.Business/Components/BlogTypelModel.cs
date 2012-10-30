using System;
using System.Linq;
using System.Collections.Generic;
using OnlineAuction.Business.Components;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Model;

namespace OnlineAuction.Business.Components
{
    /// <summary>
    /// 类型表
    /// </summary>
    public class BlogTypelModel : BusilessModel, IBlogTypelModel
    {
        #region 属性


        #endregion

        #region 公共方法

        public void SaveEntity(BlogType entity)
        {
            DbModel.SaveEntity<BlogType>(entity);
        }

        public void UpdateEntity(BlogType entity, Nullable<int> ID = 0)
        {
            DbModel.UpdateEntity<BlogType>(entity, ID);
        }

        public void DeleteEntity(BlogType entity)
        {
            DbModel.DeleteEntity<BlogType>(entity);
        }

        public void DeleteEntity(int rowKeyValue)
        {
            DbModel.DeleteEntity<BlogType>(rowKeyValue);
        }

        public BlogType GetEntity(BlogType entity, int Id)
        {
            return DbModel.GetEntity<BlogType>(entity,Id);
        }

        public IQueryable<BlogType> GetEntityQueryable()
        {
            return DbModel.GetEntityQueryable<BlogType>();
        }

        /// <summary>
        /// Entity Framework 4.1 之八：绕过 EF 查询映射
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BlogType> GetSimpleEntries(string tabName, string sqlCondition)
        {
            var entitys = DbModel.GetSimpleEntries<BlogType>(typeof(BlogType).Name, "");
            var blogType = from entity in entitys
                           where entity.ID == 1
                           select entity;
            return blogType;
        }

        #endregion

        #region 私有方法



        #endregion
    }
}
