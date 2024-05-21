using Discount.gRPC.API.Data;
using Discount.gRPC.API.Model;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.API.Services
{
    public class DiscountService(DiscountContext discount)
        : DiscountProtoService.DiscountProtoServiceBase
    {


        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = new Coupon
            {
                Description = request.Coupon.Description,
                ProductName = request.Coupon.Productname,
                Amount = request.Coupon.Amount
            };
            var couponEntity = discount.coupons.Add(coupon);
            await discount.SaveChangesAsync();

            var couponModel = new CouponModel
            {
                ID = couponEntity.Entity.ID,
                Productname = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
            };
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discount.coupons.Where(x => x.ID == request.Coupon.ID).FirstOrDefaultAsync();
            if (coupon is null)
            {
                throw new RpcException(Status.DefaultCancelled, $"Coupon for product {request.Coupon.Productname} not found!!");
            }
            else
            {
                coupon.ProductName = request.Coupon.Productname;
                coupon.Description = request.Coupon.Description;
                coupon.Amount = request.Coupon.Amount;
                discount.coupons.Attach(coupon);
                await discount.SaveChangesAsync();
            }
            return new CouponModel
            {
                ID = request.Coupon.ID,
                Amount = request.Coupon.Amount,
                Description = request.Coupon.Description,
                Productname = request.Coupon.Productname
            };
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discount.coupons.Where(x => x.ProductName == request.Productname).FirstOrDefaultAsync();
            if (coupon is null)
            {
                return new CouponModel { ID = 0, Amount = 0, Description = "No Coupon", Productname = request.Productname };
            }
            var couponModel = new CouponModel
            {
                ID = coupon.ID,
                Productname = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
            };
            return couponModel;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discount.coupons.Where(x => x.ProductName == request.Productname).FirstOrDefaultAsync();
            if (coupon is null)
            {
                throw new RpcException(Status.DefaultCancelled, $"No Coupon found for product {request.Productname}!!");
            }
            discount.Remove(coupon);
            await discount.SaveChangesAsync();
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
