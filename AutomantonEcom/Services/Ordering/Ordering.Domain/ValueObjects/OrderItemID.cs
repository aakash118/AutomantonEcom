using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public record OrderItemID
    {
        public Guid value { get; }
        private OrderItemID(Guid Value) => value = Value;
        public static OrderItemID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if(value == Guid.Empty)
            {
                throw new DomainException("OrderItemID cannot be empty.");
            }
            return new OrderItemID(value); 
        }
    }
}
