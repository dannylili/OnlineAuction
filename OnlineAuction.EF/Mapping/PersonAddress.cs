using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using OnlineAuction.Model;

namespace OnlineAuction.EF.Mapping
{
    public class PersonAddressMap : EntityTypeConfiguration<PersonAddress>
    {
        public PersonAddressMap()
        {
            this.HasKey(t => t.ID);
        }
    }
}
