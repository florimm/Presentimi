using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace UntypedDataSet
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "UntypedDataSet"; }
        }

        public List<Klienti> Execute()
        {
            var klientat = new List<Klienti>();
            var klientetDs = GetKlientet();
            var faturatDs = GetFaturat();
            foreach (DataRow row in klientetDs.Tables[0].Rows)
            {
                var klienti = new Klienti
                {
                    ID = (int) row["ID"],
                    Emri = (string) row["Emri"],
                    Mbiemri = (string) row["Mbiemri"],
                    Adresa = (string) row["Adresa"]
                };
                var strExpr = "KlientiID = " + klienti.ID;
                var dv = faturatDs.Tables[0].DefaultView;
                dv.RowFilter = strExpr;
                var fatura = dv.ToTable();
                foreach (DataRow row1 in fatura.Rows)
                {
                    klienti.Faturat.Add(new Fatura
                    {
                        ID = (int)row1["ID"], 
                        Data = (DateTime)row1["Data"], 
                        Nr = (string)row1["Nr"], 
                        Shuma = (decimal)row1["Shuma"]
                    });
                }
                klientat.Add(klienti);

            }
            return klientat;
        }
        private DataSet GetKlientet()
        {
            var conn = ConnectionFactory.Connection();
            var dataset = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter("select * from Klientat", conn);
                conn.Open();
                adapter.Fill(dataset);
            }
            finally
            {
                conn.Close();
            }
            return dataset;
        }

        private DataSet GetFaturat()
        {
            var conn = ConnectionFactory.Connection();
            var dataset = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter("select * from Faturat", conn);
                conn.Open();
                adapter.Fill(dataset);
            }
            finally
            {
                conn.Close();
            }
            return dataset;
        }
    }
}
