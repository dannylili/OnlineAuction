using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Common.Interfaces;
using OnlineAuction.Model;


namespace OnlineAuction.Business.Components
{
    public class BlogTypeModel : BusinessModel, IBlogTypeModel
    {
        #region Implement IBlogTypeModel

        public void Save(BlogType entityType)
        {
            Model.Save(entityType);
        }

        public void Update(BlogType entityType, int? ID = 0)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogType entityType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rowKeyValue)
        {
            throw new NotImplementedException();
        }

        public BlogType Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BlogType> ListIsActiveAll()
        {
            return Model.ListIsActiveAll<BlogType>();
        }

        public IEnumerable<BlogType> GetSimple(string tabName, string sqlCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BlogType> ListAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
