using System;
namespace FreeCourse.Web.Models.Order
{
    public class OrderCreatedStatusViewModel
    {
        public int OrderId { get; set; }
        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
