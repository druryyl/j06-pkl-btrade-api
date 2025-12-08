using btrade.domain.Model;
using Nuna.Lib.DataAccessHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.Contract
{
    public interface IWilayahDal :
        IInsert<WilayahType>,
        IUpdate<WilayahType>,
        IDelete<IWilayahKey>,
        IGetDataMayBe<WilayahType, IWilayahKey>,
        IListDataMayBe<WilayahType, IServerId>
    {
        void Delete(IServerId server);
    }
}
