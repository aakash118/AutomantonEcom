using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Domain
{
    public class OrderItem : Entity<OrderItemID>
    {
        internal OrderItem(OrderID orderid, ProductID productid, int quantity, decimal price)
        {
            ID = OrderItemID.Of(Guid.NewGuid());
            OrderID = orderid;
            ProductID = productid;
            Quantity = quantity;
            Price = price;
        }
        public OrderID OrderID { get; private set; } = default!;
        public ProductID ProductID { get; private set; } = default!;
        public int Quantity { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
    }
}
