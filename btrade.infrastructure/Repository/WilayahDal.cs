﻿using btrade.application.Contract;
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

namespace btrade.infrastructure.Repository
{
    public class WilayahDal : IWilayahDal
    {
        private readonly DatabaseOptions _opt;

        public WilayahDal(IOptions<DatabaseOptions> opt)
        {
            _opt = opt.Value;
        }

        public void Insert(WilayahType model)
        {
            const string sql = @"
            INSERT INTO BTRADE_Wilayah(
                WilayahId, WilayahName
            ) VALUES (
                @WilayahId, @WilayahName)";

            var dp = new DynamicParameters();
            dp.AddParam("@WilayahId", model.WilayahId, SqlDbType.VarChar);
            dp.AddParam("@WilayahName", model.WilayahName, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public void Update(WilayahType model)
        {
            const string sql = @"
            UPDATE
                BTRADE_Wilayah
            SET
                WilayahName = @WilayahName
            WHERE
                WilayahId = @WilayahId";

            var dp = new DynamicParameters();
            dp.AddParam("@WilayahId", model.WilayahId, SqlDbType.VarChar);
            dp.AddParam("@WilayahName", model.WilayahName, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public void Delete(IWilayahKey key)
        {
            const string sql = @"
            DELETE FROM
                BTRADE_Wilayah
            WHERE
                WilayahId = @WilayahId";

            var dp = new DynamicParameters();
            dp.AddParam("@WilayahId", key.WilayahId, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql, dp);
        }

        public MayBe<WilayahType> GetData(IWilayahKey key)
        {
            const string sql = @"
            SELECT
                WilayahId, WilayahName
            FROM
                BTRADE_Wilayah
            WHERE
                WilayahId = @WilayahId";

            var dp = new DynamicParameters();
            dp.AddParam("@WilayahId", key.WilayahId, SqlDbType.VarChar);

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            return MayBe.From(conn.ReadSingle<WilayahType>(sql, dp));
        }

        public MayBe<IEnumerable<WilayahType>> ListData()
        {
            const string sql = @"
            SELECT
                WilayahId, WilayahName
            FROM
                BTRADE_Wilayah";

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            return MayBe.From(conn.Read<WilayahType>(sql));
        }

        public void Delete()
        {
            const string sql = "DELETE FROM BTRADE_Wilayah";

            using var conn = new SqlConnection(ConnStringHelper.Get(_opt));
            conn.Execute(sql);
        }
    }
}
