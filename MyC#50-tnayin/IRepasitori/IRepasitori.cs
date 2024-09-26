using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyC_50_tnayin.IRepasitori
{
    internal interface IRepasitori<T>
    {
        void Add(T t);
        T Find(int Id);
        List<T> FindAll();
        void Updater(T t);
        void Delite(int Id);
    }
}
