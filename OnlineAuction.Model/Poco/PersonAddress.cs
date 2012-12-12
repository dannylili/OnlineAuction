using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineAuction.Model.Common;
using OnlineAuction.Common.Extension;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuction.Model
{
    public class PersonAddress : IOnlineAuctionBaseEntity
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Provice是必填的")]
        [MaxLength(100)]
        public string Provice { get; set; }

        [Required(ErrorMessage = "City是必填的")]
        public string City { get; set; }

        public SystemStatusWrapper SystemStatus { get; set; }
    }
}
