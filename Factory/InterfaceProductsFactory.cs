using fastwebsite.Entities;

namespace fastwebsite.Factory
{
    public interface InterfaceProductsFactory
    {
        Product CreateProduct(string productName, decimal price, string? img, string? des, int? cateId);
    }
}
