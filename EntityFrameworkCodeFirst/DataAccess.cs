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

        public List<Klienti> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class DataCon : DbContext
    {
        
    }


}
