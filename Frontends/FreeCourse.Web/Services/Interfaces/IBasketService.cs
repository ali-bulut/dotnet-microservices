﻿using System;
using System.Threading.Tasks;
using FreeCourse.Web.Models.Basket;

namespace FreeCourse.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> Upsert(BasketViewModel basket);
        Task<BasketViewModel> Get();
        Task<bool> Delete();
        Task AddBasketItem(BasketItemViewModel basketItem);
        Task<bool> RemoveBasketItem(string courseId);
        Task<bool> ApplyDiscount(string discountCode);
        Task<bool> CancelAppliedDiscount();
    }
}
