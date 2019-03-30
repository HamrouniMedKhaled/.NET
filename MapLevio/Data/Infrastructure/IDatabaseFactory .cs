using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLevio.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        mapContext DataContext { get; }
    }

}
