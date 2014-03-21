using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IName
    {
        string Name
        {
            get;

        }
    }
    public interface IExecutable : IName
    {
        void Execute();
    }

    public interface IDataResult
    {
        List<Klienti> Rezultati();
    }

    public interface IAdd
    {
        void Add(Klienti k);
    }

    public interface IUpdate
    {
        void Update(Klienti k);
    }
}
