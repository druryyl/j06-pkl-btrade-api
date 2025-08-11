using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.Model
{
    public record OrderItemType(
        string OrderId,
        int NoUrut,
        string BrgId,
        string BrgCode,
        string BrgName,
        string KategoriName,
        int QtyBesar,
        string SatBesar,
        int QtyKecil,
        string SatKecil,
        int Konversi,
        decimal UnitPrice,
        decimal LineTotal
    ) : IOrderKey;
}
