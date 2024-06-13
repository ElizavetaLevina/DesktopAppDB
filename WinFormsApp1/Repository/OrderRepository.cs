using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class OrderRepository
    {
        public List<OrderDTO> GetOrders(bool? inProgress, bool? deleted, bool? issue, bool? dateStartWork, 
            bool? dateCompleted, bool? dateIssue, bool? id)
        {
            Context context = new();

            /*var list = context.Orders;

            if(deleted != null)
                list.Where(i => i.Deleted == deleted);
            else
                list.Where(i => i.InProgress == inProgress && i.Issue == issue);*/

            var list = context.Orders.Where(i => i.InProgress == inProgress &&
            i.Deleted == deleted && i.Issue == issue);

            if (dateStartWork != null)
                list.OrderByDescending(i => i.DateStartWork);
            if(dateCompleted != null)
                list.OrderByDescending(i => i.DateCompleted);
            if(dateIssue != null)
                list.OrderByDescending(i => i.DateIssue);
            if(id != null)
                list.OrderByDescending(i => i.Id);

            return list
                .Select(a => new OrderDTO(a))
                .ToList();

        }
        public static async void AddOrderAsync(List<Order> list)
        {
            using Context db = new();

            Order order = new()
            {
                Id = list[0].Id,
                ClientId = list[0].ClientId,
                MasterId = list[0].MasterId,
                DateCreation = list[0].DateCreation,
                DateStartWork = list[0].DateStartWork,
                DateCompleted = list[0].DateCompleted,
                DateIssue = list[0].DateIssue,
                TypeTechnicId = list[0].TypeTechnicId,
                BrandTechnicId = list[0].BrandTechnicId,
                ModelTechnic = list[0].ModelTechnic,
                FactoryNumber = list[0].FactoryNumber,
                EquipmentId = list[0].EquipmentId,
                DiagnosisId = list[0].DiagnosisId,
                Note = list[0].Note,
                InProgress = list[0].InProgress,
                Guarantee = list[0].Guarantee,
                DateEndGuarantee = list[0].DateEndGuarantee,
                Deleted = list[0].Deleted,
                ReturnUnderGuarantee = list[0].ReturnUnderGuarantee,
                DateReturn = list[0].DateReturn,
                DateCompletedReturn = list[0].DateCompletedReturn,
                DateIssueReturn = list[0].DateIssueReturn,
                Issue = list[0].Issue,
                ColorRow = list[0].ColorRow,
                DateLastCall = list[0].DateLastCall,
                PriceAgreed = list[0].PriceAgreed,
                MaxPrice = list[0].MaxPrice
            };
            try
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        public static void ChangeOrder(List<Order> list)
        {
            using Context db = new();
            Order order = new()
            {
                Id = list[0].Id,
                ClientId = list[0].ClientId,
                MasterId = list[0].MasterId,
                DateCreation = list[0].DateCreation,
                DateStartWork = list[0].DateStartWork,
                DateCompleted = list[0].DateCompleted,
                DateIssue = list[0].DateIssue,
                TypeTechnicId = list[0].TypeTechnicId,
                BrandTechnicId = list[0].BrandTechnicId,
                ModelTechnic = list[0].ModelTechnic,
                FactoryNumber = list[0].FactoryNumber,
                EquipmentId = list[0].EquipmentId,
                DiagnosisId = list[0].DiagnosisId,
                Note = list[0].Note,
                InProgress = list[0].InProgress,
                Guarantee = list[0].Guarantee,
                DateEndGuarantee = list[0].DateEndGuarantee,
                Deleted = list[0].Deleted,
                ReturnUnderGuarantee = list[0].ReturnUnderGuarantee,
                DateReturn = list[0].DateReturn,
                DateCompletedReturn = list[0].DateCompletedReturn,
                DateIssueReturn = list[0].DateIssueReturn,
                Issue = list[0].Issue,
                ColorRow = list[0].ColorRow,
                DateLastCall = list[0].DateLastCall,
                PriceAgreed = list[0].PriceAgreed,
                MaxPrice = list[0].MaxPrice
            };
            try
            {
                db.Orders.Update(order);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
