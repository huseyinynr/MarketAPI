using MarketAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        string barcode,
        string city)
    {
        var result = await _db.MarketProducts
            .Where(mp =>
                mp.Product.Barcode == barcode &&
                mp.Market.City == city)
            .Select(mp => new
            {
                mp.Product.Barcode,
                mp.Product.Name,
                mp.Product.PhotoUrl,
                mp.Price,
                MarketName = mp.Market.Name
            })
            .ToListAsync();

        return Ok(result);
    }
}