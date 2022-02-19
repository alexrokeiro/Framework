using Domain;
using Infra;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class GetPrimeDividersCommand
    {
        public class Contract : IRequest<Result<List<int>>>
        {
            public int Number { get; set; }
        }

        public class Handler : IRequestHandler<Contract, Result<List<int>>>
        {
            public async Task<Result<List<int>>> Handle(Contract request, CancellationToken cancellationToken)
            {
                if (request == null)
                    return Result<List<int>>.CreateFail("Request não pode ser null.");

                DomainResult<Number> domainResult = Number.Create(request.Number);

                if (!domainResult.IsSucess)
                    return Result<List<int>>.CreateFail(domainResult.Error);

                return Result<List<int>>.CreateSucess(domainResult.Model.GetPrimeDividers());

            }
        }
    }
}
