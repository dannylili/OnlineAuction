﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model;


namespace OnlineAuction.Business.Interfaces
{
    public interface IBlogTypeModel
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        void Save(BlogType entityType);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="ID"></param>
        void Update(BlogType entityType, Nullable<int> ID = 0);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        void Delete(BlogType entityType);

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
        BlogType Get(int Id);

        IQueryable<BlogType> ListIsActiveAll();

        IEnumerable<BlogType> GetSimple(string tabName, string sqlCondition);

        IQueryable<BlogType> ListAll();
    }
}
