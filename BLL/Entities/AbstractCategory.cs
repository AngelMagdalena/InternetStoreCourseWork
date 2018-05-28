using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
  public abstract class AbstractCategory
    {
        public abstract int ID { get; set; }
        public abstract string Name { get; set; }
    }
}
