using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BEADO
{
    public class DataAccess : IExecutable, IDataResult, IAdd, IUpdate
    {
        public string Name
        {
            get { return "BEADO"; }
        }

        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(Common.Klienti.Create());
            Update(rezultati[0]);
        }


        private List<Klienti> MerrKlientet()
        {
            var pl = new List<Klienti>();
            var conn = ConnectionFactory.Connection();
            try
            {
                var cmd = new SqlCommand("select * from Klientat", conn);
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var k = new Klienti
                    {
                        ID = (int)rdr["ID"],
                        Emri = (string)rdr["Emri"],
                        Mbiemri = (string)rdr["Mbiemri"],
                        Adresa = (string)rdr["Adresa"]
                    };
                    k.Faturat = MerrFaturat(k);
                    pl.Add(k);
                }
                return pl;
            }
            finally
            {
                conn.Close();
            }
        }

        private List<Fatura> MerrFaturat(Klienti klienti)
        {
            var pl = new List<Fatura>();
            var conn = ConnectionFactory.Connection();
            try
            {
                var cmd = new SqlCommand("select * from Faturat where klientiId = @klientiID", conn) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@klientiID", klienti.ID);
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var p = new Fatura
                    {
                        ID = (int)rdr["ID"],
                        Data = (DateTime)rdr["Data"],
                        Nr = (string)rdr["Nr"],
                        Shuma = (decimal)rdr["Shuma"]
                    };
                    pl.Add(p);
                }
                return pl;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Klienti> Rezultati()
        {
            return MerrKlientet();
        }

        public void Add(Klienti k)
        {
            var conn = ConnectionFactory.Connection();
            try
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Klientat]([Emri],[Mbiemri],[Adresa]) VALUES (@Emri,@Mbiemri,@Adresa)", conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Emri", k.Emri);
                cmd.Parameters.AddWithValue("@Mbiemri", k.Mbiemri);
                cmd.Parameters.AddWithValue("@Adresa", k.Adresa);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Klienti k)
        {
            var conn = ConnectionFactory.Connection();
            try
            {
                var cmd = new SqlCommand("update [dbo].[Klientat] set [Emri] = @Emri, [Mbiemri] = @Mbiemri, [Adresa] = @Adresa where ID = @ID", conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Emri", k.Emri);
                cmd.Parameters.AddWithValue("@Mbiemri", k.Mbiemri);
                cmd.Parameters.AddWithValue("@Adresa", k.Adresa);
                cmd.Parameters.AddWithValue("@ID", k.ID);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
