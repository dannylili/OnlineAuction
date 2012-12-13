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
    public class PersonModel : BusinessModel,IPersonModel
    {
        #region 实现接口

        public ErrorResult Save(Person entityType)
        {
            // 做Validation 取得valdiation的结果，将该结果抛出到上层
            Model.Save(entityType);
            var result = new ErrorResult();
            return result;
            // return (new ErrorResult() { Message = new List<Common.Classes.Message>(), IsValid = true });
        }

        public ErrorResult Update(Person entityType, int? ID = 0)
        {
            Model.Update(entityType);
            return (new ErrorResult());
        }

        public void Delete(Person entityType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rowKeyValue)
        {
            Model.Delete<Person>(rowKeyValue);
        }

        public Person Get(int Id)
        {
            var blogType = Model.Get<Person>(Id);
            return blogType;
        }

        public IQueryable<Person> ListIsActiveAll()
        {
            return Model.ListIsActiveAll<Person>();
        }

        public IEnumerable<Person> GetSimple(string tabName, string sqlCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> ListAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
