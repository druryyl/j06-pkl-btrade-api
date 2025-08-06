using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;

namespace btrade.application.UseCase
{
    public record BrgListDataQuery() : IRequest<IEnumerable<BrgType>>;

    public class BrgListDataHandler : IRequestHandler<BrgListDataQuery, IEnumerable<BrgType>>
    {
        private readonly IBrgDal _brgDal;
        public BrgListDataHandler(IBrgDal brgDal)
        {
            _brgDal = brgDal;
        }

        public Task<IEnumerable<BrgType>> Handle(BrgListDataQuery request, CancellationToken cancellationToken)
        {
            var listData = _brgDal.ListData();
            return Task.FromResult(listData.HasValue
                ? listData.Value
                : Enumerable.Empty<BrgType>());
        }
    }
}
