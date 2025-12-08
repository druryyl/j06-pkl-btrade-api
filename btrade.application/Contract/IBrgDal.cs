using btrade.domain.Model;
using Nuna.Lib.DataAccessHelper;

namespace btrade.application.Contract;

public interface IBrgDal :
    IInsert<BrgType>,
    IUpdate<BrgType>,
    IDelete<IBrgKey>,
    IGetDataMayBe<BrgType, IBrgKey>,
    IListDataMayBe<BrgType, IServerId>
{
    void Delete(IServerId serverId);
}