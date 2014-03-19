using System.Collections.Generic;
using System.Linq;
using Common;

namespace EntityFramework
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "EntityFramework"; }
        }

        public List<Common.Klienti> Execute()
        {
            var da = new DataEntities();
            var data = da.Klientats.Include("Faturat").ToList();
            
            
            
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
                    k.Faturat.Add(new Fatura {Data = fatura.Data,ID = fatura.ID,Nr = fatura.Nr,Shuma = fatura.Shuma});
                }
                ls.Add(k);
            }
            return ls;

        }
    }
}
