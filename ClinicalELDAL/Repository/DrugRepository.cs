using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class BaseRepository
    {
        protected EntityLayer.Team3CASEntities1 mycontext;
        public BaseRepository()
        {
            mycontext = new EntityLayer.Team3CASEntities1();
        }
    }
    public class DrugRepository : BaseRepository
    {
        public List<EntityLayer.Drug> GetAllDrugs()
        {
            IEnumerable<EntityLayer.Drug> query = from drug in mycontext.Drugs
                                                  orderby drug.Name ascending
                                                  select drug;
            return query.ToList();
        }

        public EntityLayer.Drug GetSpecificDrug(int drugid)
        {
            IEnumerable<EntityLayer.Drug> query = from drug in mycontext.Drugs
                                                  where drug.DrugID==drugid
                                                  orderby drug.Name ascending
                                                  select drug;
            return query.Single();
        }

        public void AddOrder(List<EntityLayer.OrderItem> oi , int docid)
        {
            EntityLayer.Order ord = new EntityLayer.Order();
            ord.OrderDate = DateTime.Now;
            ord.Status = "active";
            ord.UserID = docid;

            foreach (var item in oi)
            {
                ord.OrderItems.Add(item);
            }
            mycontext.Orders.Add(ord);
            int ret = mycontext.SaveChanges();         
        }

        public List< EntityLayer.Drug> GetSearchDrug(string drugname)
        {
            IEnumerable<EntityLayer.Drug> query = from drug in mycontext.Drugs
                                                  where drug.Name.ToLower().StartsWith(drugname.ToLower())
                                                  select drug;
            return query.ToList();
        }

        public bool AddDrug(EntityLayer.Drug drg)
        {
            mycontext.Drugs.Add(drg);
            int result = mycontext.SaveChanges();
            return result > 0;
        }

    }
}
