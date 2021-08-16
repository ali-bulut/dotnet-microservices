using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models.Basket;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IDiscountService _discountService;

        public BasketService(HttpClient httpClient, IDiscountService discountService)
        {
            _httpClient = httpClient;
            _discountService = discountService;
        }

        public async Task AddBasketItem(BasketItemViewModel basketItem)
        {
            var basket = await Get();

            if(basket != null)
            {
                if(!basket.BasketItems.Any(x => x.CourseId == basketItem.CourseId))
                {
                    basket.BasketItems.Add(basketItem);
                }
            } else
            {
                basket = new BasketViewModel();
                basket.BasketItems.Add(basketItem);
            }

            await Upsert(basket);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            await CancelAppliedDiscount();
            var basket = await Get();
            if(basket == null)
            {
                return false;
            }

            var hasDiscount = await _discountService.GetDiscount(discountCode);
            if(hasDiscount == null)
            {
                return false;
            }

            basket.ApplyDiscount(hasDiscount.Code, hasDiscount.Rate);

            return await Upsert(basket);
        }

        public async Task<bool> CancelAppliedDiscount()
        {
            var basket = await Get();
            if(basket == null || basket.DiscountCode == null)
            {
                return false;
            }

            basket.CancelDiscount();

            return await Upsert(basket);
        }

        public async Task<bool> Delete()
        {
            var result = await _httpClient.DeleteAsync("baskets");
            return result.IsSuccessStatusCode;
        }

        public async Task<BasketViewModel> Get()
        {
            var response = await _httpClient.GetAsync("baskets");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var basket = await response.Content.ReadFromJsonAsync<Response<BasketViewModel>>();
            return basket.Data;
        }

        public async Task<bool> RemoveBasketItem(string courseId)
        {
            var basket = await Get();
            if(basket == null)
            {
                return false;
            }

            var deletedBasketItem = basket.BasketItems.FirstOrDefault(x => x.CourseId == courseId);
            if(deletedBasketItem == null)
            {
                return false;
            }

            var deleteResult = basket.BasketItems.Remove(deletedBasketItem);
            if (!deleteResult)
            {
                return false;
            }

            if (!basket.BasketItems.Any())
            {
                basket.DiscountCode = null;
            }

            return await Upsert(basket);
        }

        public async Task<bool> Upsert(BasketViewModel basket)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketViewModel>("baskets", basket);

            return response.IsSuccessStatusCode;
        }
    }
}
