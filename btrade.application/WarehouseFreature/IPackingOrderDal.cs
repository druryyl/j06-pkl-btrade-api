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
        IListData<PackingOrderView, DateTime, string>
    {
    }

    public class PackingOrderView : IPackingOrderKey
    {
        public PackingOrderView(string packingOrderId, DateTime packingOrderDate, 
            string customerId, string customerCode, string customerName, string alamat, string noTelp, 
            decimal latitude, decimal longitude, int accuracy, 
            string fakturId, string fakturCode, DateTime fakturDate, string adminName, 
            string warehouseDesc, string officeCode, DateTime updateTimestamp)
        {
            PackingOrderId = packingOrderId;
            PackingOrderDate = packingOrderDate;
            CustomerId = customerId;
            CustomerCode = customerCode;
            CustomerName = customerName;
            Alamat = alamat;
            NoTelp = noTelp;
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
            FakturId = fakturId;
            FakturCode = fakturCode;
            FakturDate = fakturDate;
            AdminName = adminName;
            WarehouseDesc = warehouseDesc;
            OfficeCode = officeCode;
            UpdateTimestamp = updateTimestamp;
        }

        public string PackingOrderId { get; private set; }
        public DateTime PackingOrderDate { get; private set; }

        public string CustomerId { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerName { get; private set; }
        public string Alamat { get; private set; }
        public string NoTelp { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public int Accuracy { get; private set; }

        public string FakturId { get; private set; }
        public string FakturCode { get; private set; }
        public DateTime FakturDate { get; private set; }
        public string AdminName { get; private set; }

        public string WarehouseDesc { get; private set; }
        public string OfficeCode { get; private set; }
        public DateTime UpdateTimestamp { get; private set; }
    }
}
