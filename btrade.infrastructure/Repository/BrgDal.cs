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

public class BrgDal : IBrgDal
{
    private readonly DatabaseOptions _opt;

    public BrgDal(IOptions<DatabaseOptions> opt)
    {
        _opt = opt.Value;
    }

    public void Insert(BrgType model)
    {
        const string sql = @"
            INSERT INTO BTRADE_Brg(
                BrgId, BrgCode, BrgName, KategoriName, 
                SatBesar, SatKecil, Konversi, HrgSat, Stok)
            VALUES (
                @BrgId, @BrgCode, @BrgName, @KategoriName, 
                @SatBesar, @SatKecil, @Konversi, @HrgSat, @Stok)";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", model.BrgId, SqlDbType.VarChar); 
        dp.AddParam("@BrgCode", model.BrgCode, SqlDbType.VarChar); 
        dp.AddParam("@BrgName", model.BrgName, SqlDbType.VarChar); 
        dp.AddParam("@KategoriName", model.KategoriName, SqlDbType.VarChar); 
        dp.AddParam("@SatBesar", model.SatBesar, SqlDbType.VarChar); 
        dp.AddParam("@SatKecil", model.SatKecil, SqlDbType.VarChar); 
        dp.AddParam("@Konversi", model.Konversi, SqlDbType.Int); 
        dp.AddParam("@HrgSat", model.HrgSat, SqlDbType.Decimal); 
        dp.AddParam("@Stok", model.Stok, SqlDbType.Int);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Update(BrgType model)
    {
        const string sql = @"
            UPDATE
                BTRADE_Brg
            SET
                BrgCode = @BrgCode, 
                BrgName = @BrgName, 
                KategoriName = @KategoriName, 
                SatBesar = @SatBesar, 
                SatKecil = @SatKecil, 
                Konversi = @Konversi, 
                HrgSat = @HrgSat, 
                Stok = @Stok
            WHERE
                BrgId = @BrgId";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", model.BrgId, SqlDbType.VarChar);
        dp.AddParam("@BrgCode", model.BrgCode, SqlDbType.VarChar);
        dp.AddParam("@BrgName", model.BrgName, SqlDbType.VarChar);
        dp.AddParam("@KategoriName", model.KategoriName, SqlDbType.VarChar);
        dp.AddParam("@SatBesar", model.SatBesar, SqlDbType.VarChar);
        dp.AddParam("@SatKecil", model.SatKecil, SqlDbType.VarChar);
        dp.AddParam("@Konversi", model.Konversi, SqlDbType.Int);
        dp.AddParam("@HrgSat", model.HrgSat, SqlDbType.Decimal);
        dp.AddParam("@Stok", model.Stok, SqlDbType.Int);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql, dp);
    }

    public void Delete(IBrgKey key)
    {
        const string sql = @"
            DELETE FROM
                BTRADE_Brg
            WHERE
                BrgId = @BrgId";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", key.BrgId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt)); 
        conn.Execute(sql, dp);
    }

    public void Delete()
    {
        const string sql = @"
            DELETE FROM
                BTRADE_Brg";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        conn.Execute(sql);
    }

    public MayBe<BrgType> GetData(IBrgKey key)
    {
        const string sql = @"
            SELECT
                BrgId, BrgCode, BrgName, KategoriName, 
                SatBesar, SatKecil, Konversi, HrgSat, Stok
            FROM
                BTRADE_Brg
            WHERE
                BrgId = @BrgId";

        var dp = new DynamicParameters();
        dp.AddParam("@BrgId", key.BrgId, SqlDbType.VarChar);

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.ReadSingle<BrgType>(sql, dp));
    }

    public MayBe<IEnumerable<BrgType>> ListData()
    {
        const string sql = @"
            SELECT
                BrgId, BrgCode, BrgName, KategoriName, 
                SatBesar, SatKecil, Konversi, HrgSat, Stok
            FROM
                BTRADE_Brg ";

        using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
        return MayBe.From(conn.Read<BrgType>(sql));
    }
}

//public class BrgDalTest
//{
//    private readonly BrgDal _sut;

//    public void UT1_InsertTest()
//    {
//        // Arrange
//        var model = new BrgType
//        {
//            BrgId = "BRG001",
//            BrgCode = "BC001",
//            BrgName = "Barang 1",
//            KategoriName = "Kategori A",
//            SatBesar = "PCS",
//            SatKecil = "BOX",
//            Konversi = 10,
//            HrgSat = 100.00m,
//            Stok = 50
//        };
//        // Act
//        _sut.Insert(model);
//        // Assert
//        var result = _sut.GetData(new BrgKey { BrgId = model.BrgId });
//        Assert.IsTrue(result.HasValue);
//    }
//}