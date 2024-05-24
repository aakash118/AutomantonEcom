using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Domain
{
    public class Customer : Entity<CustomerID>
    {
        public string Name { get; private set; } = default!;
        public string Mail { get; private set; } = default!;

        public static Customer Create(CustomerID customerID, string name, string mail)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(mail);
            var customer = new Customer
            {
                Name = name,
                ID = customerID,
                Mail = mail
            };
            return customer;
        }
    }
}
