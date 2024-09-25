using AutoMapper;
using WinFormsApp1.DTO;
using WinFormsApp1.Enum;
using WinFormsApp1.Model;

namespace WinFormsApp1.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Client, ClientEditDTO>();
            CreateMap<Client, ClientDTO>();
            CreateMap<BrandTechnic, BrandTechnicDTO>();
            CreateMap<BrandTechnic, BrandTechnicEditDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameBrandTechnic));
            CreateMap<Diagnosis, DiagnosisEditDTO>();
            CreateMap<Equipment, EquipmentEditDTO>();
            CreateMap<Malfunction, MalfunctionEditDTO>();
            CreateMap<MalfunctionOrder, MalfunctionOrderEditDTO>();
            CreateMap<Master, MasterDTO>();
            CreateMap<Master, MasterEditDTO>();
            CreateMap<NoteSalaryMaster, NoteSalaryMasterEditDTO>()
                .ForMember(d => d.NameMaster, opt => opt.MapFrom(s => s.Master.NameMaster))
                .ForMember(d => d.Salary, opt => opt.Ignore());
            CreateMap<Order, OrderEditDTO>();
            CreateMap<Order, OrderTableDTO>()
                .ForMember(d => d.DateCreation, opt => opt.MapFrom(s => s.DateCreation.Value.ToShortDateString()))
                .ForMember(d => d.DateStartWork, opt => opt.MapFrom(s => s.DateStartWork.Value.ToShortDateString()))
                .ForMember(d => d.DateCompleted, opt => opt.MapFrom(s => s.DateCompleted.Value.ToShortDateString()))
                .ForMember(d => d.DateIssue, opt => opt.MapFrom(s => s.DateIssue.Value.ToShortDateString()))
                .ForMember(d => d.MasterName, opt => opt.MapFrom(s => s.AdditionalMaster != null ? string.Format("{0} | {1}",
                s.MainMaster.NameMaster, s.AdditionalMaster.NameMaster) : s.MainMaster.NameMaster))
                .ForMember(d => d.NameDevice, opt => opt.MapFrom(s => string.Format("{0} {1} {2}", s.TypeTechnic.NameTypeTechnic,
                s.BrandTechnic.NameBrandTechnic, s.ModelTechnic)))
                .ForMember(d => d.IdClient, opt => opt.MapFrom(s => s.Client.IdClient))
                .ForMember(d => d.Diagnosis, opt => opt.MapFrom(s => s.Diagnosis.Name));
            CreateMap<OrderTableDTO, OrderTableExcelDTO>();
            CreateMap<RateMaster, RateMasterDTO>()
                .ForMember(d => d.MasterName, opt => opt.MapFrom(s => s.Master.NameMaster))
                .ForMember(d => d.MonthYear, opt => opt.MapFrom(s => string.Format("{0}  {1}", (MonthEnum)s.DateStart.Month, s.DateStart.Year)));
            CreateMap<RateMaster, RateMasterEditDTO>();
            CreateMap<TypeBrand, TypeBrandDTO>();
            CreateMap<TypeTechnic, TypeTechnicDTO>();
            CreateMap<TypeTechnic, TypeTechnicEditDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameTypeTechnic));
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<Warehouse, WarehouseEditDTO>();
            CreateMap<Warehouse, WarehouseTableDTO>()
                .ForMember(d => d.DatePurchase, opt => opt.MapFrom(s => s.DatePurchase.ToShortDateString()));
            CreateMap<TypeBrand, TypeBrandComboBoxDTO>()
                .ForMember(d => d.IdBrand, opt => opt.MapFrom(s => s.BrandTechnicsId))
                .ForMember(d => d.NameBrandTechnic, opt => opt.MapFrom(s => s.BrandTechnic.NameBrandTechnic));
        }
    }
}
