using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using OnlineAuction.Model;


namespace OnlineAuction.EF
{
    public class OnlineAuctionDbContent : DbContext
    {
        public OnlineAuctionDbContent()
            : base()
        { }

        public OnlineAuctionDbContent(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        DbSet<Student> Student { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
