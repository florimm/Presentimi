using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Common;

namespace LinqToSql
{
    public class DataAccess : IExecutable, IAdd, IUpdate, IDataResult
    {
        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(new Common.Klienti() { Adresa = "Adresa => Linq to Sql", Emri = "Linq", Mbiemri = "to Sql" });
            Update(rezultati[0]);
        }
        public string Name
        {
            get { return "LinqToSql"; }
        }

        public void Add(Klienti k)
        {
            var ac = new DataContextDataContext();
            ac.Klientats.InsertOnSubmit(new Klientat
            {
                Adresa = k.Adresa,
                Emri = k.Emri,
                Mbiemri = k.Mbiemri
            });
            ac.SubmitChanges();
        }

        public void Update(Klienti k)
        {
            var ac = new DataContextDataContext();
            var klient = ac.Klientats.Single(t => t.ID == k.ID);
            klient.Emri = k.Emri;
            klient.Mbiemri = k.Mbiemri;
            klient.Adresa = k.Adresa;
            ac.SubmitChanges();
        }

        public List<Klienti> Rezultati()
        {
            var ac = new DataContextDataContext();
            var options = new DataLoadOptions();
            options.LoadWith<Klientat>(t => t.Faturats);
            ac.LoadOptions = options;
            var data = ac.Klientats.ToList();

            var ls = new List<Common.Klienti>();
            foreach (var klienti in data)
            {
                var k = new Klienti
                {
                    ID = klienti.ID,
                    Adresa = klienti.Adresa,
                    Emri = klienti.Emri,
                    Mbiemri = klienti.Mbiemri
                };
                foreach (var fatura in klienti.Faturats)
                {
                    k.Faturat.Add(new Fatura { Data = fatura.Data, ID = fatura.ID, Nr = fatura.Nr, Shuma = fatura.Shuma });
                }
                ls.Add(k);
            }
            return ls;
        }
    }

    public partial class DataContextDataContext
    {
        public DataContextDataContext() : this(ConnectionFactory.ConnectionString())
        {
            
        }
    }
}
