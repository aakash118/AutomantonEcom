using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;

        protected Address()
        {

        }
        private Address(string firstname, string lastname, string emailaddress, string addressline, string country, string state, string zipcode)
        {
            FirstName = firstname;
            LastName = lastname;
            EmailAddress = emailaddress;
            AddressLine = addressline;
            Country = country;
            State = state;
            ZipCode = zipcode;
        }

        public static Address Of(string firstname, string lastname, string emailaddress, string addressline, string country, string state, string zipcode)
        {
            return new Address(firstname, lastname, emailaddress, addressline, country, state, zipcode);
        }
    }
}
