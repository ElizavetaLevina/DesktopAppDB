using AutoMapper;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Model;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Repository
{
    public class OrderRepository : IOrderRepository
    {
        IMapper _mapper;

        public OrderRepository (IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <inheritdoc/>
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

            return _mapper.ProjectTo<OrderTableDTO>(set).ToList();
        }


        /// <inheritdoc/>
        public List<OrderTableDTO> GetOrdersBySearch(string numberOrder, string dateCreation, string dateStartWork, string masterName,
            string device, string idClient, StatusOrderEnum? statusOrder)
        {
            Context context = new();            
            var set = context.Orders.Where(c => true);

            if (!string.IsNullOrEmpty(numberOrder))
                set = set.Where(i => i.NumberOrder.ToString().Contains(numberOrder));
            if (!string.IsNullOrEmpty(dateCreation))
                set = set.Where(i => i.DateCreation.ToString().StartsWith(dateCreation));
            if (!string.IsNullOrEmpty(dateStartWork))
                set = set.Where(i => i.DateStartWork != null && i.DateStartWork.ToString().StartsWith(dateStartWork));
            if (!string.IsNullOrEmpty(idClient))
                set = set.Where(i => i.Client.IdClient.Contains(idClient));
            if (!string.IsNullOrEmpty(masterName))
                set = set.Where(i => i.MainMaster.NameMaster.ToLower().Contains(masterName.ToLower()) ||
                i.AdditionalMaster.NameMaster.ToLower().Contains(masterName.ToLower()));
            if (!string.IsNullOrEmpty(device))
                set = set.Where(i => i.TypeTechnic.NameTypeTechnic.ToLower().Contains(device.ToLower()) ||
                i.BrandTechnic.NameBrandTechnic.ToLower().Contains(device.ToLower()) ||
                i.ModelTechnic.ToLower().Contains(device.ToLower()));
            if (statusOrder != null)
                set = set.Where(i => i.StatusOrder == statusOrder);

            return _mapper.ProjectTo<OrderTableDTO>(set.OrderByDescending(i => i.NumberOrder)).ToList();
        }

        /// <inheritdoc/>
        public List<OrderTableExcelDTO> GetOrdersForExcel(List<OrderTableDTO> orders)
        {
            return _mapper.ProjectTo<OrderTableExcelDTO>(orders.AsQueryable()).ToList();
        }

        /// <inheritdoc/>
        public OrderEditDTO GetOrder(int id)
        {
            Context context = new();
            return _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.Id == id)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public OrderEditDTO GetLastNumberOrder()
        {
            Context context = new();
            return _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().OrderBy(i => i.Id)).LastOrDefault();
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrders()
        {
            Context context = new();
            return _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>()).ToList();
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersByIdDiagnosis(int idDiagnosis)
        {
            Context context = new();
            return _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.DiagnosisId == idDiagnosis)).ToList();
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersByIdEquipment(int idEquipment)
        {
            Context context = new();
            return _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.EquipmentId == idEquipment)).ToList();
        }

        /// <inheritdoc/>
        public List<OrderEditDTO> GetOrdersForChart(int year, bool master = false, int? masterId = null)
        {
            Context context = new();
            var set = context.Orders.Where(i => i.StatusOrder != StatusOrderEnum.InRepair && i.StatusOrder != StatusOrderEnum.Trash);

            set = set.Where(i => i.DateCompleted.Value.Year == year);              

            if (master)
                set = set.Where(i => i.MainMasterId == masterId || i.AdditionalMasterId == masterId);

            return _mapper.ProjectTo<OrderEditDTO>(set).ToList();
        }

        /// <inheritdoc/>
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

            return _mapper.ProjectTo<OrderEditDTO>(set).ToList();
        }

        /// <inheritdoc/>
        public async Task<int> SaveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var order = _mapper.Map<OrderEditDTO, Order>(orderDTO);
            
                if (order.Id == 0)
                    context.Orders.Add(order);
                else
                    context.Orders.Update(order);
                await context.SaveChangesAsync(token);
                return order.Id;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); throw; }
        }

        /// <inheritdoc/>
        public async Task RemoveOrder(OrderEditDTO orderDTO, CancellationToken token = default)
        {
            try
            {
                Context context = new();
                var order = _mapper.Map<OrderEditDTO, Order>(orderDTO);
                context.Orders.Remove(order);
                await context.SaveChangesAsync(token);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
