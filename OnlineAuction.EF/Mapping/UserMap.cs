using System.Data.Entity.ModelConfiguration;
using OnlineAuction.Model;

namespace OnlineAuction.EF.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.ID);

            #region 复杂类型的映射

            this.Property(t => t.SystemStatus.Value).HasColumnName("SystemStatus");

            #endregion
        }
    }
}
