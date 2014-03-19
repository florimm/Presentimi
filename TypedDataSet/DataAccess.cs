using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using TypedDataSet.DataContextTableAdapters;

namespace TypedDataSet
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "TypedDataSet"; }
        }

        public List<Klienti> Execute()
        {
            var klientat = new List<Klienti>();
            var ad = new KlientatTableAdapter();
            var kd = new DataContext.KlientatDataTable();
            ad.Fill(kd);
            foreach ( DataContext.KlientatRow k in kd.Rows)
            {
                var klienti = new Klienti
                {
                    ID = k.ID,
                    Emri = k.Emri,
                    Mbiemri = k.Mbiemri,
                    Adresa = k.Adresa
                };
                var fd = new FaturatTableAdapter();
                var f = new DataContext.FaturatDataTable();
                fd.PerKlientin(f, klienti.ID);
                foreach (DataContext.FaturatRow faturatRow in f.Rows)
                {
                    klienti.Faturat.Add(new Fatura()
                    {
                        ID = faturatRow.ID,
                        Data = faturatRow.Data,
                        Nr = faturatRow.Nr,
                        Shuma = faturatRow.Shuma
                    });
                }
                klientat.Add(klienti);
            }
            return klientat;
        }
    }
}
