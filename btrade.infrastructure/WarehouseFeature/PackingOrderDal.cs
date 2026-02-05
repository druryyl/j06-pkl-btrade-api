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
                PackingOrderId, PackingOrderDate,
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                Latitude, Longitude, Accuracy,
                FakturId, FakturCode, FakturDate, AdminName,
                WarehouseCode, OfficeCode, UpdateTimestamp, DownloadTimestamp)
            VALUES(
                @PackingOrderId, @PackingOrderDate, 
                @CustomerId, @CustomerCode, @CustomerName, @Alamat, @NoTelp,
                @Latitude, @Longitude, @Accuracy,
                @FakturId, @FakturCode, @FakturDate, @AdminName,
                @WarehouseCode, @OfficeCode, @UpdateTimestamp, @DownloadTimestamp)
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", model.PackingOrderId, SqlDbType.VarChar);
        dp.AddParam("@PackingOrderDate", model.PackingOrderDate, SqlDbType.DateTime);

        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Alamat", model.Alamat, SqlDbType.VarChar);
        dp.AddParam("@NoTelp", model.NoTelp, SqlDbType.VarChar);
        dp.AddParam("@Latitude", model.Latitude, SqlDbType.Decimal);
        dp.AddParam("@Longitude", model.Longitude, SqlDbType.Decimal);
        dp.AddParam("@Accuracy", model.Accuracy, SqlDbType.Int);

        dp.AddParam("@FakturId", model.FakturId, SqlDbType.VarChar);
        dp.AddParam("@FakturCode", model.FakturCode, SqlDbType.VarChar);
        dp.AddParam("@FakturDate", model.FakturDate, SqlDbType.DateTime);
        dp.AddParam("@AdminName", model.AdminName, SqlDbType.VarChar);

        dp.AddParam("@WarehouseCode", model.WarehouseCode, SqlDbType.VarChar);
        dp.AddParam("@OfficeCode", model.OfficeCode, SqlDbType.VarChar);
        dp.AddParam("@UpdateTimestamp", model.UpdateTimestamp, SqlDbType.DateTime);
        dp.AddParam("@DownloadTimestamp", model.DownloadTimestamp, SqlDbType.DateTime);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(PackingOrderModel model)
    {
        const string sql = @"
            UPDATE BTRGX_PackingOrder
            SET
                PackingOrderDate = @PackingOrderDate,

                CustomerId = @CustomerId,
                CustomerCode = @CustomerCode,
                CustomerName = @CustomerName,
                Alamat = @Alamat,
                NoTelp = @NoTelp,
                Latitude = @Latitude,
                Longitude = @Longitude,
                Accuracy = @Accuracy,

                FakturId = @FakturId,
                FakturCode = @FakturCode,
                FakturDate = @FakturDate,
                AdminName = @AdminName,

                WarehouseCode = @WarehouseCode,
                OfficeCode = @OfficeCode,
                UpdateTimestamp = @UpdateTimestamp,
                DownloadTimestamp = @DownloadTimestamp  
                
            WHERE
                PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", model.PackingOrderId, SqlDbType.VarChar);
        dp.AddParam("@PackingOrderDate", model.PackingOrderDate, SqlDbType.DateTime);

        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Alamat", model.Alamat, SqlDbType.VarChar);
        dp.AddParam("@NoTelp", model.NoTelp, SqlDbType.VarChar);
        dp.AddParam("@Latitude", model.Latitude, SqlDbType.Decimal);
        dp.AddParam("@Longitude", model.Longitude, SqlDbType.Decimal);
        dp.AddParam("@Accuracy", model.Accuracy, SqlDbType.Int);

        dp.AddParam("@FakturId", model.FakturId, SqlDbType.VarChar);
        dp.AddParam("@FakturCode", model.FakturCode, SqlDbType.VarChar);
        dp.AddParam("@FakturDate", model.FakturDate, SqlDbType.DateTime);
        dp.AddParam("@AdminName", model.AdminName, SqlDbType.VarChar);

        dp.AddParam("@WarehouseCode", model.WarehouseCode, SqlDbType.VarChar);
        dp.AddParam("@OfficeCode", model.OfficeCode, SqlDbType.VarChar);
        dp.AddParam("@UpdateTimestamp", model.UpdateTimestamp, SqlDbType.DateTime);
        dp.AddParam("@DownloadTimestamp", model.DownloadTimestamp, SqlDbType.DateTime);

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
                PackingOrderId, PackingOrderDate, 
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                Latitude, Longitude, Accuracy,
                FakturId, FakturCode, FakturDate, AdminName,
                WarehouseCode, OfficeCode, UpdateTimestamp, DownloadTimestamp
            FROM BTRGX_PackingOrder
            WHERE PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", key.PackingOrderId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.ReadSingle<PackingOrderModel>(sql, dp);
    }

    public IEnumerable<PackingOrderModel> ListData(DateTime timeStamp, string warehouseCode)
    {
        const string sql = @"
            SELECT TOP 500
                PackingOrderId, PackingOrderDate, 
                CustomerId, CustomerCode, CustomerName, Alamat, NoTelp,
                Latitude, Longitude, Accuracy,
                FakturId, FakturCode, FakturDate, AdminName,
                WarehouseCode, OfficeCode, UpdateTimestamp, DownloadTimestamp
            FROM BTRGX_PackingOrder
            WHERE UpdateTimestamp >= @Timestamp 
                AND WarehouseCode = @WarehouseCode
            ORDER BY PackingOrderId ASC    
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@Timestamp", timeStamp, SqlDbType.DateTime);
        dp.AddParam("@WarehouseCode", warehouseCode, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.Read<PackingOrderModel>(sql, dp);
    }
}