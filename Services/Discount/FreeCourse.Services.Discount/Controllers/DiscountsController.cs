using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.Discount.Services;
using FreeCourse.Shared.ControllerBase;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    public class DiscountsController : CustomBaseController
    {
        private readonly ISharedIdentityService _sharedIdentityService;
        private readonly IDiscountService _discountService;

        public DiscountsController(ISharedIdentityService sharedIdentityService, IDiscountService discountService)
        {
            _sharedIdentityService = sharedIdentityService;
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResultInstance(await _discountService.GetById(id));
        }

        [Route("/api/[controller]/[action]/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, userId));
        }

        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Save(discount));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.Update(discount));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.Delete(id));
        }
    }
}
