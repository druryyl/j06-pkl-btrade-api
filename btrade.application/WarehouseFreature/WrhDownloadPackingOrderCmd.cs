//using btrade.domain.WarehouseFeature;
//using MediatR;

//namespace btrade.application.WarehouseFreature
//{
//    public record WrhDownloadPackingOrderCmd(string StartTimestamp, string WarehouseCode, int pageSize)
//        : IRequest<WrhDownloadPackingOrderResp>;
//    public record WrhDownloadPackingOrderResp(
//        string LastTimestamp, 
//        IEnumerable<WrhDownloadPackingOrderRespHdr> ListData);
//    public record WrhDownloadPackingOrderRespHdr(
//        string PackingOrderId, string PackingOrderDate,
//        string CustomerId, string CustomerCode, string CustomerName, string Alamat, string NoTelp,
//        decimal Latitude, decimal Longitude, int Accuracy,
//        string FakturId, string FakturCode, string FakturDate, string AdminName,
//        string WarehouseCode, string OfficeCode, 
//        IEnumerable<WrhDownloadPackingOrderRespDtl> ListItem);
//    public record WrhDownloadPackingOrderRespDtl(
//        int NoUrut, string BrgId, string BrgCode, string BrgNme, string KategoriName,
//        int QtyBesar, string SatBesar, int QtyKecil, string SatKecil, string depoId);

//    public class  WrhDownloadPackingOrderHandler : IRequestHandler<WrhDownloadPackingOrderCmd, WrhDownloadPackingOrderResp> 
//    {
//        private readonly IPackingOrderDal _packingOrderDal;
//        private readonly IPackingOrderItemDal _packingOrderItemDal;

//        public WrhDownloadPackingOrderHandler(IPackingOrderDal packingOrderDal, 
//            IPackingOrderItemDal packingItemOrderDal)
//        {
//            _packingOrderDal = packingOrderDal;
//            _packingOrderItemDal = packingItemOrderDal;
//        }

//        public Task<WrhDownloadPackingOrderResp> Handle(WrhDownloadPackingOrderCmd request, CancellationToken cancellationToken)
//        {
//            var timeStamp = DateTime.Parse(request.StartTimestamp);
//            var listHdr = _packingOrderDal
//                .ListData(timeStamp, request.WarehouseCode)?.ToList() 
//                ?? new List<PackingOrderModel>();
//            listHdr = listHdr
//                .OrderBy(x => x.UpdateTimestamp)
//                .Take(request.pageSize)
//                .ToList();

//            foreach(var hdr in listHdr)
//            {
//                hdr.SetDownloadTimestamp(DateTime.Now);
//                var listItem = _packingOrderItemDal
//                    .ListData(hdr)?.ToList()
//                    ?? new List<PackingOrderItemModel>();
//                hdr.SetListItem(listItem);
//            }

//            var resultList = new List<PackingOrderModel>();
//            foreach (var item in listHdr)
//            {
//                if (item.ListDepo.Where(x => x.DepoId == request.WarehouseCode).Any())
//                {
//                    resultList.Add(item);
//                };
//            }

//            var result = resultList
//                .Select(x => new WrhDownloadPackingOrderRespHdr(
//                    x.PackingOrderId,
//                    x.PackingOrderDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    x.CustomerId,
//                    x.CustomerCode,
//                    x.CustomerName,
//                    x.Alamat,
//                    x.NoTelp,
//                    x.Latitude,
//                    x.Longitude,
//                    x.Accuracy,
//                    x.FakturId,
//                    x.FakturCode,
//                    x.FakturDate.ToString("yyyy-MM-dd HH:mm:ss"),
//                    x.AdminName,
//                    x.WarehouseCode,
//                    x.OfficeCode,
//                    x.ListItem.Select(i => new WrhDownloadPackingOrderRespDtl(
//                        i.NoUrut,
//                        i.BrgId,
//                        i.BrgCode,
//                        i.BrgName,
//                        i.KategoriName,
//                        i.QtyBesar,
//                        i.SatBesar,
//                        i.QtyKecil,
//                        i.SatKecil,
//                        i.DepoId
//                    ))
//                ));

//            foreach(var hdr in resultList)
//            {
//                _packingOrderDal.Update(hdr);
//            }

//            return Task.FromResult(new WrhDownloadPackingOrderResp(
//                listHdr.Any() ? listHdr.Max(x => x.UpdateTimestamp).ToString("yyyy-MM-dd HH:mm:ss") : request.StartTimestamp,
//                result
//            ));
//        }
//    }
//}
