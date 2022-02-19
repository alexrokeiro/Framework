using Application.Dto;
using Domain;
using Infra;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class GetDividersAndPrimeDividersCommand
    {
        public class Contract : IRequest<Result<GetDividersAndPrimeDividersDTO>>
        {
            public int Number { get; set; }
        }

        public class Handler : IRequestHandler<Contract, Result<GetDividersAndPrimeDividersDTO>>
        {
            public async Task<Result<GetDividersAndPrimeDividersDTO>> Handle(Contract request, CancellationToken cancellationToken)
            {
                if (request == null)
                    return Result<GetDividersAndPrimeDividersDTO>.CreateFail("Request não pode ser null.");

                DomainResult<Number> domainResult = Number.Create(request.Number);

                if (!domainResult.IsSucess)
                    return Result<GetDividersAndPrimeDividersDTO>.CreateFail(domainResult.Error);

                GetDividersAndPrimeDividersDTO dividersAndPrimeDividersDTO = new GetDividersAndPrimeDividersDTO();
                dividersAndPrimeDividersDTO.Number = request.Number;
                dividersAndPrimeDividersDTO.Dividers = domainResult.Model.GetDividers();
                dividersAndPrimeDividersDTO.PrimeDividers = domainResult.Model.GetPrimeDividers();

                return Result<GetDividersAndPrimeDividersDTO>.CreateSucess(dividersAndPrimeDividersDTO);
            }
        }
    }
}
