using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using FreeCourse.Shared.Services;
using FreeCourse.Web.Models.FakePayment;
using FreeCourse.Web.Models.Order;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFakePaymentService _fakePaymentService;
        private readonly HttpClient _httpClient;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderService(IFakePaymentService fakePaymentService, HttpClient httpClient, IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _fakePaymentService = fakePaymentService;
            _httpClient = httpClient;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<OrderCreatedStatusViewModel> CreateOrder(CheckoutInfoInput checkoutInfo)
        {
            var basket = await _basketService.Get();

            var payment = new FakePaymentInfoInput
            {
                CardName = checkoutInfo.CardName,
                CardNumber = checkoutInfo.CardNumber,
                Expiration = checkoutInfo.Expiration,
                CVV = checkoutInfo.CVV,
                TotalPrice = basket.TotalPrice
            };

            var paymentResponse = await _fakePaymentService.ReceivePayment(payment);

            if(!paymentResponse)
            {
                return new OrderCreatedStatusViewModel { Error = "Payment could not be received!", IsSuccessful = false };
            }

            var orderCreateInput = new OrderCreateInput
            {
                CustomerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput
                {
                    Province = checkoutInfo.Province,
                    District = checkoutInfo.District,
                    Line = checkoutInfo.Line,
                    Street = checkoutInfo.Street,
                    ZipCode = checkoutInfo.ZipCode
                }
            };

            basket.BasketItems.ForEach(x =>
            {
                orderCreateInput.OrderItems.Add(new OrderItemCreateInput
                {
                    ProductId = x.CourseId,
                    Price = x.CurrentPrice,
                    ProductName = x.CourseName,
                    PictureUrl = ""
                });
            });

            var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders", orderCreateInput);

            if (!response.IsSuccessStatusCode)
            {
                return new OrderCreatedStatusViewModel { Error = "Payment could not be received!", IsSuccessful = false };
            }

            var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedStatusViewModel>>();
            orderCreatedViewModel.Data.IsSuccessful = true;

            await _basketService.Delete();

            return orderCreatedViewModel.Data;
        }

        public async Task<List<OrderViewModel>> GetOrder()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");
            return response.Data;
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfo)
        {
            throw new NotImplementedException();
        }
    }
}
