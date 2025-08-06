using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;

namespace btrade.application.UseCase;

public record CustomerListDataQuery() : IRequest<IEnumerable<CustomerType>>;

public class CustomerListDataHandler : IRequestHandler<CustomerListDataQuery, IEnumerable<CustomerType>>
{
    private readonly ICustomerDal _customerDal;

    public CustomerListDataHandler(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public Task<IEnumerable<CustomerType>> Handle(CustomerListDataQuery request, CancellationToken cancellationToken)
    {
        var listData = _customerDal.ListData();
        return Task.FromResult(listData.HasValue
            ? listData.Value
            : Enumerable.Empty<CustomerType>());
    }
}
