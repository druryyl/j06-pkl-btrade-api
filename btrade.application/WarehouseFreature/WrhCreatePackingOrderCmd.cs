using btrade.domain.WarehouseFeature;
using MediatR;
using Nuna.Lib.ValidationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.application.WarehouseFreature
{
    public record WrhSavePackingOrderCmd(
        string PackingOrderId, string PackingOrderDate, 
        string CustomerId, string CustomerCode, string CustomerName, string Alamat, string NoTelp,
        string FakturId, string FakturCode, string FakturDate, string AdminName,
        decimal Latitude, decimal Longitude, int Accuracy,
        string WarehouseCode, string OfficeCode,
        IEnumerable<WrhSavePackingOrderItemCmd> ListItem) : IRequest, IPackingOrderKey;
    
    public record WrhSavePackingOrderItemCmd(
        int NoUrut, string BrgId, string BrgCode, 
        string BrgNme, string KategoriName,
        int QtyBesar, string SatBesar,
        int QtyKecil, string SatKecil, string DepoId);

    public class WrhSavePackingOrderCmdHandler : IRequestHandler<WrhSavePackingOrderCmd>
    {
        private readonly IPackingOrderDal _packingOrderDal;
        private readonly IPackingOrderItemDal _packingOrderItemDal;

        public WrhSavePackingOrderCmdHandler(IPackingOrderDal packingOrderDal, IPackingOrderItemDal packingOrderItemDal)
        {
            _packingOrderDal = packingOrderDal;
            _packingOrderItemDal = packingOrderItemDal;
        }

        public Task Handle(WrhSavePackingOrderCmd req, CancellationToken cancellationToken)
        {
            var listItem = req.ListItem.Select(item => new PackingOrderItemModel(
                req.PackingOrderId,
                item.NoUrut, item.BrgId, item.BrgNme, item.BrgCode, item.KategoriName,
                item.QtyBesar, item.SatBesar,
                item.QtyKecil, item.SatKecil, item.DepoId)).ToList();
            var timestampNow = DateTime.Now;
            var packingOrder = new PackingOrderModel(
                req.PackingOrderId, req.PackingOrderDate.ToDate(DateFormatEnum.YMD_HMS), 
                req.CustomerId, req.CustomerCode, req.CustomerName, req.Alamat, req.NoTelp,
                req.Latitude, req.Longitude, req.Accuracy,
                req.FakturId, req.FakturCode, req.FakturDate.ToDate(DateFormatEnum.YMD_HMS), req.AdminName,
                req.WarehouseCode, req.OfficeCode, timestampNow, new DateTime(3000,1,1),
                listItem);

            var packingOrderDb = _packingOrderDal.GetData(req);
            if (packingOrderDb is not null)
                _packingOrderDal.Update(packingOrder);
            else
                _packingOrderDal.Insert(packingOrder);

            _packingOrderItemDal.Delete(req);
            _packingOrderItemDal.Insert(listItem);

            return Task.CompletedTask;
        }
    }
}
