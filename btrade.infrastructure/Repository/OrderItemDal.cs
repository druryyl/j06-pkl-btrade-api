using btrade.application.Contract;
using btrade.domain.Model;
using btrade.infrastructure.Helpers;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace btrade.infrastructure.Repository
{
    public class OrderItemDal : IOrderItemDal
    {
        private readonly DatabaseOptions _opt;

        public OrderItemDal(IOptions<DatabaseOptions> opt)
        {
            _opt = opt.Value;
        }

        public void Insert(IEnumerable<OrderItemType> listModel)
        {
            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            using var bcp = new SqlBulkCopy(conn);
            conn.Open();

            bcp.AddMap("OrderId","OrderId");
            bcp.AddMap("NoUrut","NoUrut");
            bcp.AddMap("BrgId","BrgId");
            bcp.AddMap("BrgCode","BrgCode");
            bcp.AddMap("BrgName","BrgName");
            bcp.AddMap("KategoriName","KategoriName");
            bcp.AddMap("QtyBesar","QtyBesar");
            bcp.AddMap("SatBesar","SatBesar");
            bcp.AddMap("QtyKecil","QtyKecil");
            bcp.AddMap("SatKecil","SatKecil");
            bcp.AddMap("Konversi","Konversi");
            bcp.AddMap("UnitPrice","UnitPrice");
            bcp.AddMap("LineTotal", "LineTotal");

            var fetched = listModel.ToList();
            bcp.DestinationTableName = "dbo.BTRADE_OrderItem";
            bcp.WriteToServer(fetched.AsDataTable());
        }

        public void Delete(IOrderKey key)
        {
            const string sql = @"
                DELETE FROM BTRADE_OrderItem
                WHERE OrderId = @OrderId";

            var dp = new DynamicParameters();
            dp.AddParam("OrderId", key.OrderId, System.Data.SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public IEnumerable<OrderItemType> ListData(IOrderKey filter)
        {
            const string sql = @"
                SELECT 
                    OrderId, NoUrut, BrgId, BrgCode, BrgName, KategoriName, 
                    QtyBesar, SatBesar, QtyKecil, SatKecil, Konversi, 
                    UnitPrice, LineTotal
                FROM BTRADE_OrderItem
                WHERE OrderId = @OrderId";

            var dp = new DynamicParameters();
            dp.AddParam("OrderId", filter.OrderId, System.Data.SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            return conn.Read<OrderItemType>(sql, dp);
        }
    }
}
