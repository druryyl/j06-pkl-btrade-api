using btrade.application.Contract;
using btrade.domain.Model;
using btrade.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.PatternHelper;
using System.Data;
using System.Data.SqlClient;

namespace btrade.infrastructure.Repository;

public class SalesPersonDal : ISalesPersonDal
{
    private readonly DatabaseOptions _opt;

    public SalesPersonDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(SalesPersonType model)
    {
        const string sql = @"
            INSERT INTO BTRADE_SalesPerson(
                SalesPersonId, SalesPersonCode, SalesPersonName
            ) VALUES (
                @SalesPersonId, @SalesPersonCode, @SalesPersonName)";

        var dp = new DynamicParameters();
        dp.AddParam("@SalesPersonId", model.SalesPersonId, SqlDbType.VarChar);
        dp.AddParam("@SalesPersonCode", model.SalesPersonCode, SqlDbType.VarChar);
        dp.AddParam("@SalesPersonName", model.SalesPersonName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(SalesPersonType model)
    {
        const string sql = @"
            UPDATE
                BTRADE_SalesPerson
            SET
                SalesPersonCode = @SalesPersonCode,
                SalesPersonName = @SalesPersonName
            WHERE
                SalesPersonId = @SalesPersonId";

        var dp = new DynamicParameters();
        dp.AddParam("@SalesPersonId", model.SalesPersonId, SqlDbType.VarChar);
        dp.AddParam("@SalesPersonCode", model.SalesPersonCode, SqlDbType.VarChar);
        dp.AddParam("@SalesPersonName", model.SalesPersonName, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(ISalesPersonKey key)
    {
        const string sql = @"
            DELETE FROM
                BTRADE_SalesPerson
            WHERE
                SalesPersonId = @SalesPersonId";

        var dp = new DynamicParameters();
        dp.AddParam("@SalesPersonId", key.SalesPersonId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete()
    {
        const string sql = @"
            DELETE FROM
                BTRADE_SalesPerson";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql);
    }

    public MayBe<SalesPersonType> GetData(ISalesPersonKey key)
    {
        const string sql = @"
            SELECT
                SalesPersonId, SalesPersonCode, SalesPersonName
            FROM
                BTRADE_SalesPerson
            WHERE
                SalesPersonId = @SalesPersonId";

        var dp = new DynamicParameters();
        dp.AddParam("@SalesPersonId", key.SalesPersonId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.ReadSingle<SalesPersonType>(sql, dp));
    }

    public MayBe<IEnumerable<SalesPersonType>> ListData()
    {
        const string sql = @"
            SELECT
                SalesPersonId, SalesPersonCode, SalesPersonName
            FROM
                BTRADE_SalesPerson";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.Read<SalesPersonType>(sql));
    }
}