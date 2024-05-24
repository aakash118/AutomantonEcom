using Ordering.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public record ProductID
    {
        public Guid value { get; }
        public ProductID(Guid Value) => value = Value;

        public static ProductID Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("ProductID cannot be empty.");
            }
            return new ProductID(value);
        }
    }
}
