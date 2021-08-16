using System;
namespace FreeCourse.Services.FakePayment.Models
{
    public class FakePaymentInfoDto
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
