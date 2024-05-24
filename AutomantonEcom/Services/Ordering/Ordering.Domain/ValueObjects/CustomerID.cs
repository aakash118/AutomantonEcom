
using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects
{
    public record CustomerID
    {
        public Guid value { get; }
        private CustomerID(Guid Value) => value = Value;
        public static CustomerID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CustomerID cannot be empty.");
            }
            return new CustomerID(value);
        }
    }
}
