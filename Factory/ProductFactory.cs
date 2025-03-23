using fastwebsite.Entities;

namespace fastwebsite.Factory
{
    public class ProductFactory : InterfaceProductsFactory
    {
        public Product CreateProduct(string productName, decimal price, string? img, string? des, int? cateId)
        {
            return new Product
            {
                ProductName = productName,
                Price = price,
                Img = img,
                Des = des,
                CateId = cateId
            };
        }
    }
}
