using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeCourse.Web.Models.FakePayment;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class FakePaymentService : IFakePaymentService
    {
        private readonly HttpClient _httpClient;

        public FakePaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfo)
        {
            var response = await _httpClient.PostAsJsonAsync<FakePaymentInfoInput>("fakepayments", fakePaymentInfo);
            return response.IsSuccessStatusCode;
        }
    }
}
