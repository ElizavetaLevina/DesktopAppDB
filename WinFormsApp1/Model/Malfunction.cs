using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Malfunction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public List<Order>? Orders { get; set; }
        public List<MalfunctionOrder>? MalfunctionOrders { get; set; }
    }
}
