using fastwebsite.Entities;

namespace fastwebsite.Builder
{
    //Builder Pattern - Lân
    public class ProductBuilder
    {
        private int _productId;
        private string _productName = string.Empty;
        private decimal _price;
        private string? _img;
        private string? _des;
        private int? _cateId;
        private ICollection<CartItem> _cartItems = new List<CartItem>();
        private Category? _cate;
        private ICollection<OrderItem> _orderItems = new List<OrderItem>();
        private ICollection<Review> _reviews = new List<Review>();

        public ProductBuilder SetProductId(int productId)
        {
            _productId = productId;
            return this;
        }

        public ProductBuilder SetProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ProductBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public ProductBuilder SetImage(string? img)
        {
            _img = img;
            return this;
        }

        public ProductBuilder SetDescription(string? des)
        {
            _des = des;
            return this;
        }

        public ProductBuilder SetCategoryId(int? cateId)
        {
            _cateId = cateId;
            return this;
        }

        public ProductBuilder SetCategory(Category? cate)
        {
            _cate = cate;
            return this;
        }

        public ProductBuilder AddCartItem(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
            return this;
        }

        public ProductBuilder AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
            return this;
        }

        public ProductBuilder AddReview(Review review)
        {
            _reviews.Add(review);
            return this;
        }

        public Product Build()
        {
            return new Product
            {
                ProductId = _productId,
                ProductName = _productName,
                Price = _price,
                Img = _img,
                Des = _des,
                CateId = _cateId,
                Cate = _cate,
                CartItems = _cartItems,
                OrderItems = _orderItems,
                Reviews = _reviews
            };
        }
    }
}
