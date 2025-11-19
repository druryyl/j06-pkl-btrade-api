using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;

namespace btrade.application.UseCase;

public record CustomerClearUpdatedFlagCmd() : IRequest;

public class CustomerClearUpdatedFlagHandler : IRequestHandler<CustomerClearUpdatedFlagCmd>
{
    private readonly ICustomerDal _customerDal;

    public CustomerClearUpdatedFlagHandler(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public Task Handle(CustomerClearUpdatedFlagCmd request, CancellationToken cancellationToken)
    {
        var listDataMayBe = _customerDal.ListData();
        var listCustomer = listDataMayBe.HasValue
            ? listDataMayBe.Value
            : Enumerable.Empty<CustomerType>();
        var listUpdated = listCustomer.Where(x => x.IsUpdated)?.ToList()
                          ?? new List<CustomerType>();
        foreach (var item in listUpdated)
        {
            var cleanItem = item with { IsUpdated = false };
            _customerDal.Update(cleanItem);
        }
        
        return Task.FromResult(Unit.Value);
    }
}