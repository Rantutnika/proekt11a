using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt22.Controller
{
    public class ParcelLogic
    {
        private CourierContext corContext = new CourierContext();
        public Parcel Get(int id)
        {
            Parcel findParc = corContext.Parcels.Find(id);
            if (findParc != null)
            {
                corContext.Entry(findParc).Reference(x => x.ParcelTypes).Load();
            }
            return findParc;
        }
        public List<Parcel>GetAll()
        {
            return corContext.Parcels.Include("Type").ToList();
        }
        public void Create(Parcel par)
        {
            corContext.Parcels.Add(par);
            corContext.SaveChanges();
        }
        public void Updates(int id, Parcel par)
        {
            Parcel findParc=corContext.Parcels.Find(id);
            if (findParc == null)
            {
                return;
            }
            findParc.Name= par.Name;
            findParc.Price = par.Price;
            findParc.Number = par.Number;
            findParc.Description = par.Description;
            findParc.Weight = par.Weight;
            findParc.ParcelTypes= par.ParcelTypes;
            corContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Parcel findParc = corContext.Parcels.Find(id);
            corContext.Parcels.Remove(findParc);
            corContext.SaveChanges();
        }
    }
}
