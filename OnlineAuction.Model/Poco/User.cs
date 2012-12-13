using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Extension;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Model
{
    /// <summary>
    /// 登陆系统时的用户，在person中科院找到
    /// </summary>
    public class User : IOnlineAuctionBaseEntity
    {
        #region General Property

        public int ID { get; set; }

        [Display(Name = "用户类型：来源用户类型表[1:student 2:teach 3:admin,4:]")]
        [Required(ErrorMessage = "{0}必填")]
        public int UserType { get; set; }

        /// <summary>
        /// 如果一个User保存或在注册时同时填写Person基本信息，则修改User.PersonID为当天被添加Person的ID
        /// </summary>
        [Display(Name = "Person")]
        public Nullable<int> PersonID { get; set; }

        [Display(Name = "登陆名称")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(15, ErrorMessage = "{0}最大长度10")]
        [MinLength(5, ErrorMessage = "{0}最大长度5")]
        public string EntryName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}必填")]
        [MaxLength(10, ErrorMessage = "{0}最大长度10")]
        [MinLength(6, ErrorMessage = "{0}最大长度6")]
        // [RegularExpression("")]
        public string EntryVeryPwd { get; set; }

        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "{0}必填")]
        public string Email { get; set; }

        #endregion

        #region Complex Propert

        public SystemStatusWrapper SystemStatus { get; set; }

        #endregion

        #region Reference Property

        public virtual Person Person { get; set; }

        #endregion
    }
}
