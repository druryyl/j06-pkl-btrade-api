﻿using btrade.domain.Model;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.ValidationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.Contract
{
    public interface IOrderDal :
        IInsert<OrderModel>,
        IUpdate<OrderModel>,
        IDelete<IOrderKey>,
        IGetDataMayBe<OrderModel, IOrderKey>,
        IListDataMayBe<OrderModel, Periode>
    {
        void Delete();
    }
}
