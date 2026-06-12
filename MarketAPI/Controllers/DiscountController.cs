using MarketAPI.Data;
using MarketAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    [ApiController]
    [Route("api/discounts")]
    public class DiscountController : ControllerBase
    {
        private readonly AppDbContext _db;

        public DiscountController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPut("make-discount")]
        public async Task<IActionResult> MakeDiscount([FromBody] MakeDiscount request)
        {
            if (request.NewPrice <= 0)
            {
                return BadRequest(new { message = "The discounted price cannot be 0 or less." });
            }

            var marketProduct = await _db.MarketProducts
                .FirstOrDefaultAsync(mp => mp.MarketId == request.MarketId && mp.ProductId == request.ProductId);

            if (marketProduct == null)
            {
                return NotFound(new { message = "This product could not be found in this store." });
            }

            if (request.NewPrice >= marketProduct.Price)
            {
                return BadRequest(new { message = "The discounted price cannot be higher than or equal to the regular price of the product." });
            }

            marketProduct.DiscountPrice = request.NewPrice;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Discount applied successfully!", currentPrice = marketProduct.DiscountPrice });
        }

        [HttpGet("getdiscountsbylocation")]
        public async Task<IActionResult> GetDiscounts(string city)
        {
            var result = await _db.MarketProducts
                .Where(x => x.Market.City == city && x.DiscountPrice != null)
                .Select(x => new
                {
                    x.Product.Barcode,
                    x.Product.Name,
                    x.Product.PhotoUrl,
                    OriginalPrice = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    MarketName = x.Market.Name,
                    City = x.Market.City
                })
                .ToListAsync();

            return Ok(result);
        }
    }
}