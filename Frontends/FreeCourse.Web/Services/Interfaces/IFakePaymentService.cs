using System;
using System.Threading.Tasks;
using FreeCourse.Web.Models.FakePayment;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface IFakePaymentService
    {
        Task<bool> ReceivePayment(FakePaymentInfoInput fakePaymentInfo);
    }
}
