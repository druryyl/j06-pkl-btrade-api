using btrade.application.WarehouseFreature;
using btrade.domain.WarehouseFeature;
using btrade.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.ValidationHelper;
using System.Data;
using System.Data.SqlClient;

namespace btrade.infrastructure.WarehouseFeature;
public class PackingOrderDal : IPackingOrderDal
{
    private readonly DatabaseOptions _opt;

    public PackingOrderDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(PackingOrderModel model)
    {
        const string sql = @"
            INSERT INTO BTRGX_PackingOrder(
                PackingOrderId, PackingOrderDate, PackingOrderCode,
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                FakturId, FakturCode, FakturDate, AdminName,
                Latitude, Longitude, Accuracy,
                WarehouseCode, OfficeCode)
            VALUES(
                @PackingOrderId, @PackingOrderDate, @PackingOrderCode,
                @CustomerId, @CustomerCode, @CustomerName, @Alamat, @NoTelp,
                @FakturId, @FakturCode, @FakturDate, @AdminName,
                @Latitude, @Longitude, @Accuracy,
                @WarehouseCode, @OfficeCode)
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", model.PackingOrderId, SqlDbType.VarChar);
        dp.AddParam("@PackingOrderDate", model.PackingOrderDate, SqlDbType.DateTime);
        dp.AddParam("@PackingOrderCode", model.PackingOrderCode, SqlDbType.VarChar);

        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Alamat", model.Alamat, SqlDbType.VarChar);
        dp.AddParam("@NoTelp", model.NoTelp, SqlDbType.VarChar);

        dp.AddParam("@FakturId", model.FakturId, SqlDbType.VarChar);
        dp.AddParam("@FakturCode", model.FakturCode, SqlDbType.VarChar);
        dp.AddParam("@FakturDate", model.FakturDate, SqlDbType.DateTime);
        dp.AddParam("@AdminName", model.AdminName, SqlDbType.VarChar);

        dp.AddParam("@Latitude", model.Latitude, SqlDbType.Decimal);
        dp.AddParam("@Longitude", model.Longitude, SqlDbType.Decimal);
        dp.AddParam("@Accuracy", model.Accuracy, SqlDbType.Int);

        dp.AddParam("@WarehouseCode", model.WarehouseCode, SqlDbType.VarChar);
        dp.AddParam("@OfficeCode", model.OfficeCode, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(PackingOrderModel model)
    {
        const string sql = @"
            UPDATE BTRGX_PackingOrder
            SET
                PackingOrderDate = @PackingOrderDate,
                PackingOrderCode = @PackingOrderCode,
                CustomerId = @CustomerId,
                CustomerCode = @CustomerCode,
                CustomerName = @CustomerName,
                Alamat = @Alamat,
                NoTelp = @NoTelp,
                FakturId = @FakturId,
                FakturCode = @FakturCode,
                FakturDate = @FakturDate,
                AdminName = @AdminName,
                Latitude = @Latitude,
                Longitude = @Longitude,
                Accuracy = @Accuracy,
                WarehouseCode = @WarehouseCode,
                OfficeCode = @OfficeCode
            WHERE
                PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", model.PackingOrderId, SqlDbType.VarChar);
        dp.AddParam("@PackingOrderDate", model.PackingOrderDate, SqlDbType.DateTime);
        dp.AddParam("@PackingOrderCode", model.PackingOrderCode, SqlDbType.VarChar);

        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Alamat", model.Alamat, SqlDbType.VarChar);
        dp.AddParam("@NoTelp", model.NoTelp, SqlDbType.VarChar);

        dp.AddParam("@FakturId", model.FakturId, SqlDbType.VarChar);
        dp.AddParam("@FakturCode", model.FakturCode, SqlDbType.VarChar);
        dp.AddParam("@FakturDate", model.FakturDate, SqlDbType.DateTime);
        dp.AddParam("@AdminName", model.AdminName, SqlDbType.VarChar);

        dp.AddParam("@Latitude", model.Latitude, SqlDbType.Decimal);
        dp.AddParam("@Longitude", model.Longitude, SqlDbType.Decimal);
        dp.AddParam("@Accuracy", model.Accuracy, SqlDbType.Int);

        dp.AddParam("@WarehouseCode", model.WarehouseCode, SqlDbType.VarChar);
        dp.AddParam("@OfficeCode", model.OfficeCode, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(IPackingOrderKey key)
    {
        const string sql = @"
            DELETE FROM BTRGX_PackingOrder
            WHERE PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", key.PackingOrderId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public PackingOrderModel GetData(IPackingOrderKey key)
    {
        const string sql = @"
            SELECT
                PackingOrderId, PackingOrderDate, PackingOrderCode,
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                FakturId, FakturCode, FakturDate, AdminName,
                Latitude, Longitude, Accuracy,
                WarehouseCode, OfficeCode
            FROM BTRGX_PackingOrder
            WHERE PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", key.PackingOrderId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.ReadSingle<PackingOrderModel>(sql, dp);
    }

    public IEnumerable<PackingOrderModel> ListData(Periode filter)
    {
        const string sql = @"
            SELECT
                PackingOrderId, PackingOrderDate, PackingOrderCode,
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                FakturId, FakturCode, FakturDate, AdminName,
                Latitude, Longitude, Accuracy,
                WarehouseCode, OfficeCode
            FROM BTRGX_PackingOrder
            WHERE PackingOrderDate BETWEEN @Tgl1 AND @Tgl1
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@Tgl1", filter.Tgl1, SqlDbType.DateTime);
        dp.AddParam("@Tgl2", filter.Tgl2, SqlDbType.DateTime);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.Read<PackingOrderModel>(sql, dp);
    }
}