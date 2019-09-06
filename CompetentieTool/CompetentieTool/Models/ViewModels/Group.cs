using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetentieTool.Models.ViewModels
{
    public class Group<K, T>
    {
        public K Key { get; set; }
        public IList<T> Values { get; set; }

    }
}
