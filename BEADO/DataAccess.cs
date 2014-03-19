using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BEADO
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "BEADO"; }
        }

        public List<Klienti> Execute()
        {
            return MerrKlientet();
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
                var cmd = new SqlCommand("select * from Faturat where klientiId = @klientiID", conn){CommandType = CommandType.Text};

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
    }
}
