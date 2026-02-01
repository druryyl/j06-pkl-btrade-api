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

        public PackingOrderModel(string packingOrderId, DateTime packingOrderDate, string packingOrderCode, 
            string customerId, string customerCode, string customerName, string alamat, string noTelp, 
            string fakturId, string fakturCode, DateTime fakturDate, string adminName, 
            decimal latitude, decimal longitude, int accuracy, IEnumerable<PackingOrderItemModel> listItem)
        {
            PackingOrderId = packingOrderId;
            PackingOrderDate = packingOrderDate;
            PackingOrderCode = packingOrderCode;
            CustomerId = customerId;
            CustomerCode = customerCode;
            CustomerName = customerName;
            Alamat = alamat;
            NoTelp = noTelp;
            FakturId = fakturId;
            FakturCode = fakturCode;
            FakturDate = fakturDate;
            AdminName = adminName;
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
            _listItem = listItem.ToList();
        }

        public string PackingOrderId { get; private set; }
        public DateTime PackingOrderDate { get; private set; }
        public string PackingOrderCode { get; private set; }
        public string CustomerId { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerName { get; private set; }
        public string Alamat { get; private set; }
        public string NoTelp { get; private set; }

        public string FakturId { get; private set; }
        public string FakturCode { get; private set; }
        public DateTime FakturDate { get; private set; }
        public string AdminName { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public int Accuracy { get; private set; }

        public string WarehouseCode { get; private set; }
        public string OfficeCode { get; private set; }

        public IEnumerable<PackingOrderItemModel> ListItem => _listItem;
    }

    public interface IPackingOrderKey
    {
        string PackingOrderId { get; }
    }
}
