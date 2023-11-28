using System;
using Grp3_GrpVI_ITELEC1C.Data;
using Grp3_GrpVI_ITELEC1C.Models;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Services
{
	public class ProductDataService : IProductDataService
	{
        private AppDbContext _appDbContext;

        public ProductDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            var selectedProduct = await _appDbContext.Products.Where(x => product.Id == x.Id).FirstOrDefaultAsync();

            if (selectedProduct != null)
            {
                _appDbContext.Products.Remove(selectedProduct);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            var selectedProduct = await _appDbContext.Products.Where(x => product.Id == x.Id).FirstOrDefaultAsync();

            if (selectedProduct != null)
            {
                selectedProduct.ProductName = product.ProductName;
                selectedProduct.Description = product.Description;
                selectedProduct.Price = product.Price;
                selectedProduct.Stock = product.Stock;

                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}

