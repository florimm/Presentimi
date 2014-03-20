using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace EntityFrameworkCodeFirst
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "EntityFrameworkCodeFirst"; }
        }

        public List<Common.Klienti> Execute()
        {
            var con = new DataCon();
            var ds = con.Klientat.Include(t => t.Faturat).ToList();
            
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
