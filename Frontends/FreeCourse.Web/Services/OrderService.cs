using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Order;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderCreatedStatusViewModel> CreateOrder(CheckoutInfoInput checkoutInfo)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderViewModel>> GetOrder()
        {
            throw new NotImplementedException();
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfo)
        {
            throw new NotImplementedException();
        }
    }
}
