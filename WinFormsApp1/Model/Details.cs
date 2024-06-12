using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Details
    {
        public int Id { get; set; }
        public virtual List<int>? IdWarehouse { get; set; }
        public virtual List<Warehouse>? Warehouse { get; set; }
    }
}
