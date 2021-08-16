using System;
using System.Threading.Tasks;
using FreeCourse.Web.Models.FakePayment;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class FakePaymentService : IFakePaymentService
    {
        public Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
