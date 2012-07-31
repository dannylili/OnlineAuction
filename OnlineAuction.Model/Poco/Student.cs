using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

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
    }
}
