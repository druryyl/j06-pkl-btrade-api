using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using Nuna.Lib.TransactionHelper;

namespace btrade.application.UseCase;

public record BrgSyncCommand(IEnumerable<BrgType> ListBrg) : IRequest<Unit>;

public class BrgSyncHandler: IRequestHandler<BrgSyncCommand, Unit>
{
    private readonly IBrgDal _brgDal;
    public BrgSyncHandler(IBrgDal brgDal)
    {
        _brgDal = brgDal;
    }
    public Task<Unit> Handle(BrgSyncCommand request, CancellationToken cancellationToken)
    {
        using var trans = TransHelper.NewScope();
        _brgDal.Delete();
        foreach(var item in request.ListBrg)
        {
            _brgDal.Insert(item);
        }
        trans.Complete();
        return Task.FromResult(Unit.Value);
    }
}
