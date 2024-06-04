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
        public List<TypeTechnic>? TypeTechnics { get; set; }
        public List<TypeBrand>? TypeBrands { get; set; }
        public List<Order>? Order { get; set; }
    }
}
