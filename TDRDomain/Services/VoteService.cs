using AutoMapper;
using TDR.Models;
using TDR.ViewModels.Votacao;
using TDRData.Repositories.IRepositories;
using TDRDomain.Services.IServices;

namespace TDRDomain.Services
{
    public class VoteService : BaseService<CreateVoteViewModel, UpdateVoteViewModel, ReadVoteViewModel, Vote>, IVoteService
    {
        private readonly IMenuService _menuService;

        public VoteService(IVoteRepository voteRepository, IMenuService menuService, IMapper mapper) : base(voteRepository, mapper)
        {
            _menuService = menuService;
        }        

        public ushort GetTotalVotes(long menuId)
        {
            return Convert.ToUInt16(base
                .ListAsync(c => c.MenuFk == menuId && c.State == true)
                .GetAwaiter()
                .GetResult()
                .Count(c => c.State));
        }

        public bool CanVote(ReadVoteViewModel vote)
        {
            if (vote == null)
                return false;                  

            if (vote!.InteractionsNumber < 1)
                return false;

            var currentDate = DateTime.Now;

            if (currentDate < vote.MenuStartVote && currentDate > vote.MenuEndVote)
                return false;

            return true;
        }

        public async Task<ReadVoteViewModel?> GetCurrentVoteAsync(long userFk, long periodFk)
        {
            //Obtendo registro de Voto do dia
            var vote = await base
                .FindByAsync(c => c.UserFk == userFk && c.Menu.Date == DateTime.Now.Date &&
                             c.Menu.PeriodFk == periodFk &&
                             c.Menu.DeletedAt == null, "Menu");

            if (vote != null)
                return vote;

            //Caso não exista registro de Voto é consultado a Refeição do dia
            var menu = await _menuService.GetCurrentMenuAsync(periodFk);

            if (menu == null) return null;

            return new ReadVoteViewModel { MenuFk = (long)menu.Id!, UserFk = userFk, MenuName = menu.Name, MenuDate = menu.Date };
        }

        public async Task<ReadVoteViewModel?> GetCurrentVoteByIdAsync(long id, long userFk, long periodFk)
        {
            //Obtendo registro de Voto do dia por Id específico
            var vote = await base
                .FindByAsync(c => c.Id == id && c.UserFk == userFk && c.Menu.Date == DateTime.Now.Date &&
                             c.Menu.PeriodFk == periodFk &&
                             c.Menu.DeletedAt == null, "Menu");

            if (vote != null)
                return vote;

            //Caso não exista registro de Voto é consultado a Refeição do dia
            var menu = await _menuService.GetCurrentMenuAsync(periodFk);

            if (menu == null) return null;

            return new ReadVoteViewModel { MenuFk = (long)menu.Id!, UserFk = userFk, MenuName = menu.Name, MenuDate = menu.Date };
        }

        public override Task<ReadVoteViewModel> IsValidCreate(CreateVoteViewModel createModel)
        {
            return Task.FromResult(base.BuildReadModel());
        }

        public override Task<ReadVoteViewModel> IsValidUpdate(UpdateVoteViewModel updateModel)
        {
            return Task.FromResult(base.BuildReadModel());
        }

        public override Vote UpdateFields(Vote model, UpdateVoteViewModel updateModel)
        {
            model.State = updateModel.State;
            model.InteractionsNumber = updateModel.InteractionsNumber--;
            return model;
        }
    }
}
