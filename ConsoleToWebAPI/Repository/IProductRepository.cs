using ConsoleToWebAPI.Models;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Repository // Repository folder basically contain Services. For example, EmailSender service, etc.
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAllProducts();

        string GetName();
    }
}