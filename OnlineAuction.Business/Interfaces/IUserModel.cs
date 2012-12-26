using System;
using System.Collections.Generic;
using System.Linq;
using OnlineAuction.Business.Validation;
using OnlineAuction.Model;

namespace OnlineAuction.Business.Interfaces
{
    public interface IUserModel
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        ErrorResult Save(User entityType);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="ID"></param>
        ErrorResult Update(User entityType, Nullable<int> ID = 0);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        void Delete(User entityType);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="rowKeyValue"></param>
        void Delete(int rowKeyValue);

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="type"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        User Get(int Id);

        IQueryable<User> ListIsActiveAll();

        IEnumerable<User> GetSimple(string tabName, string sqlCondition);

        IQueryable<User> ListAll();
    }
}
