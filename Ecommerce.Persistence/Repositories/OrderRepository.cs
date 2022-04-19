using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceContext context) : base(context)
        {
        }

        public async Task<Order> CreateOrderFromCartAsync(int cartId, int adressId)
        {
            var cart = await _context.Carts
                .Include(x => x.ProductsInCart)
                .ThenInclude(x => x.ProductVariant)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Tax)
                .SingleOrDefaultAsync(x => x.Id == cartId);
            var order = new Order () { AdressId = adressId, UserId = cart.UserId,  };

            var response = await _context.Orders.AddAsync(order);

            var products = new List<OrderProducts>();

            foreach (var product in cart.ProductsInCart)
            {
                var orderproduct = new OrderProducts() { Price = product.ProductVariant.Price, ProductVariantId = product.ProductVariant.Id, Quantity = product.Quantity, TaxValue = product.ProductVariant.Product.Tax.Value };
                products.Add(orderproduct);
            }

            response.Entity.Products = products;

            var prductsInCart = await _context.CartProducts.Where(x => x.CartId == cartId).ToListAsync();

            _context.CartProducts.RemoveRange(prductsInCart);

            await _context.SaveChangesAsync();


            return response.Entity;
        }

        public async Task<Order> GetUserOrderAsync(int userId, int orderId)
        {
            var order = await _context.Orders.Where(x => x.UserId == userId && x.Id == orderId).FirstOrDefaultAsync();

            return order;
        }

        public async Task<IReadOnlyList<Order>> GetUserOrdersAsync(int userId)
        {
            var orders = await _context.Orders.Where(x => x.UserId == userId).Include(x => x.Adress).Include(x => x.Products).ThenInclude(x => x.ProductVariant).ThenInclude(x => x.Product).ToListAsync();

            return orders;
        }
    }
}
