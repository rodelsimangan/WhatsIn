﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface IStoreAppService : IApplicationService
    {
        Task<List<StoreDto>> GetStores(string filter, bool isDeleted);
        Task<List<StoreDto>> GetStores(int? categoryId, int? locationId, bool isDeleted);
        Task<StoreDto> GetStore(long id);
        Task<StoreDto> GetStoreByUser(long userId);
        Task UpsertStore(StoreDto input);
        Task DeleteStore(long id);
    }
}
