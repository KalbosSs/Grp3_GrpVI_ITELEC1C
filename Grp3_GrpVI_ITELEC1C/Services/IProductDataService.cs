using System;
using Grp3_GrpVI_ITELEC1C.Models;

namespace Grp3_GrpVI_ITELEC1C.Services
{
	public interface IProductDataService
	{
        Task<List<Product>> GetProductsAsync();

        Task AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}

