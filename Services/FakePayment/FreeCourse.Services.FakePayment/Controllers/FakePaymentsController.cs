using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Shared.ControllerBase;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    public class FakePaymentsController : CustomBaseController
    {
       [HttpPost]
       public IActionResult ReceivePayment()
       {
           return CreateActionResultInstance(Response<NoContent>.Success(200));
       }
    }
}
