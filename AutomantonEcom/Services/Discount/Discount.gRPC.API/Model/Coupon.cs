namespace Discount.gRPC.API.Model
{
    public class Coupon
    {
        public int ID { get; set; }
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Amount { get; set; }
    }
}
