using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using Nuna.Lib.TransactionHelper;

namespace btrade.application.UseCase;

public record CustomerSyncCommand(IEnumerable<CustomerType> ListCustomer) : IRequest<Unit>;

public class CustomerSyncHandler : IRequestHandler<CustomerSyncCommand, Unit>
{
    private readonly ICustomerDal _customerDal;

    public CustomerSyncHandler(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public Task<Unit> Handle(CustomerSyncCommand request, CancellationToken cancellationToken)
    {
        using var trans = TransHelper.NewScope();
        _customerDal.Delete();
        foreach (var item in request.ListCustomer)
        {
            _customerDal.Insert(item);
        }
        trans.Complete();
        return Task.FromResult(Unit.Value);
    }
}
