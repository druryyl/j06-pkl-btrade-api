using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using System.Collections.Generic;

namespace btrade.application.UseCase;

public record CustomerListUpdatedQuery() : IRequest<IEnumerable<CustomerType>>;
public class CustomerListUpdatedHandler : IRequestHandler<CustomerListUpdatedQuery, IEnumerable<CustomerType>>
{
    private readonly ICustomerDal _customerDal;

    public CustomerListUpdatedHandler(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public Task<IEnumerable<CustomerType>> Handle(CustomerListUpdatedQuery request, CancellationToken cancellationToken)
    {
        var listDataMayBe = _customerDal.ListData();
        var listCustomer = listDataMayBe.HasValue
            ? listDataMayBe.Value
            : Enumerable.Empty<CustomerType>();
        var listUpdated = listCustomer.Where(x => x.IsUpdated)?.ToList()
                          ?? new List<CustomerType>();
        return Task.FromResult(listUpdated.AsEnumerable());
    }
}