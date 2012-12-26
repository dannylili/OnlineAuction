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
    public class UserModel : BusinessModel,IUserModel
    {
        #region 实现接口

        public ErrorResult Save(User entityType)
        {
            // 做Validation 取得valdiation的结果，将该结果抛出到上层
            Model.Save(entityType);
            var result = new ErrorResult();
            return result;
            // return (new ErrorResult() { Message = new List<Common.Classes.Message>(), IsValid = true });
        }

        public ErrorResult Update(User entityType, int? ID = 0)
        {
            Model.Update(entityType);
            return (new ErrorResult());
        }

        public void Delete(User entityType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rowKeyValue)
        {
            Model.Delete<User>(rowKeyValue);
        }

        public User Get(int Id)
        {
            var blogType = Model.Get<User>(Id);
            return blogType;
        }

        public IQueryable<User> ListIsActiveAll()
        {
            return Model.ListIsActiveAll<User>();
        }

        public IEnumerable<User> GetSimple(string tabName, string sqlCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> ListAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
