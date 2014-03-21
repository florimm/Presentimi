using System.Collections.Generic;
using System.Linq;
using Common;

namespace EntityFrameworkDBFirst
{
    public class DataAccess : IExecutable, IAdd, IUpdate, IDataResult
    {
        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(new Common.Klienti());
            Update(rezultati[0]);
        }
        public string Name
        {
            get { return "EntityFrameworkDBFirst"; }
        }

        public void Add(Klienti k)
        {
            var da = new DataTestEntities();
            da.Klientats.Add(new Klientat() {Adresa = k.Adresa, Mbiemri = k.Mbiemri, Emri = k.Emri});
            da.SaveChanges();
        }

        public void Update(Klienti k)
        {
            var da = new DataTestEntities();
            var klienti = da.Klientats.Single(t=> t.ID == k.ID);
            klienti.Adresa = k.Adresa;
            klienti.Mbiemri = k.Mbiemri;
            klienti.Emri = k.Emri;

            da.SaveChanges();
        }

        public List<Klienti> Rezultati()
        {
            var da = new DataTestEntities();
            var data = da.Klientats.Include("Faturats").ToList();

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
}
