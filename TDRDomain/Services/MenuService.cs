﻿using AutoMapper;
using TDR.Enums;
using TDR.Models;
using TDR.ViewModels.Cardapios;
using TDRData.Repositories.IRepositories;
using TDRDomain.Services.IServices;

namespace TDRDomain.Services
{
    public class MenuService : BaseService<CreateMenuViewModel, UpdateMenuViewModel, ReadMenuViewModel, Menu>, IMenuService
    {
        public MenuService(IMenuRepository menuRepository, IMapper mapper) : base (menuRepository, mapper)
        {
        }

        public async Task<IEnumerable<ReadMenuViewModel>> GetMenusAsync(long periodFk)
        {
            return periodFk == (long)PeriodType.Both
                ? await base.ListAsync(c => c.DeletedAt == null)
                : await base.ListAsync(c => c.PeriodFk == periodFk && c.DeletedAt == null);
        }

        public async Task<ReadMenuViewModel?> GetMenuByIdAsync(long id, long periodFk)
        {
            return periodFk == (long)PeriodType.Both
                ? await base.FindByAsync(c => c.Id == id && c.DeletedAt == null)
                : await base.FindByAsync(c => c.Id == id && c.PeriodFk == periodFk && c.DeletedAt == null);
        }

        public async Task<ReadMenuViewModel?> GetCurrentMenuAsync(long periodFk)
        {
            return await base
                .FindByAsync(c => c.Date == DateTime.Now.Date && c.PeriodFk == periodFk && c.DeletedAt == null);
        }

        public override Task<ReadMenuViewModel> IsValidCreate(CreateMenuViewModel createModel)
        {
            return Task.FromResult(base.BuildReadModel());
        }

        public override Task<ReadMenuViewModel> IsValidUpdate(UpdateMenuViewModel updateModel)
        {
            return Task.FromResult(base.BuildReadModel());
        }

        public override Menu UpdateFields(Menu model, UpdateMenuViewModel updateModel)
        {
            model.Name = updateModel.Name;
            model.Date = updateModel.Date;
            model.StartVote = updateModel.StartVote;
            model.EndVote = updateModel.EndVote;

            return model;
        }
    }
}
