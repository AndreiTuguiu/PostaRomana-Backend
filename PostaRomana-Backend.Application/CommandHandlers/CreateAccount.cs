using MediatR;
using PostaRomanaBackend.Data;
using PostaRomanaBackend.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.WriteOperations
{
    public class CreateAccount : IRequestHandler<MakeNewAccount>
    {
        private readonly IMediator _mediator;
        private readonly AccountOptions _accountOptions;
        //private readonly RatingDbContext _dbContext;


        public CreateAccount(IMediator mediator, AccountOptions accountOptions)
        {
            _mediator = mediator;
            _accountOptions = accountOptions;
            //_dbContext = dbContext;
        }

        public async Task<Unit> Handle(MakeNewAccount request, CancellationToken cancellationToken)
        {
            // TODO: implement logic
            return Unit.Value;
        }        
    }
}