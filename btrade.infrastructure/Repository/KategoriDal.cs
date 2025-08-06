using btrade.application.Contract;
using btrade.domain.Model;
using btrade.infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Options;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.PatternHelper;
using System.Data;
using System.Data.SqlClient;

namespace btrade.infrastructure.Repository
{
    public class KategoriDal : IKategoriDal
    {
        private readonly DatabaseOptions _opt;

        public KategoriDal(IOptions<DatabaseOptions> opt)
        {
            _opt = opt.Value;
        }

        public void Insert(KategoriType model)
        {
            const string sql = @"
            INSERT INTO BTRADE_Kategori(
                KategoriId, KategoriName
            ) VALUES (
                @KategoriId, @KategoriName)";

            var dp = new DynamicParameters();
            dp.AddParam("@KategoriId", model.KategoriId, SqlDbType.VarChar);
            dp.AddParam("@KategoriName", model.KategoriName, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public void Update(KategoriType model)
        {
            const string sql = @"
            UPDATE
                BTRADE_Kategori
            SET
                KategoriName = @KategoriName
            WHERE
                KategoriId = @KategoriId";

            var dp = new DynamicParameters();
            dp.AddParam("@KategoriId", model.KategoriId, SqlDbType.VarChar);
            dp.AddParam("@KategoriName", model.KategoriName, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public void Delete(IKategoriKey key)
        {
            const string sql = @"
            DELETE FROM
                BTRADE_Kategori
            WHERE
                KategoriId = @KategoriId";

            var dp = new DynamicParameters();
            dp.AddParam("@KategoriId", key.KategoriId, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public MayBe<KategoriType> GetData(IKategoriKey key)
        {
            const string sql = @"
            SELECT
                KategoriId, KategoriName
            FROM
                BTRADE_Kategori
            WHERE
                KategoriId = @KategoriId";

            var dp = new DynamicParameters();
            dp.AddParam("@KategoriId", key.KategoriId, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            return MayBe.From(conn.ReadSingle<KategoriType>(sql, dp));
        }

        public MayBe<IEnumerable<KategoriType>> ListData()
        {
            const string sql = @"
            SELECT
                KategoriId, KategoriName
            FROM
                BTRADE_Kategori";

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            return MayBe.From(conn.Read<KategoriType>(sql));
        }

        public void Delete()
        {
            const string sql = "DELETE FROM BTRADE_Kategori";

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql);
        }
    }
}
