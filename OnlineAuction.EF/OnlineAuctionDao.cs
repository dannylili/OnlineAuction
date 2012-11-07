using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using OnlineAuction.EF;
using OnlineAuction.Common.Interfaces;
using OnlineAuction.Common.Extension;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Enum;

namespace OnlineAuction.EF
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class OnlineAuctionDao : IModel, IDisposable
    {
        #region 属性

        public readonly DbContext DB;

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
        /// <c>保存数据方法</c>
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        public void Save<EntityType>(EntityType entityType) where EntityType : class,IOnlineAuctionBaseEntity
        {
            EntityDetech<EntityType>(entityType);

            // 判断当前操作的Entity类型
            GetDbSet<EntityType>().Add(entityType);
            SaveChanges();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="ID"></param>
        public void Update<EntityType>(EntityType entityType, Nullable<int> ID = 0) where EntityType : class,IOnlineAuctionBaseEntity
        {
            EntityDetech<EntityType>(entityType);
            //  var oldEntityValue=GetDbSet<EntityType>().Find(ID);
            var oldEntityValue = GetDbSet<EntityType>().Find(entityType.ID);
            DB.Entry(oldEntityValue).CurrentValues.SetValues(entityType);
            SaveChanges();
        }

        //public void UpdateEntity<EntityType>(EntityType entityType) where EntityType : class,IOnlineAuctionBaseEntity
        //{
        //    EntityDetech<EntityType>(entityType);
        //    var entity = this.GetDbSet<EntityType>().Find(entityType.ID);
        //    if (entity != null)
        //    {
        //        DB.Entry<EntityType>().CurrentValues.SetValues(EntityType);
        //    }
        //    else new ArgumentException("");
        //}

        /// <summary>
        /// 根据对象删除对象
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="rowKeyValue"></param>
        public void Delete<EntityType>(EntityType entityType) where EntityType : class,IOnlineAuctionBaseEntity
        {
            EntityDetech(entityType);
            var entity = GetDbSet<EntityType>().Find(entityType.ID);
            // entity.SystemStatus = SystemStatus.Deleted; // 如果是逻辑删除时用这个方法
            DbSet dbset = GetDbSet<EntityType>();
            dbset.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <param name="rowKeyValue"></param>
        public void Delete<EntityType>(int rowKeyValue) where EntityType : class, IOnlineAuctionBaseEntity
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
        public EntityType GetDbSet<EntityType>(int rowKeyValue) where EntityType : class, IOnlineAuctionBaseEntity
        {
            var dbset = GetDbSet<EntityType>();
            var entity = dbset.Find(rowKeyValue);
            return entity;
        }

        /// <summary>
        /// http://www.cnblogs.com/dudu/archive/2012/04/01/enitity_framework_func.html 参考DbSet的where方法中的参数，Func类型的参数将全表查询，而 Expression是只查询一部分，
        /// 不要用Func<TSource, bool>，用Expression<Func<TSource, bool>>。
        /// IQueryablel的where方法也是需要注意性能问题:将where生成一个负载的sql语句，一次查询，然后
        /// List是从数据库一次查询，然后再内存中查询
        /// AsEnumerable()方法也是将读取数据
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        public IQueryable<EntityType> List<EntityType>() where EntityType : class, IOnlineAuctionBaseEntity
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
        public EntityType Get<EntityType>(int Id) where EntityType : class, IOnlineAuctionBaseEntity
        {
            throw new NotImplementedException();
            // return new (object)EntityType;
        }

        /// <summary>
        /// Entity Framework 4.1 之八：绕过 EF 查询映射
        /// you can see http://www.cnblogs.com/haogj/archive/2011/05/08/2040196.html
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        public IEnumerable<EntityType> GetSimple<EntityType>(string tabName, string sqlCondition = "") where EntityType : class,IOnlineAuctionBaseEntity
        {
            IObjectContextAdapter adapter = (DbContext)DB;
            string sql = " select * from " + tabName + " where 1=1 " + sqlCondition;
            var entity = adapter.ObjectContext.CreateQuery<EntityType>(sql);
            return entity;
        }

        /// <summary>
        /// 获取状态为可用的数据
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        public IQueryable<EntityType> ListIsActiveAll<EntityType>() where EntityType : class,IOnlineAuctionBaseEntity
        {
            return GetDbSet<EntityType>().IsActive();
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="EntityType"></typeparam>
        /// <returns></returns>
        public IQueryable<EntityType> ListAll<EntityType>() where EntityType : class ,IOnlineAuctionBaseEntity
        {
            return GetDbSet<EntityType>();
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


            /// 处于 deleted 或 detached 状态的对象没有当前值（CurrentValues ）
            /// 处于 added 或 detached 状态的对象没有原始值(OriginalValues )
            var addedTrackableEntries = DB.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            // var updatedTrackableEntries = DB.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            var updatedTrackableEntries = ((IObjectContextAdapter)DB).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Where(t => t.GetModifiedProperties().Count() > 0);

            // 判断对象Entity是否发生了改变
            if (addedTrackableEntries.Count() < 0 && updatedTrackableEntries.Count() < 0)
            {
                return;
            }

            foreach (var item in addedTrackableEntries.Select(e => e.Entity))
            {
                DbEntityValidationResult validateResult = DB.Entry(item).GetValidationResult();
                ((IOnlineAuctionBaseEntity)item).SystemStatus = SystemStatus.Active;
                // 添加创建人给每个刚被添加的Entity
            }
            foreach (var item in updatedTrackableEntries.Select(e => e.Entity))
            {
                // 添加修改人给每个刚被添加的Entity

                /// 取得哪些字段被修改过 http://www.cnblogs.com/l1b2q31/articles/1721025.html
                // ObjectStateEntry updatedEntity = ((IObjectContextAdapter)DB).ObjectContext.ObjectStateManager.GetObjectStateEntries(item).Where(t => t.State == EntityState.Modified && t.GetModifiedProperties().Count() > 0);
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
                        errorMessage += string.Format("Entity of {0} in statue {1} has following error {2}", error.Entry.Entity.GetType().Name, error.Entry.State, validationError.PropertyName + "相关错误是：" + validationError.ErrorMessage + "||");
                    }
                }
                // throw new ArgumentException(errorMessage);
            }
            catch (OptimisticConcurrencyException concurrencyException)
            {
                // throw new ArgumentException("并发异常是：" + concurrencyException.Message);
            }
        }

        #endregion

        #region Entity FrameWork的特性

        // 1　　说明　　1
        //2　　Context操作数据　　1
        //2.1　　AddObject 添加实体　　1
        //2.2　　DeleteObject 删除实体　　1
        //2.3　　Detach 分离实体　　2
        //2.4　　修改实体　　2
        //2.5　　ApplyPropertyChanges 修改实体　　2
        //2.6　　Attach / AttachTo 附加实体　　2
        //2.7　　CreateEntityKey 创建EntityKey　　3
        //2.7.1　　EntityKey　　3
        //2.8　　GetObjectByKey/TryGetObjectByKey 通过EntityKey得到实体　　3
        //2.9　　CreateQuery 创建查询　　4
        //3　　状态管理　　4
        //3.1　　EntityState 状态枚举　　4
        //3.2　　Context.ObjectStateManager 管理记录的状态　　4
        //3.2.1　　GetObjectStateEntry 得到状态实体　　4
        //3.2.2　　TryGetObjectStateEntry 得到状态实体　　4
        //3.2.3　　GetObjectStateEntries 得到状态实体集合　　5
        //3.2.4　　ObjectStateManagerChanged 事件　　5
        //3.3　　ObjectStateEntry 对象　　5
        //3.3.1　　基本属性　　5
        //3.3.2　　State 状态属性　　6
        //3.3.3　　CurrentValues 当前值　　6
        //3.3.4　　OriginalValues 原始值　　6
        //3.3.5　　GetModifiedProperties 得到被修改的属性　　6
        //3.3.6　　SetModified,SetModifiedProperty 标记为修改　　7
        //3.3.7　　Delete 标记为删除　　7
        //3.3.8　　AcceptChanges 方法　　7
        //4　　保存修改到数据库　　8
        //4.1　　Context.SaveChanges 方法　　8
        //4.2　　Context.SavingChanges 事件　　9
        //4.3　　Context.AcceptAllChanges 方法　　9
        //5　　连接属性　　9
        //5.1　　Context.DefaultContainerName 属性　　9
        //5.2　　Context.Connection 属性　　9
        //5.3　　Context.CommandTimeout 属性　　10
        //6　　Context.MetadataWorkspace　　10
        //7　　数据刷新与并发　　10
        //7.1　　缓存数据不会自动更新　　10
        //7.2　　[并发模式]值为[Fixed]的并发异常　　11
        //7.3　　ObjectContext.Refresh()　　11
        //7.3.1　　StoreWins　　11
        //7.3.2　　ClientWins　　12
        //7.4　　也可以先Refresh()再SaveChanges(),而不用异常捕获　　13
        //8　　事务处理　　13
        //8.1　　同一SubmitChanges 会做默认的事务处理　　13
        //8.2　　不同SubmitChanges 不会做事务处理　　13
        //8.3　　System.Data.Common.DbTransaction　　13
        //8.4　　死锁(两个Context使用DbTransaction)　　14
        //8.5　　TransactionScope 事务(两个Context)　　14

        #endregion

        #region MyRegion

        /// <summary>
        /// 释放数据库资源
        /// </summary>
        public void Dispose()
        {
            /// 如果没有这句的话，将抛出一个错误
            // DB.Dispose();
        }

        #endregion
    }
}
