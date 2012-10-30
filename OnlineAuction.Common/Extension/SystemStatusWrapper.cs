using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Common.Enum;


namespace OnlineAuction.Common.Extension
{
    /// <summary>
    /// 操作符重载
    /// 用操作符重载定义EF和DB直接使用枚举（由于数据库无法直接调用POCO中的枚举）
    /// http://www.189works.com/article-58067-1.html
    /// </summary>
    public class SystemStatusWrapper
    {
        #region Primitive Properties

        public byte Value
        {
            get { return (byte)EnumValue; }
            set { EnumValue = (SystemStatus)value; }
        }

        public SystemStatus EnumValue { get; set; }

        #endregion

        #region Wrapper Elements

        /// <summary>
        /// SystemStatusWrapper为类型转换运算符的目标类型。
        /// </summary>
        /// <param name="valueWrapper"></param>
        /// <returns></returns>
        public static implicit operator SystemStatusWrapper(SystemStatus value)
        {
            return new SystemStatusWrapper { EnumValue = value };
        }

        public static implicit operator SystemStatus(SystemStatusWrapper valueWrapper)
        {
            if (valueWrapper == null)
                throw new ArgumentOutOfRangeException(string.Format(@"Cannot 
                    convert SystemStatusWrapper value:{0} to SystemStatus type", valueWrapper));

            return valueWrapper.EnumValue;
        }


        #endregion

    }
}
