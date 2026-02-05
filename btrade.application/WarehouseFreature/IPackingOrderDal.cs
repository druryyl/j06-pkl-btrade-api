using btrade.domain.WarehouseFeature;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.ValidationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.WarehouseFreature
{
    public interface IPackingOrderDal : 
        IInsert<PackingOrderModel>,
        IUpdate<PackingOrderModel>,
        IDelete<IPackingOrderKey>,
        IGetData<PackingOrderModel, IPackingOrderKey>,
        IListData<PackingOrderModel, DateTime, string>
    {
    }
}
