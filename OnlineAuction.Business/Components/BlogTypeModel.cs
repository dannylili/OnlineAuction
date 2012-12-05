using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Common.Interfaces;
using OnlineAuction.Model;
using OnlineAuction.Business.Validation;

namespace OnlineAuction.Business.Components
{
    public class BlogTypeModel : BusinessModel, IBlogTypeModel
    {
        #region Implement IBlogTypeModel

        public ErrorResult Save(BlogType entityType)
        {
            // 做Validation 取得valdiation的结果，将该结果抛出到上层
            Model.Save(entityType);
            var result = new ErrorResult();
            return result;
            // return (new ErrorResult() { Message = new List<Common.Classes.Message>(), IsValid = true });
        }
        public ErrorResult Update(BlogType entityType, int? ID = 0)
        {
            Model.Update(entityType);
            return (new ErrorResult());
        }

        public void Delete(BlogType entityType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rowKeyValue)
        {
            Model.Delete<BlogType>(rowKeyValue);
        }

        public BlogType Get(int Id)
        {
            var blogType = Model.Get<BlogType>(Id);
            return blogType;
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
