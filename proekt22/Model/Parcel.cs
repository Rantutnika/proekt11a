using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt22
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public  ParcelType ParcelTypes { get; set; }
        public int ParcelTypeId { get; set; }

    }
}
