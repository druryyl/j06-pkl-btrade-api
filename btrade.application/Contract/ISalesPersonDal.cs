using btrade.domain.Model;
using Nuna.Lib.DataAccessHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.Contract;

public interface ISalesPersonDal :
    IInsert<SalesPersonType>,
    IUpdate<SalesPersonType>,
    IDelete<ISalesPersonKey>,
    IGetDataMayBe<SalesPersonType, ISalesPersonKey>,
    IListDataMayBe<SalesPersonType, IServerId>
{
    void Delete(IServerId server);
}
