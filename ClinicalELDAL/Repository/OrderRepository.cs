using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalELDAL.Repository
{
    public class OrderRepository : BaseRepository
    {
        public List<EntityLayer.Order> GetActiveOrder()
        {
            IEnumerable<EntityLayer.Order> query = from order in mycontext.Orders.Include("User")
                                                   where order.Status == "active"
                                                   select order;
            return query.ToList();
        }

        public List<EntityLayer.OrderItem> GetOrderItems(int orderid)
        {
            IEnumerable<EntityLayer.OrderItem> query = from orderitem in mycontext.OrderItems.Include("Drug")
                                                       where orderitem.OrderID == orderid
                                                       select orderitem;
            return query.ToList();
        }

        public bool ApproveOrder(int orderid)
        {
            EntityLayer.Order query = (from order in mycontext.Orders
                                       where order.OrderID == orderid
                                       select order).SingleOrDefault();
            query.Status = "inactive";
            mycontext.Entry(query).State = System.Data.Entity.EntityState.Modified;
            int result = mycontext.SaveChanges();
            return result > 0;
        }
    }
}
