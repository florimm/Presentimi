using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace OtherDataAccess
{
    public class DataAccess : IDataResult
    {
        public string Name
        {
            get { return "OtherDataAccess"; }
        }

        public List<Klienti> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
