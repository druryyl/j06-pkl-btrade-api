using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.UseCase
{
    public record WilayahListQuery() : IRequest<IEnumerable<WilayahType>>;

    public class WilayahListQueryHandler : IRequestHandler<WilayahListQuery, IEnumerable<WilayahType>>
    {
        private readonly IWilayahDal _wilayahDal;

        public WilayahListQueryHandler(IWilayahDal wilayahDal)
        {
            _wilayahDal = wilayahDal;
        }

        public Task<IEnumerable<WilayahType>> Handle(WilayahListQuery request, CancellationToken cancellationToken)
        {
            var listData = _wilayahDal.ListData();
            return Task.FromResult(listData.HasValue
                ? listData.Value
                : Enumerable.Empty<WilayahType>());
        }
    }
}
