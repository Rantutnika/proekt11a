using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt22
{
    internal class CourierContext : DbContext
    {
        public CourierContext()
               : base("CourierContext")
        {

        }


        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelType> ParcelTypes { get; set; }

    }
}
