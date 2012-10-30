using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using OnlineAuction.Model;

namespace OnlineAuction.EF.Mapping
{
    public class BlogTypeMap : EntityTypeConfiguration<BlogType>
    {
        public BlogTypeMap()
        {
            #region 一般的处理

            this.ToTable("BlogType");

            /// 指定主键
            this.HasKey(t => t.ID);

            /// 给属性指定指定长度
            this.Property(t => t.BlogShortName)
                .IsRequired()
                .HasMaxLength(200)
                /// / 指定对应到数据库的类型为 varchar，IsUnicode(true) 为 nvarchar(最大长度为4000)，默认为 nvarchar
                .IsUnicode(false);

            #endregion

            #region 复杂类型的映射

            this.Property(t => t.SystemStatus.Value).HasColumnName("SystemStatus");

            #endregion
        }
    }
}
