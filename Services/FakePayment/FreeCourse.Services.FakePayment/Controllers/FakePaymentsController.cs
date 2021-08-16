using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.FakePayment.Models;
using FreeCourse.Shared.ControllerBase;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    public class FakePaymentsController : CustomBaseController
    {
       [HttpPost]
       public IActionResult ReceivePayment(FakePaymentInfoDto fakePaymentInfo)
       {
           return CreateActionResultInstance(Response<NoContent>.Success(200));
       }
    }
}
