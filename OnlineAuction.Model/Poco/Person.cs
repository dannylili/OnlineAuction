using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Extension;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Model
{
    /// <summary>
    /// 个人基本信息
    /// 记录某个User的基本信息
    /// </summary>
    public class Person : IOnlineAuctionBaseEntity
    {
        #region General Property

        public int ID { get; set; }

        [Description("学着身份")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "填写名称")]
        [MaxLength(10, ErrorMessage = "{0}不能大于10个字符")]
        [MinLength(2, ErrorMessage = "{0}不能少于2个字符")]
        public int Name { get; set; }

        [Description("年龄")]
        public Nullable<int> Age { get; set; }

        [Description("出生日期")]
        Nullable<System.DateTime> BorthData { get; set; }

        [Description("性别")]
        public Nullable<int> Sex { get; set; }

        [Description("昵称")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "填写名称")]
        [MaxLength(8, ErrorMessage = "{0}不能大于10个字符")]
        [MinLength(2, ErrorMessage = "{0}不能少于2个字符")]
        public string Nickname { get; set; }

        #endregion

        #region Complex Propert

        public SystemStatusWrapper SystemStatus { get; set; }

        #endregion

        #region Reference Property


        #endregion
    }
}
