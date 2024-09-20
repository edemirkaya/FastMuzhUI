using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MasterProfiles.Queries.GetList;

public class GetListMasterProfileQuery : IRequest<GetListResponse<GetListMasterProfileListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMasterProfileQueryHandler : IRequestHandler<GetListMasterProfileQuery, GetListResponse<GetListMasterProfileListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMasterProfileRepository _masterProfileRepository;

        public GetListMasterProfileQueryHandler(IMapper mapper, IMasterProfileRepository masterProfileRepository)
        {
            _mapper = mapper;
            _masterProfileRepository = masterProfileRepository;
        }

        public async Task<GetListResponse<GetListMasterProfileListItemDto>> Handle(GetListMasterProfileQuery request, CancellationToken cancellationToken)
        {
            Paginate<MasterProfile> masterProfile = await _masterProfileRepository.GetListAsync(
                include: m => m.Include(m => m.Master).Include(m => m.MasterWorkPhotos).Include(m => m.ServiceCategories),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = _mapper.Map<GetListResponse<GetListMasterProfileListItemDto>>(masterProfile);
            return response;
        }
    }
}
