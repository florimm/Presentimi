using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LinqToSql
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "LinqToSql"; }
        }

        public List<Klienti> Execute()
        {
            var ac = new DataContextDataContext();
            ac.LoadOptions.AssociateWith<Klientat>(t=> t.Faturats);
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
        public DataContextDataContext() : this(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString)
        {
            
        }
    }
}
