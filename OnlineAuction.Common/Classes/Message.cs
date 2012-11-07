using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAuction.Common.Classes
{
    /// <summary>
    /// 消息类
    /// </summary>
    [Serializable]
    public sealed class Message
    {
        public string MessageKey { get; set; }
        public string MessageValue { get; set; }

        public string MessageType { get; set; }
        public int MessageDuration { get; set; }

    }
}
