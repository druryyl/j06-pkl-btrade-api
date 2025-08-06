using btrade.domain.Model;
using Nuna.Lib.DataAccessHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.Contract
{
    public interface IKategoriDal :
        IInsert<KategoriType>,
        IUpdate<KategoriType>,
        IDelete<IKategoriKey>,
        IGetDataMayBe<KategoriType, IKategoriKey>,
        IListDataMayBe<KategoriType>
    {
        void Delete();
    }
}
