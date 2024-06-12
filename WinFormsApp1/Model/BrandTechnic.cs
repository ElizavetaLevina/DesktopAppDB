using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class BrandTechnic
    {
        public int Id { get; set; }
        public string? NameBrandTechnic { get; set; }
        public virtual List<TypeTechnic>? TypeTechnics { get; set; }
        public virtual List<TypeBrand>? TypeBrands { get; set; }
        public virtual List<Order>? Order { get; set; }
    }
}
