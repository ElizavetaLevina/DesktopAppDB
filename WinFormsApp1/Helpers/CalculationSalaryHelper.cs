using WinFormsApp1.DTO;
using WinFormsApp1.Enum;

namespace WinFormsApp1.Helpers
{
    public static class CalculationSalaryHelper
    {
        public static int SalaryCalculation(MasterEditDTO masterDTO, List<OrderEditDTO> ordersDTO, RateMasterEditDTO rateMasterDTO)
        {
            int salary = 0;

            var rateMaster = rateMasterDTO.Id == 0 ? masterDTO.Rate : rateMasterDTO.PercentProfit;

            switch (masterDTO.TypeSalary) 
            {
                case TypeSalaryEnum.percentMaster:
                    foreach (var order in ordersDTO)
                    {
                        if (order.MainMasterId == masterDTO.Id)
                        {
                            salary += (int)(order.MalfunctionOrders.Sum(m => m.Price) * order.PercentWorkMainMaster / 100.0);
                        }
                        else if (order.AdditionalMasterId == masterDTO.Id)
                        {
                            salary += (int)(order.MalfunctionOrders.Sum(m => m.Price) * order.PercentWorkAdditionalMaster / 100.0);
                        }
                    }
                    salary = (int)(salary * rateMaster / 100.0);
                    break;
                case TypeSalaryEnum.percentOrganization:
                    salary = (int)(ordersDTO.Sum(o => o.MalfunctionOrders.Sum(m => m.Price)) * rateMaster / 100.0);
                    break;
                case TypeSalaryEnum.rate:
                    salary = rateMaster;
                    break;
            }
            return salary;
        }
    }
}
