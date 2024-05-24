using Ordering.Domain.Abstractions;
using Ordering.Domain.Enums;
using Ordering.Domain.Events;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Domain
{
    public class Order : Aggregate<OrderID>
    {
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public CustomerID CustomerID { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; set; } = default!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice
        {
            get => OrderItems.Sum(x => x.Price * x.Quantity);
            private set { }
        }

        public static Order Create(OrderID orderid, CustomerID customerID, OrderName orderName, Address shippindaddress, Address billingaddress, Payment payment, decimal totalprice)
        {
            var order = new Order
            {
                ID = orderid,
                CustomerID = customerID,
                OrderName = orderName,
                ShippingAddress = shippindaddress,
                BillingAddress = billingaddress,
                Payment = payment,
                TotalPrice = totalprice
            };
            order.AddDominEvent(new OrderCreatedEvent(order));
            return order;
        }

        public void Update(OrderName orderName, Address shippindaddress, Address billingaddress, Payment payment, OrderStatus status)
        {
            OrderName = orderName;
            ShippingAddress = shippindaddress;
            BillingAddress = billingaddress;
            Payment = payment;
            Status = status;
            AddDominEvent(new OrderUpdatedEvent(this));
        }

        public void Add(ProductID productID, int quantity, decimal price)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            var orderitem = new OrderItem(ID, productID, quantity, price);
            _orderItems.Add(orderitem);
        }

        public void Remove(ProductID productID)
        {
            ArgumentNullException.ThrowIfNull(productID);
            var orderitem = _orderItems.FirstOrDefault(x => x.ProductID == productID);
            if(orderitem is not null)
               _orderItems.Remove(orderitem);

        }
    }
}
