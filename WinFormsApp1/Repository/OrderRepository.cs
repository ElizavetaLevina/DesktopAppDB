using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
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
        public List<OrderTableDTO> GetOrdersForTable(StatusOrderEnum? statusOrder = null, bool? deleted = null, bool dateCreation = false, 
            bool dateCompleted = false, bool dateIssue = false, bool id = false)
        {
            Context context = new();

            var set = context.Orders.Where(c => true);

            if(deleted != null)
                set = set.Where(i => i.Deleted == deleted);
            if(statusOrder != null)
                set = set.Where(i => i.StatusOrder == statusOrder);

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
        /// Получение списка заказов для поиска
        /// </summary>
        /// <param name="numberOrder">Номер заказа</param>
        /// <param name="dateCreation">Дата создания</param>
        /// <param name="dateStartWork">Дата начала работы</param>
        /// <param name="masterName">Имя мастера</param>
        /// <param name="typeTechnic">Тип устройства</param>
        /// <param name="brandTechnic">Бренд устройства</param>
        /// <param name="modelTechnic">Модель устройства</param>
        /// <param name="idClient"></param>
        /// <returns>Список заказов</returns>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string typeTechnic, string brandTechnic, string modelTechnic, string idClient)
        {
            Context context = new();
            
            var set = context.Orders.Where(c => true);

            if(!string.IsNullOrEmpty(numberOrder))
                set = set.Where(i => i.NumberOrder.ToString().Contains(numberOrder));
            if (!string.IsNullOrEmpty(dateCreation))
                set = set.Where(i => i.DateCreation.ToString().StartsWith(dateCreation));
            if (!string.IsNullOrEmpty(dateStartWork))
                set = set.Where(i => i.DateStartWork != null && i.DateStartWork.ToString().StartsWith(dateStartWork));
            if (!string.IsNullOrEmpty(idClient))
                set = set.Where(i => i.Client.IdClient.Contains(idClient));

            var result = set.ToList();
            //if (!string.IsNullOrEmpty(masterName))
            //    result = result.Where(i => i.Master?.NameMaster.ToLower()?.Contains(masterName.ToLower()) ?? false).ToList();
            if (!string.IsNullOrEmpty(typeTechnic))
                result = result.Where(i => i.TypeTechnic?.NameTypeTechnic?.ToLower()?.StartsWith(typeTechnic.ToLower()) ?? false).ToList();
            if (!string.IsNullOrEmpty(brandTechnic))
                result = result.Where(i => i.BrandTechnic?.NameBrandTechnic?.ToLower()?.StartsWith(brandTechnic.ToLower()) ?? false).ToList();
            if (!string.IsNullOrEmpty(modelTechnic))
                result = result.Where(i => i.ModelTechnic?.ToLower()?.StartsWith(modelTechnic.ToLower()) ?? false).ToList();

            return result
                .OrderByDescending(i => i.NumberOrder)
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
        public int GetLastNumberOrder()
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

        /// <summary>
        /// Получения списка заказов для диаграммы
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="master">Указан ли мастер</param>
        /// <param name="masterId">Идентификатор мастера</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersForChart(int year, bool master = false, int? masterId = null)
        {
            Context context = new();
            var set = context.Orders.Where(i => i.StatusOrder != StatusOrderEnum.InRepair && i.StatusOrder != StatusOrderEnum.Trash);

            set = set.Where(i => i.DateCompleted.Value.Year == year);              

            if (master)
                set = set.Where(i => i.MainMasterId == masterId || i.AdditionalMasterId == masterId);

            return set.Select(a => new OrderEditDTO(a)).ToList();
        }

        /// <summary>
        /// Получение списка заказов для расчета зарплаты
        /// </summary>
        /// <param name="dateCompleted">Дата завершения заказа</param>
        /// <param name="dateIssue">Дата выдачи заказа</param>
        /// <returns>Список заказов</returns>
        public List<OrderEditDTO> GetOrdersForSalaries(DateTime? dateCompleted = null, DateTime? dateIssue = null)
        {
            Context context = new();
            var set = context.Orders.Where(c => true);

            set = set.Where(i => !i.Deleted);
            set = set.Where(i => (i.StatusOrder != StatusOrderEnum.InRepair || i.ReturnUnderGuarantee));

            if (dateCompleted != null)
                set = set.Where(i => i.DateCompleted.Value.Month == dateCompleted.Value.Month 
                && i.DateCompleted.Value.Year == dateCompleted.Value.Year);
            if (dateIssue != null)
                set = set.Where(i => i.DateIssue.Value.Month == dateIssue.Value.Month 
                && i.DateIssue.Value.Year == dateIssue.Value.Year);

            return set.Select(a => new OrderEditDTO(a)).ToList();
        }


        public async Task<int> SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default)
        {
            using Context db = new();
            Order order = new()
            {
                Id = orderDTO.Id,
                NumberOrder = orderDTO.NumberOrder,
                ClientId = orderDTO.ClientId,
                MainMasterId = orderDTO.MainMasterId,
                PercentWorkMainMaster = orderDTO.PercentWorkMainMaster,
                AdditionalMasterId = orderDTO.AdditionalMasterId,
                PercentWorkAdditionalMaster = orderDTO.PercentWorkAdditionalMaster,
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
                StatusOrder = orderDTO.StatusOrder,
                //InProgress = orderDTO.InProgress,
                Guarantee = orderDTO.Guarantee,
                DateEndGuarantee = orderDTO.DateEndGuarantee,
                Deleted = orderDTO.Deleted,
                ReturnUnderGuarantee = orderDTO.ReturnUnderGuarantee,
                DateReturn = orderDTO.DateReturn,
                DateCompletedReturn = orderDTO.DateCompletedReturn,
                DateIssueReturn = orderDTO.DateIssueReturn,
                //Issue = orderDTO.Issue,
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
