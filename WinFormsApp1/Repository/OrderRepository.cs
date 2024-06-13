using DocumentFormat.OpenXml.Spreadsheet;
using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class OrderRepository
    {
        /// <summary>
        /// Получение списка заказов
        /// </summary>
        /// <param name="inProgress"></param>
        /// <param name="deleted"></param>
        /// <param name="issue"></param>
        /// <param name="dateStartWork"></param>
        /// <param name="dateCompleted"></param>
        /// <param name="dateIssue"></param>
        /// <param name="id"></param>
        /// <returns>Список заказов</returns>
        public List<OrderDTO> GetOrders(bool? inProgress, bool? deleted, bool? issue, bool dateStartWork = false, 
            bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            Context context = new();

            var set = context.Orders.Where(c => true);

            if(deleted != null)
                set = set.Where(i => i.Deleted == deleted);
            else
                set = set.Where(i => i.InProgress == inProgress && i.Issue == issue);

            if (dateStartWork == true)
                set = set.OrderByDescending(i => i.DateStartWork);
            if(dateCompleted == true)
                set = set.OrderByDescending(i => i.DateCompleted);
            if(dateIssue == true)
                set = set.OrderByDescending(i => i.DateIssue);
            if(id == true)
                set = set.OrderByDescending(i => i.Id);

            return set
                .Select(a => new OrderDTO(a))
                .ToList();

        }

        public static void RemoveOrder(List<Order> list)
        {
            using Context db = new();
            Order order = new() { Id = list[0].Id };
            try
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public async Task SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default)
        {
            using Context db = new();
            Order order = new()
            {
                Id = orderDTO.Id,
                ClientId = orderDTO.ClientId,
                MasterId = orderDTO.MasterId,
                DateCreation = orderDTO.DateCreation,
                DateStartWork = orderDTO.DateStartWork,
                DateCompleted = orderDTO.DateCompleted,
                DateIssue = orderDTO.DateIssue,
                TypeTechnicId = orderDTO.TypeTechnicId,
                BrandTechnicId = orderDTO.BrandTechnicId,
                ModelTechnic = orderDTO.ModelTechnic,
                FactoryNumber = orderDTO.FactoryNumber,
                EquipmentId = orderDTO.EquipmentId,
                DiagnosisId = orderDTO.DiagnosisId,
                Note = orderDTO.Note,
                InProgress = orderDTO.InProgress,
                Guarantee = orderDTO.Guarantee,
                DateEndGuarantee = orderDTO.DateEndGuarantee,
                Deleted = orderDTO.Deleted,
                ReturnUnderGuarantee = orderDTO.ReturnUnderGuarantee,
                DateReturn = orderDTO.DateReturn,
                DateCompletedReturn = orderDTO.DateCompletedReturn,
                DateIssueReturn = orderDTO.DateIssueReturn,
                Issue = orderDTO.Issue,
                ColorRow = orderDTO.ColorRow,
                DateLastCall = orderDTO.DateLastCall,
                PriceAgreed = orderDTO.PriceAgreed,
                MaxPrice = orderDTO.MaxPrice
            };
            try
            {
                if (order.Id == 0)
                    db.Orders.Add(order);
                else
                {
                    db.Orders.Update(order);
                }
                
                await db.SaveChangesAsync(token);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }
    }
}
