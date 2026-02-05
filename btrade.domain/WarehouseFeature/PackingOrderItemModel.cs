using btrade.domain.SalesFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.WarehouseFeature
{
    public class PackingOrderItemModel
    {

        public PackingOrderItemModel(string packingOrderId, int noUrut, 
            string brgId, string brgCode, string brgName, string kategoriName,
            int qtyBesar, string satBesar, int qtyKecil, string satKecil)
        {
            PackingOrderId = packingOrderId;
            NoUrut = noUrut;
            BrgId = brgId;
            BrgCode = brgCode;
            BrgName = brgName;
            KategoriName = kategoriName;
            QtyBesar = qtyBesar;
            SatBesar = satBesar;
            QtyKecil = qtyKecil;
            SatKecil = satKecil;
        }

        public string PackingOrderId { get; }
        public int NoUrut { get; }
        public string BrgId { get; }
        public string BrgCode { get; }
        public string BrgName { get; }
        public string KategoriName { get; }
        public int QtyBesar { get; }
        public string SatBesar { get; }
        public int QtyKecil { get; }
        public string SatKecil { get; }
    }
}
