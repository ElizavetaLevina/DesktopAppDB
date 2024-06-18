using System.ComponentModel;
using WinFormsApp1.Model;

namespace WinFormsApp1.DTO
{
    public class OrderDTO
    {
        public virtual BrandTechnic? BrandTechnic { get; set; }


        public OrderDTO(Order order)
        {
            BrandTechnic = order.BrandTechnic;
        }
    }
}
