using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDataResult
    {
        string Name
        {
            get; 
            
        }

        List<Klienti> Execute();
    }
}
