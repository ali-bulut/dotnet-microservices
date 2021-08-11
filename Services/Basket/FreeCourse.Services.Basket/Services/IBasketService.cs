﻿using System;
using System.Threading.Tasks;
using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> Upsert(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
