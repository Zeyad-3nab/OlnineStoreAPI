using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Arch.Core.Models
{
    public class ProductBrand : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
