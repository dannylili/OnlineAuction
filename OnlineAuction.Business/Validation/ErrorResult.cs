using System;
using System.Collections.Generic;
using OnlineAuction.Common.Classes;
using OnlineAuction.Common.Const;

namespace OnlineAuction.Business.Validation
{
    [Serializable]
    public class ErrorResult
    {
        #region 属性

        public List<Message> Message { get; set; }

        /// <summary>
        /// 判断是否有错误
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Message.Count > 0;
            }
            set;
        }

        #endregion

        #region 方法

        public void AddMessage(string messageKey, string messageValue)
        {
            Message.Add(new Message { MessageKey = messageKey, MessageValue = messageValue, MessageType = Constants.MessageType.messageTypeError });
        }

        public void AddMessage(string messageKey = null, string messageValue = null)
        {
            Message.Add(new Message { MessageKey = messageKey, MessageValue = messageValue, MessageType = Constants.MessageType.messageTypeInfor });
        }



        #endregion
    }
}
