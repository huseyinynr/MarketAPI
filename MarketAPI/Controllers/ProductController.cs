using MarketAPI.Data;
using MarketAPI.Models;
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

    [HttpPost("add-product")]
    public async Task<IActionResult> AddProductToMarket([FromBody] AddProduct request)
    {
      
        if (request.Price <= 0)
        {
            return BadRequest(new { message = "The product price must be greater than 0." });
        }

       
        var marketExists = await _db.Markets.AnyAsync(m => m.Id == request.MarketId);
        if (!marketExists)
        {
            return NotFound(new { message = "The specified MarketId could not be found." });
        }

   
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Barcode == request.Barcode);

        if (product == null)
        {

            product = new Product
            {
                Barcode = request.Barcode,
                Name = request.Name,
                PhotoUrl = request.PhotoUrl
            };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

     
        var isAlreadyLinked = await _db.MarketProducts
            .AnyAsync(mp => mp.MarketId == request.MarketId && mp.ProductId == product.Id);

        if (isAlreadyLinked)
        {
            return BadRequest(new { message = "This product already exists in this store. You can use the discount method to update the price." });
        }

        
        var marketProduct = new MarketProduct
        {
            MarketId = request.MarketId,
            ProductId = product.Id,
            Price = request.Price,
            DiscountPrice = null
        };

        _db.MarketProducts.Add(marketProduct);
        await _db.SaveChangesAsync(); 

        return Ok(new
        {
            message = "Product successfully created and added to the store!",
            productId = product.Id,
            marketId = request.MarketId
        });
    }

    [HttpGet("findbybarccodenumber")]
    public async Task<IActionResult> Search(string barcode, string city)
    {
        var result = await _db.MarketProducts
            .Where(mp => mp.Product.Barcode == barcode && mp.Market.City == city)
            .Select(mp => new
            {
                mp.Product.Barcode,
                mp.Product.Name,
                mp.Product.PhotoUrl,
                mp.Price,
                mp.DiscountPrice,
                MarketName = mp.Market.Name
            })
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet("getallproducts")]
    public async Task<IActionResult> GetProductsByMarket(int marketId)
    {
        var result = await _db.MarketProducts
            .Where(mp => mp.MarketId == marketId)
            .Select(mp => new
            {
                mp.Product.Barcode,
                mp.Product.Name,
                mp.Product.PhotoUrl,
                OriginalPrice = mp.Price,
                CurrentDiscountPrice = mp.DiscountPrice,
                MarketName = mp.Market.Name
            })
            .ToListAsync();

        if (result == null || !result.Any())
        {
            return NotFound(new { message = "No products were found for this store." });
        }

        return Ok(result);
    }

    [HttpPatch("clear-discount")]
    public async Task<IActionResult> ClearDiscount(string barcode)
    {
        var marketProducts = await _db.MarketProducts
            .Where(mp => mp.Product.Barcode == barcode)
            .ToListAsync();

        if (!marketProducts.Any())
        {
            return NotFound(new { message = "Product not found." });
        }

        foreach (var mp in marketProducts)
        {
            mp.DiscountPrice = null;
        }

        await _db.SaveChangesAsync();

        return Ok(new { message = "Discounts cleared for all markets", affectedRows = marketProducts.Count });
    }
}