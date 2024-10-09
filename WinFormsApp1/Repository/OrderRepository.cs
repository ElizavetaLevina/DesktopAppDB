using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<OrderTableDTO>> GetOrdersForTableAsync(StatusOrderEnum? statusOrder = null, bool? deleted = null, 
            bool dateCreation = false, bool dateCompleted = false, bool dateIssue = false, bool id = false, 
            CancellationToken token = default)
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

            return await _mapper.ProjectTo<OrderTableDTO>(set).ToListAsync();
        }


        /// <inheritdoc/>
        public async Task<List<OrderTableDTO>> GetOrdersBySearchAsync(string numberOrder, string dateCreation, string dateStartWork, 
            string masterName, string device, string idClient, StatusOrderEnum? statusOrder, CancellationToken token = default)
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

            return await _mapper.ProjectTo<OrderTableDTO>(set.OrderByDescending(i => i.NumberOrder)).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderTableExcelDTO>> GetOrdersForExcelAsync(List<OrderTableDTO> orders, CancellationToken token = default)
        {
            return await _mapper.ProjectTo<OrderTableExcelDTO>(orders.AsQueryable()).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<OrderEditDTO> GetOrderAsync(int id, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.Id == id)).FirstOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<OrderEditDTO> GetLastNumberOrderAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().OrderBy(i => i.Id)).LastOrDefaultAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersAsync(CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>()).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersByIdDiagnosisAsync(int idDiagnosis, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.DiagnosisId == idDiagnosis))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersByIdEquipmentAsync(int idEquipment, CancellationToken token = default)
        {
            Context context = new();
            return await _mapper.ProjectTo<OrderEditDTO>(context.Set<Order>().Where(i => i.EquipmentId == idEquipment))
                .ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersForChartAsync(int year, bool master = false, int? masterId = null,
            CancellationToken token = default)
        {
            Context context = new();
            var set = context.Orders.Where(i => i.StatusOrder != StatusOrderEnum.InRepair && i.StatusOrder != StatusOrderEnum.Trash);

            set = set.Where(i => i.DateCompleted.Value.Year == year);              

            if (master)
                set = set.Where(i => i.MainMasterId == masterId || i.AdditionalMasterId == masterId);

            return await _mapper.ProjectTo<OrderEditDTO>(set).ToListAsync(token);
        }

        /// <inheritdoc/>
        public async Task<List<OrderEditDTO>> GetOrdersForSalariesAsync(DateTime? dateCompleted = null, DateTime? dateIssue = null,
            CancellationToken token = default)
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

            return await _mapper.ProjectTo<OrderEditDTO>(set).ToListAsync(token);
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
        public async Task RemoveOrderAsync(OrderEditDTO orderDTO, CancellationToken token = default)
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
