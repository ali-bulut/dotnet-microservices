using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Order;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface IOrderService
    {
        // sync => checkout info will be sent to order microservice directly.
        Task<OrderCreatedStatusViewModel> CreateOrder(CheckoutInfoInput checkoutInfo);

        // async => checkout info will be sent to queue.
        Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfo);

        Task<List<OrderViewModel>> GetOrder();
    }
}
