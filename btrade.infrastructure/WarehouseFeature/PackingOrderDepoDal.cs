using btrade.application.WarehouseFreature;
using btrade.domain.WarehouseFeature;
using btrade.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using System.Data;
using System.Data.SqlClient;

namespace btrade.infrastructure.WarehouseFeature;

public class PackingOrderDepoDal : IPackingOrderDepoDal
{
    private readonly DatabaseOptions _opt;

    public PackingOrderDepoDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(IEnumerable<PackingOrderDepoModel> listModel)
    {
        using (var conn = new SqlConnection(ConnStringHelper.Get(_opt)))
        using (var bcp = new SqlBulkCopy(conn))
        {
            conn.Open();
            bcp.AddMap("PackingOrderId", "PackingOrderId");
            bcp.AddMap("DepoId", "DepoId");
            bcp.AddMap("UpdateTimestamp", "UpdateTimestamp");
            bcp.AddMap("DownloadTimestamp", "DownloadTimestamp");

            var fetched = listModel.ToList();
            bcp.BatchSize = fetched.Count;
            bcp.DestinationTableName = "dbo.BTRADE_PackingOrderDepo";
            bcp.WriteToServer(fetched.AsDataTable());
        }
    }

    public void Delete(IPackingOrderKey key)
    {
        const string sql = @"
            DELETE FROM BTRADE_PackingOrderDepo
            WHERE PackingOrderId = @PackingOrderId
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", key.PackingOrderId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public IEnumerable<PackingOrderDepoModel> ListData(IPackingOrderKey filter)
    {
        const string sql = @"
            SELECT
                PackingOrderId, DepoId,
                UpdateTimestamp, DownloadTimestamp  
            FROM BTRADE_PackingOrderDepo
            WHERE PackingOrderId = @PackingOrderId
            ORDER BY NoUrut
            ";

        var dp = new DynamicParameters();
        dp.AddParam("@PackingOrderId", filter.PackingOrderId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return conn.Read<PackingOrderDepoModel>(sql, dp);
    }
}