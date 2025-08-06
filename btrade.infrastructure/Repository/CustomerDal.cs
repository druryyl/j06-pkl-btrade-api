using btrade.application.Contract;
using btrade.domain.Model;
using btrade.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.PatternHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btrade.infrastructure.Repository;

public class CustomerDal : ICustomerDal
{
    private readonly DatabaseOptions _opt;

    public CustomerDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(CustomerType model)
    {
        const string sql = @"
            INSERT INTO BTRADE_Customer(
                CustomerId, CustomerCode, CustomerName, Address, Wilayah
            ) VALUES (
                @CustomerId, @CustomerCode, @CustomerName, @Address, @Wilayah)";

        var dp = new DynamicParameters();
        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Address", model.Address, SqlDbType.VarChar);
        dp.AddParam("@Wilayah", model.Wilayah, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(CustomerType model)
    {
        const string sql = @"
            UPDATE
                BTRADE_Customer
            SET
                CustomerCode = @CustomerCode,
                CustomerName = @CustomerName,
                Address = @Address,
                Wilayah = @Wilayah
            WHERE
                CustomerId = @CustomerId";

        var dp = new DynamicParameters();
        dp.AddParam("@CustomerId", model.CustomerId, SqlDbType.VarChar);
        dp.AddParam("@CustomerCode", model.CustomerCode, SqlDbType.VarChar);
        dp.AddParam("@CustomerName", model.CustomerName, SqlDbType.VarChar);
        dp.AddParam("@Address", model.Address, SqlDbType.VarChar);
        dp.AddParam("@Wilayah", model.Wilayah, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(ICustomerKey key)
    {
        const string sql = @"
            DELETE FROM
                BTRADE_Customer
            WHERE
                CustomerId = @CustomerId";

        var dp = new DynamicParameters();
        dp.AddParam("@CustomerId", key.CustomerId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete()
    {
        const string sql = @"
            DELETE FROM
                BTRADE_Customer";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql);
    }


    public MayBe<CustomerType> GetData(ICustomerKey key)
    {
        const string sql = @"
            SELECT
                CustomerId, CustomerCode, CustomerName, Address, Wilayah
            FROM
                BTRADE_Customer
            WHERE
                CustomerId = @CustomerId";

        var dp = new DynamicParameters();
        dp.AddParam("@CustomerId", key.CustomerId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.ReadSingle<CustomerType>(sql, dp));
    }

    public MayBe<IEnumerable<CustomerType>> ListData()
    {
        const string sql = @"
            SELECT
                CustomerId, CustomerCode, CustomerName, Address, Wilayah
            FROM
                BTRADE_Customer";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.Read<CustomerType>(sql));
    }
}
