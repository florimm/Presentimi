using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using TypedDataSet.DataContextTableAdapters;

namespace TypedDataSet
{
    public class DataAccess : IExecutable, IDataResult, IAdd, IUpdate
    {
        KlientatTableAdapter ad = new KlientatTableAdapter();
        DataContext.KlientatDataTable kd = new DataContext.KlientatDataTable();
        public string Name
        {
            get { return "TypedDataSet"; }
        }

        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(Common.Klienti.Create());
            Update(rezultati[0]);
        }

        public void Update(Klienti k)
        {
            foreach (DataContext.KlientatRow row in kd.Rows)
            {
                if (row.ID == k.ID)
                {
                    row.Emri = k.EmriMbiemri;
                    row.Mbiemri = k.Mbiemri;
                    row.Adresa = k.Adresa;
                }
            }
            ad.Update(kd);
        }

        public List<Klienti> Rezultati()
        {
            var klientat = new List<Klienti>();
            ad.Fill(kd);
            foreach (DataContext.KlientatRow k in kd.Rows)
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

        public void Add(Klienti k)
        {
            kd.AddKlientatRow(k.Emri, k.Mbiemri, k.Adresa);
            ad.Update(kd);
        }
    }
}
