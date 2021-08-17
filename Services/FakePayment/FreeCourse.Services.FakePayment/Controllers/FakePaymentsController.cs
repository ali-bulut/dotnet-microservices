using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.FakePayment.Models;
using FreeCourse.Shared.ControllerBase;
using FreeCourse.Shared.Dtos;
using FreeCourse.Shared.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    public class FakePaymentsController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FakePaymentsController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

       [HttpPost]
       public async Task<IActionResult> ReceivePayment(FakePaymentInfoDto fakePaymentInfo)
       {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));
            var createOrderMessageCommand = new CreateOrderMessageCommand
            {
                CustomerId = fakePaymentInfo.Order.CustomerId,
                Province = fakePaymentInfo.Order.Address.Province,
                District = fakePaymentInfo.Order.Address.District,
                Line = fakePaymentInfo.Order.Address.Line,
                Street = fakePaymentInfo.Order.Address.Street,
                ZipCode = fakePaymentInfo.Order.Address.ZipCode,
            };

            fakePaymentInfo.Order.OrderItems.ForEach(x =>
            {
                createOrderMessageCommand.OrderItems.Add(new OrderItem
                {
                    PictureUrl = x.PictureUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName
                });
            });

            await sendEndpoint.Send(createOrderMessageCommand);


            return CreateActionResultInstance(Shared.Dtos.Response<NoContent>.Success(200));
       }
    }
}
