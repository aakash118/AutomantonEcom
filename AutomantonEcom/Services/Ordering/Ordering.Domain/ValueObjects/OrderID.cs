using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public record OrderID
    {
        public Guid value { get; }
        private OrderID(Guid Value) =>value = Value;
        public static OrderID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("OrderID cannot be empty.");
            }
            return new OrderID(value);
        }
    }
    
}
