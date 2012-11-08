using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAuction.Common.Const
{
    public static partial class Constants
    {
        /// <summary>
        /// <c>MessageType</c>消息常量类
        /// </summary>
        public static class MessageType
        {
            /// <summary>
            /// Infor
            /// </summary>
            public const string messageTypeInfor = "Infor";

            /// <summary>
            /// Error
            /// </summary>
            public const string messageTypeError = "Error";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class ViewStatus
        {
            /// <summary>
            /// 添加成功时
            /// </summary>
            public const string TempDataAddSucess = "AddScucess";

            /// <summary>
            /// 添加失败时
            /// </summary>
            public const string TempDataAddFail = "AddFail";
        }
    }
}
