using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace EntityFrameworkCodeFirst
{
    public class DataAccess : IExecutable, IDataResult, IAdd, IUpdate
    {
        public string Name
        {
            get { return "EntityFrameworkCodeFirst"; }
        }

        public void Execute()
        {
            System.Diagnostics.Debugger.Break();
            var rezultati = Rezultati();
            Add(new Common.Klienti());
            Update(rezultati[0]);
        }

        public List<Common.Klienti> Rezultati()
        {
            var con = new DataCon();
            var data = con.Klientat.Include(t => t.Faturat).ToList();
            var ls = new List<Common.Klienti>();
            foreach (var klienti in data)
            {
                var k = new Common.Klienti
                {
                    ID = klienti.ID,
                    Adresa = klienti.Adresa,
                    Emri = klienti.Emri,
                    Mbiemri = klienti.Mbiemri
                };
                foreach (var fatura in klienti.Faturat)
                {
                    k.Faturat.Add(new Common.Fatura { Data = fatura.Data, ID = fatura.ID, Nr = fatura.Nr, Shuma = fatura.Shuma });
                }
                ls.Add(k);
            }
            return ls;
        }

        public void Update(Common.Klienti k)
        {
            var con = new DataCon();
            var klienti = con.Klientat.Single(c => c.ID == k.ID);
            klienti.Emri = k.Emri;
            klienti.Mbiemri = k.Mbiemri;
            klienti.Adresa = k.Adresa;
            con.SaveChanges();
        }

        public void Add(Common.Klienti k)
        {
            var con = new DataCon();
            var klienti = new Klienti {Emri = k.Emri, Mbiemri = k.Mbiemri, Adresa = k.Adresa};
            con.Klientat.Add(klienti);
            con.SaveChanges();
        }
    }

    public class DataCon : DbContext
    {
        static DataCon()
    	{ 
    		Database.SetInitializer<DataCon>(null);
    	}
    	
    	public DataCon() : base("name=DBContext")
        {
        }

        public DataCon(string nameOrConnectionString)
            : base(nameOrConnectionString)
    	{	
    	}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {		
    		modelBuilder.Configurations.Add(new Faturat_Mapping());
    		modelBuilder.Configurations.Add(new Klientat_Mapping());
        }
    	
        public DbSet<Fatura> Faturat { get; set; }
        public DbSet<Klienti> Klientat { get; set; }
    }


}
