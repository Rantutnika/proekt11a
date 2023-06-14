using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt22.Controller
{
    internal class TypeLogic
    {
        private CourierContext _corContext=new CourierContext();
        public List<ParcelType> GetAllTypes()
        {
            return _corContext.ParcelTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return _corContext.ParcelTypes.Find(id).Name;
        }
    }
}
