using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using OnlineAuction.Model;
using OnlineAuction.EF;
using OnlineAuction.EF.Mapping;
using System.Data.Entity.Infrastructure;

namespace OnlineAuction.EF
{
    /// <summary>
    /// 需要通过一个容器将这些类映射到数据库
    /// 使用 Code First 的好处在于，你的实体类不需要任何 EF(Entity Framework) 的内容：不需要派生自某个特定的基类，也不需要任何讨厌的标签附加在其上。好了，对于标签来说，像我们将要看到的，是可选的
    /// 
    /// 这个类是 EF 相关的，它不需要与你的模型类(POCO或者POJO，一般来将POCO就是一些只有get；set的属性类，实现封转数据的功能)出现在同一个程序集中。
    /// context 必须满足下面的要求：
    /// 派生自 System.Data.Entity.DbContext
    /// 对于你希望使用的每一个实体集定义一个属性
    /// 每一个属性的类型是 System.Data.Entity.DbSet<T>，T 就是实体的类型
    /// 每一个属性都是读写属性 read/write ( get/set )
    /// 
    /// 这个类是 EF 相关的，它不需要与你的模型类出现在同一个程序集中
    /// 在这里，DbContext 基类通过反射来获取映射到数据库的实体。这遵循一系列的约定
    /// </summary>
    public class OnlineAuctionDbContent : DbContext
    {
        #region 构造函数

        // 构造函数中的参数用于指定 connectionStrings 的 name
        // 默认值为 Context 类的类全名，本例为 OnlineAuctionDbContent
        public OnlineAuctionDbContent()
            : base("name=OnlineAuctionDbContent")
        { }

        public OnlineAuctionDbContent(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            InitialContentxt();
        }

        /// <summary>
        /// 这个静态的构造函数对于整个应用程序域来说建立一个标准，当数据库的上下文初始化的时候，检查数据库的架构是否与模型相符，如果不是的话，将删除数据库然后重新创建它
        /// <remarks></remarks>
        /// </summary>
        static OnlineAuctionDbContent()
        {
            // 也可以将这句放在 Global.asax文件中的 Application_Start方法中
            Database.SetInitializer<OnlineAuctionDbContent>(new DropCreateDatabaseIfModelChanges<OnlineAuctionDbContent>());
        }

        #endregion

        #region 所有需要关联到 Context 的类都要类似如下代码这样定义

        // DbSet<Student> Student { get; set; }
        DbSet<BlogType> BlogType { get; set; }
        DbSet<PersonAddress> PersonAddress { get; set; }
        DbSet<Person> Person { get; set; }

        #endregion

        #region 使用 Fluent API 来修改实体到数据库结构的映射，修改默认的约定。

        /*
         * 
         * 实体到数据库结构的映射是通过默认的约定来进行的，如果需要修改的话
         * 有两种方式，分别是：Data Annotations 和 Fluent API 以下介绍通过 Fluent API 来修改实体到数据库结构的映射
         *（通过 Data Annotations 来修改实体到数据库结构的映射的方法参见 Product.cs 文件） OnModelCreating
         *
         */

        /// <summary>
        /// 使用 Fluent API 来修改实体到数据库结构的映射
        /// 也可以将Mapping文件中的代码写在此方法中
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new BlogTypeMap());
            modelBuilder.Configurations.Add(new PersonAddressMap());
            modelBuilder.Configurations.Add(new PersonMap());


            // modelBuilder.Ignore(new StudentMap());


            /*
             * modelBuilder.Entity<Student>()
             *      .Property(t => t.Age)
             *      .IsOptional();
             *
             *  modelBuilder.Entity<Student>()
             *      .ToTable("Student");
             *
             *  base.OnModelCreating(modelBuilder);
             * 
             * 
             */
        }

        #endregion

        #region 配置

        private void InitialContentxt()
        {
            /// 延迟加载 true 获取实体时不会加载其导航属性，一旦用到导航属性就会自动加载
            ///  false - 直接加载（Eager loading）：通过 Include 之类的方法<c>显示</c>加载导航属性，获取实体时会即时加载通过 Include 指定的导航属性
            this.Configuration.LazyLoadingEnabled = true;

            /// 自动检测变化（POCO和database是否一致）
            // this.Configuration.AutoDetectChangesEnabled = true;
        }

        #endregion
    }
}
