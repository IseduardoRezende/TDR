using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TDR.Extensions;
using TDR.Models;
using TDR.ViewModels.Votacao;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    public class VoteController : BaseController<CreateVoteViewModel, UpdateVoteViewModel, ReadVoteViewModel, Vote>
    {
        private readonly IVoteService _voteService;
        private readonly IMapper _mapper;

        public VoteController(IVoteService voteService, IMapper mapper)
            : base(voteService, mapper)
        {
            _voteService = voteService;
            _mapper = mapper;
        }

        public override async Task<IActionResult> Delete(long? id)
        {
            return await Task.FromResult(NoContent());
        }

        public override IActionResult Create()
        {
            var userId = Convert.ToInt64(User.GetClaimValueByType("Id"));
            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            var vote = _voteService.GetCurrentVoteAsync(userId, period).GetAwaiter().GetResult();

            //Não é possível criar um novo voto para menu inexistente ou registro de voto já existente
            if (vote == null || vote.Id != null)
                return RedirectToAction("Index");

            var createVote = _mapper.Map<CreateVoteViewModel>(vote);

            return View(createVote);
        }

        public override async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return BadRequest();

            var userId = Convert.ToInt64(User.GetClaimValueByType("Id"));
            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            var vote = await _voteService.GetCurrentVoteByIdAsync(id.Value, userId, period);

            if (vote == null)
                return NotFound();

            if (!_voteService.CanVote(vote))
                return RedirectToAction("Index");

            var updateVote = _mapper.Map<UpdateVoteViewModel>(vote);

            return View(updateVote); 
        }
        
        public override async Task<IActionResult> Index()
        {
            var userId = Convert.ToInt64(User.GetClaimValueByType("Id"));
            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            var vote = await _voteService.GetCurrentVoteAsync(userId, period);

            return vote == null
                ? View(Enumerable.Empty<ReadVoteViewModel>())
                : View(new[] { vote });
        }

        public override async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return BadRequest();

            var userId = Convert.ToInt64(User.GetClaimValueByType("Id"));
            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            var vote = await _voteService.GetCurrentVoteByIdAsync(id.Value, userId, period);

            if (vote == null)
                return NotFound();
            
            return View(vote);
        }
    }
}
