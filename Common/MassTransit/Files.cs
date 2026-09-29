using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MassTransit
{
    public class Files
    {
        public int? Photo { get; set; }
        public List<int> Documents { get; set; } = new();
    }
}
