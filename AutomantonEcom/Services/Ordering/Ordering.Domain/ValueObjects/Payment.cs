using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public string PaymentMethod { get; } = default!;

        protected Payment()
        {

        }
        private Payment(string cardname, string cardnumber, string expiration, string cvv, string paymentmethod)
        {
            CardName = cardname; CardNumber = cardnumber; Expiration = expiration; CVV = cvv; PaymentMethod = paymentmethod;
        }
        public static Payment Of(string cardname, string cardnumber, string expiration, string cvv, string paymentmethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardname);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardnumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);
            return new Payment(cardname, cardnumber, expiration, cvv, paymentmethod);
        }
    }
}
