using btrade.application.Contract;
using btrade.domain.Model;
using MediatR;
using Nuna.Lib.TransactionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.UseCase
{
    public record WilayahSyncCommand(IEnumerable<WilayahType> ListWilayah) : IRequest<Unit>;
    public class WilayahSyncHandler : IRequestHandler<WilayahSyncCommand, Unit>
    {
        private readonly IWilayahDal _wilayahDal;

        public WilayahSyncHandler(IWilayahDal wilayahDal)
        {
            _wilayahDal = wilayahDal;
        }

        public Task<Unit> Handle(WilayahSyncCommand request, CancellationToken cancellationToken)
        {
            using var trans = TransHelper.NewScope();

            _wilayahDal.Delete();

            foreach (var item in request.ListWilayah)
            {
                _wilayahDal.Insert(item);
            }

            trans.Complete();
            return Task.FromResult(Unit.Value);
        }
    }
}
