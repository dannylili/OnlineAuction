using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using OnlineAuction.EF


namespace OnlineAuction.EF
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class OnlineAuctionDao : IModel
    {
        public DbContext DB;

        #region constraints

        /// <summary>
        /// 第一个构造器
        /// </summary>
        /// <param name="dbContext"></param>
        public OnlineAuctionDao(DbContext dbContext)
        {
            DB = dbContext;
        }

        /// <summary>
        /// 继承第一个构造器
        /// </summary>
        public OnlineAuctionDao()
            : this(new OnlineAuctionDbContent())
        {

        }

        #endregion

        #region 对外方法

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        public void SaveEntity<EntityType>(EntityType entityType) where EntityType : class,OnlineAuctionBaseEntity
        {
            EntityDetech<EntityType>(entityType);

            // 判断当前操作的Entity类型
            GetDbSet<EntityType>().Add(entityType);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="ID"></param>
        public void UpdateEntity<EntityType>(EntityType entityType, Nullable<int> ID = 0) where EntityType : class,OnlineAuctionBaseEntity
        {
            EntityDetech<EntityType>(entityType);
            //  var oldEntityValue=GetDbSet<EntityType>().Find(ID);
            var oldEntityValue = GetDbSet<EntityType>().Find(entityType.ID);
            DB.Entry(oldEntityValue).CurrentValues.SetValues(entityType);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="rowKeyValue"></param>
        public void DeleteEntity<EntityType>(EntityType entityType) where EntityType : class,OnlineAuctionBaseEntity
        {
            EntityDetech(entityType);
            var entity = GetDbSet<EntityType>().Find(entityType.ID);
            DbSet dbset = GetDbSet<EntityType>();
            dbset.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="rowKeyValue"></param>
        public void DeleteEntity<EntityType>(int rowKeyValue) where EntityType : class, OnlineAuctionBaseEntity
        {
            DbSet dbset = GetDbSet<EntityType>();
            var entity = dbset.Find(rowKeyValue);
            EntityDetech(dbset.Find(rowKeyValue));
            dbset.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// 检索对象
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="rowKeyValue"></param>
        /// <returns></returns>
        public EntityType GetDbSet<EntityType>(int rowKeyValue) where EntityType : class, OnlineAuctionBaseEntity
        {
            var dbset = GetDbSet<EntityType>();
            var entity = dbset.Find(rowKeyValue);
            return entity;
        }

        /// <summary>
        /// http://www.cnblogs.com/dudu/archive/2012/04/01/enitity_framework_func.html 参考DbSet的where方法中的参数，Func类型的参数将全表查询，而 Expression是只查询一部分，不要用Func<TSource, bool>，用Expression<Func<TSource, bool>>。
        /// IQueryablel的where方法也是需要注意性能问题:将where生成一个负载的sql语句，一次查询，然后
        /// List是从数据库一次查询，然后再内存中查询
        /// AsEnumerable()方法也是将读取数据
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        public IQueryable<EntityType> GetEntityQueryable<EntityType>() where EntityType : class, OnlineAuctionBaseEntity
        {
            var dbset = GetDbSet<EntityType>();
            return dbset.AsQueryable();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="type"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EntityType GetEntity<EntityType>(EntityType type, int Id) where EntityType : class, OnlineAuctionBaseEntity
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 取得EntityType类型的Set集合 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        private DbSet<EntityType> GetDbSet<EntityType>() where EntityType : class
        {
            return DB.Set<EntityType>();
        }

        /// <summary>
        /// 检查对象是否为null
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        private void EntityDetech<EntityType>(EntityType entityType)
        {
            if (entityType == null) throw new ArgumentNullException("entity is null");
        }

        /// <summary>
        /// 保存当前数据编号
        /// </summary>
        private void SaveChanges()
        {
            // 检查当前DBContext中那些Entity是Add和Update但还没有提交到数据库中的对象
            DB.ChangeTracker.DetectChanges();

            var addedTrackableEntries = DB.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            var updatedTrackableEntries = DB.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            // 判断没有改变
            if (addedTrackableEntries.Count() < 0 && updatedTrackableEntries.Count() < 0)
            {
                return;
            }

            foreach (var item in addedTrackableEntries.Select(e => e.Entity))
            {
                // 添加创建人给每个刚被添加的Entity
            }
            foreach (var item in updatedTrackableEntries.Select(e => e.Entity))
            {
                // 添加修改人给每个刚被添加的Entity
            }

            try
            {
                DB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // 检查meigeEntity的值是否和Mapping文件中的规则匹配,将错误消息记录在log中
                string errorMessage = string.Empty;
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        errorMessage += string.Format("Entity of {0} in statue {1} has following error {2}", error.Entry.Entity.GetType().Name, error.Entry.State, validationError.PropertyName + "相关错误是：" + validationError.ErrorMessage+"||");
                    }
                }
                throw new ArgumentException(errorMessage);
            }
        }

        #endregion
    }
}
