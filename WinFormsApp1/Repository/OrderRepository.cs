using WinFormsApp1.DTO;
using WinFormsApp1.Model;

namespace WinFormsApp1.Repository
{
    public class OrderRepository
    {
        /// <summary>
        /// Получение списка заказов для главной таблицы
        /// </summary>
        /// <param name="inProgress">В ремонте</param>
        /// <param name="deleted">Удален</param>
        /// <param name="issue">Выдан</param>
        /// <param name="dateCreation">Дата создания заказа</param>
        /// <param name="dateCompleted">Дата выполнения заказа</param>
        /// <param name="dateIssue">Дата выдачи</param>
        /// <param name="id">Номер заказа</param>
        /// <returns>Список заказов для главной таблицы</returns>
        public List<OrderTableDTO> GetOrdersForTable(bool? inProgress = null, bool? deleted = null, bool? issue = null, bool dateCreation = false, 
            bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            Context context = new();

            var set = context.Orders.Where(c => true);

            if(deleted != null)
                set = set.Where(i => i.Deleted == deleted);
            if(inProgress != null)
                set = set.Where(i => i.InProgress == inProgress);
            if(issue != null)
                set = set.Where(i => i.Issue == issue);

            if (dateCreation == true)
                set = set.OrderByDescending(i => i.DateCreation);
            if(dateCompleted == true)
                set = set.OrderByDescending(i => i.DateCompleted);
            if(dateIssue == true)
                set = set.OrderByDescending(i => i.DateIssue);
            if(id == true)
                set = set.OrderByDescending(i => i.Id);

            return set
                .Select(a => new OrderTableDTO(a))
                .ToList();
        }

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        public OrderEditDTO GetOrder(int id)
        {
            Context context = new();
            return new OrderEditDTO(context.Orders.First(i => i.Id == id));
        }

        /// <summary>
        /// Получение последнего идентификатора в таблице
        /// </summary>
        /// <returns>Иднтификатор</returns>
        public int GetLastId()
        {
            Context context = new();
            return (context.Orders?.OrderBy(i => i.Id).LastOrDefault()?.NumberOrder ?? 0) + 1;
        }

        /// <summary>
        /// Получение списка заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrders()
        {
            Context context = new();
            return context.Orders.Select(a => new OrderEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение списка заказов по диагнозу
        /// </summary>
        /// <param name="idDiagnosis">Идентификатор диагноза</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersByIdDiagnosis(int idDiagnosis)
        {
            Context context = new();
            return context.Orders.Where(i => i.DiagnosisId == idDiagnosis).Select(a => new OrderEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение списка заказов по комплектации
        /// </summary>
        /// <param name="idEquipment">Идентификатор комплектации</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersByIdEquipment(int idEquipment)
        {
            Context context = new();
            return context.Orders.Where(i => i.EquipmentId == idEquipment).Select(a => new OrderEditDTO(a)).ToList();
        }


        public async Task<int> SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default)
        {
            using Context db = new();
            Order order = new()
            {
                Id = orderDTO.Id,
                NumberOrder = orderDTO.NumberOrder,
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
                    db.Orders.Update(order);

                await db.SaveChangesAsync(token);
                return order.Id;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); throw; }
        }

        public void RemoveOrder(OrderEditDTO orderDTO)
        {
            try
            {
                using Context db = new();
                var order = db.Orders.FirstOrDefault(c => c.Id == orderDTO.Id);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
