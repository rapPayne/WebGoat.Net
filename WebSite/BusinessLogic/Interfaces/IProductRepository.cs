using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById(int ProductId);
        List<Product> GetTopProducts(int NumberOfProductsToReturn);
        List<Product> FindProducts(string ProductName);
    }
}
