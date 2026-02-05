using btrade.domain.SalesFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.domain.WarehouseFeature
{
    public class PackingOrderModel : IPackingOrderKey
    {
        private readonly List<PackingOrderItemModel> _listItem;

        public PackingOrderModel(string packingOrderId, DateTime packingOrderDate, 
            string customerId, string customerCode, string customerName, string alamat, string noTelp,
            decimal latitude, decimal longitude, int accuracy,
            string fakturId, string fakturCode, DateTime fakturDate, string adminName, 
            string warehouseCode, string officeCode, DateTime updateTimestamp, DateTime downloadTimestamp,
            IEnumerable<PackingOrderItemModel> listItem)
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

            WarehouseCode = warehouseCode;
            OfficeCode = officeCode;
            UpdateTimestamp = updateTimestamp;
            DownloadTimestamp = downloadTimestamp;

            _listItem = listItem.ToList();
        }

        public PackingOrderModel(string packingOrderId, DateTime packingOrderDate,
            string customerId, string customerCode, string customerName, string alamat, string noTelp,
            decimal latitude, decimal longitude, int accuracy,
            string fakturId, string fakturCode, DateTime fakturDate, string adminName,
            string warehouseCode, string officeCode, DateTime updateTimestamp, DateTime downloadTimestamp)
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

            WarehouseCode = warehouseCode;
            OfficeCode = officeCode;
            UpdateTimestamp = updateTimestamp;
            DownloadTimestamp = downloadTimestamp;
            _listItem = new List<PackingOrderItemModel>();
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

        public string WarehouseCode { get; private set; }
        public string OfficeCode { get; private set; }
        public DateTime UpdateTimestamp { get; private set; }
        public DateTime DownloadTimestamp { get; private set; }

        public IEnumerable<PackingOrderItemModel> ListItem => _listItem;

        public void SetDownloadTimestamp(DateTime timestamp)
        {
            DownloadTimestamp = timestamp;
        }
        public void SetListItem(IEnumerable<PackingOrderItemModel> listItem)
        {
            _listItem.Clear();
            _listItem.AddRange(listItem);
        }
    }

    public interface IPackingOrderKey
    {
        string PackingOrderId { get; }
    }
}
