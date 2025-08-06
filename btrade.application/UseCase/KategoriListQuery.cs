using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;

namespace btrade.application.UseCase
{
    public record KategoriListQuery() : IRequest<IEnumerable<KategoriType>>;

    public class KategoriListQueryHandler : IRequestHandler<KategoriListQuery, IEnumerable<KategoriType>>
    {
        private readonly IKategoriDal _kategoriDal;

        public KategoriListQueryHandler(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public Task<IEnumerable<KategoriType>> Handle(KategoriListQuery request, CancellationToken cancellationToken)
        {
            var listData = _kategoriDal.ListData();
            return Task.FromResult(listData.HasValue
                ? listData.Value
                : Enumerable.Empty<KategoriType>());
        }
    }
}
