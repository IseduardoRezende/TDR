using AutoMapper;
using TDR.Models;
using TDR.ViewModels.Votacao;

namespace TDRDomain.Profiles
{
    public class VoteProfile : Profile
    {
        public VoteProfile()
        {
            CreateMap<CreateVoteViewModel, Vote>();
            CreateMap<UpdateVoteViewModel, Vote>();
            CreateMap<Vote, ReadVoteViewModel>();
            CreateMap<ReadVoteViewModel, CreateVoteViewModel>();
            CreateMap<ReadVoteViewModel, UpdateVoteViewModel>();
        }
    }
}
