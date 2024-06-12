using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public class Client
    {
        public int Id { get; set; }
        public string? IdClient {  get; set; }
        public string? NameClient { get; set; }
        public string? Address { get; set; }
        public string? NumberSecondPhone {  get; set; }
        public string TypeClient { get; set; } = "normal";
        public virtual List<Order>? Order { get; set; }
    }
}
