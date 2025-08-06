using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using Nuna.Lib.TransactionHelper;

namespace btrade.application.UseCase;

public record SalesPersonSyncCommand(IEnumerable<SalesPersonType> ListSalesPerson) : IRequest<Unit>;

public class SalesPersonSyncHandler : IRequestHandler<SalesPersonSyncCommand, Unit>
{
    private readonly ISalesPersonDal _salesPersonDal;

    public SalesPersonSyncHandler(ISalesPersonDal salesPersonDal)
    {
        _salesPersonDal = salesPersonDal;
    }

    public Task<Unit> Handle(SalesPersonSyncCommand request, CancellationToken cancellationToken)
    {
        using var trans = TransHelper.NewScope();
        _salesPersonDal.Delete();
        foreach (var item in request.ListSalesPerson)
        {
            _salesPersonDal.Insert(item);
        }
        trans.Complete();
        return Task.FromResult(Unit.Value);
    }
}