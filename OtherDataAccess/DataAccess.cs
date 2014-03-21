using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common;

namespace OtherDataAccess
{
    public class DataAccess : IExecutable, IAdd, IUpdate, IDataResult
    {
        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(Common.Klienti.Create());
            Update(rezultati[0]);
        }
        public string Name
        {
            get { return "OtherDataAccess"; }
        }


        public void Add(Klienti k)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                string sql =
                    "INSERT INTO [dbo].[Klientat]([Emri],[Mbiemri],[Adresa]) VALUES (@Emri,@Mbiemri,@Adresa)";
                conn.Execute(sql,
                    new
                    {
                        k.Emri,
                        k.Mbiemri,
                        k.Adresa
                    });
                conn.Close();
            }
        }

        public void Update(Klienti k)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                string sql =
                    "update [dbo].[Klientat] set [Emri] = @Emri, [Mbiemri] = @Mbiemri, [Adresa] = @Adresa where ID = @ID";
                conn.Execute(sql,
                    new
                    {
                        k.Emri,
                        k.Mbiemri,
                        k.Adresa,
                        k.ID
                    });
                conn.Close();
            }
        }

        public List<Klienti> Rezultati()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                conn.Open();
                var sql = @"SELECT * FROM Klientat LEFT OUTER JOIN Faturat ON Klientat.ID = Faturat.KlientiID";
                var result = conn.QueryParentChild<Klienti, Fatura, int>(sql, k => k.ID, k => k.Faturat, splitOn: "KlientiID");
                conn.Close();
                return result.ToList();
            }
        }
    }

    public static class DapperExtensions
    {
        public static IEnumerable<TParent> QueryParentChild<TParent, TChild, TParentKey>(this IDbConnection connection,
    string sql,Func<TParent, TParentKey> parentKeySelector,
    Func<TParent, IList<TChild>> childSelector,
    dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            var cache = new Dictionary<TParentKey, TParent>();

            connection.Query<TParent, TChild, TParent>(
                sql,
                (parent, child) =>
                {
                    if (!cache.ContainsKey(parentKeySelector(parent)))
                    {
                        cache.Add(parentKeySelector(parent), parent);
                    }

                    TParent cachedParent = cache[parentKeySelector(parent)];
                    IList<TChild> children = childSelector(cachedParent);
                    children.Add(child);
                    return cachedParent;
                },
                param as object, transaction, buffered, splitOn, commandTimeout, commandType);

            return cache.Values;
        }
    }
}
