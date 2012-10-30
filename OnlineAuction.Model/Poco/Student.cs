using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using OnlineAuction.Model.Poco;
using OnlineAuction.Common.Extension;

namespace OnlineAuction.Model
{
    public class Student
    {
        public Student()
        {

        }

        public int ID { get; set; }
        public Nullable<int> Age { get; set; }
        public string Name { get; set; }

        #region Complex Propert

        public SystemStatusWrapper SystemStatus { get; set; }

        #endregion
    }
}
