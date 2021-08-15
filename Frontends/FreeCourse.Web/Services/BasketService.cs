using System;
using System.Net.Http;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Basket;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddBasketItem(BasketItemViewModel basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApplyDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelAppliedDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<BasketViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveBasketItem(string courseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(BasketViewModel basket)
        {
            throw new NotImplementedException();
        }
    }
}
