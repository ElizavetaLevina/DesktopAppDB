using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using WinFormsApp1.Logic;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Mappings;
using WinFormsApp1.Repository;
using WinFormsApp1.Repository.Interfaces;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Приложение уже открыто!");
                return;
            }
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());

        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    var mapperConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfiles(new List<Profile> {
                            new AppMappingProfile()
                        });
                    });
                    mapperConfig.AssertConfigurationIsValid();
                    services.AddSingleton(mapperConfig.CreateMapper());
                    services.AddTransient<IBrandTechnicRepository, BrandTechnicRepository>();
                    services.AddTransient<IClientRepository, ClientRepository>();
                    services.AddTransient<IDiagnosisRepository, DiagnosisRepository>();
                    services.AddTransient<IEquipmentRepository, EquipmentRepository>();
                    services.AddTransient<IMalfunctionOrderRepository, MalfunctionOrderRepository>();
                    services.AddTransient<IMalfunctionRepository, MalfunctionRepository>();
                    services.AddTransient<IMasterRepository, MasterRepository>();
                    services.AddTransient<INoteSalaryMasterRepository, NoteSalaryMasterRepository>();
                    services.AddTransient<IOrderRepository, OrderRepository>();
                    services.AddTransient<IRateMasterRepository, RateMasterRepository>();
                    services.AddTransient<ITypeBrandRepository, TypeBrandRepository>();
                    services.AddTransient<ITypeTechnicRepository, TypeTechnicRepository>();
                    services.AddTransient<IWarehouseRepository, WarehouseRepository>();

                    services.AddTransient<IBrandsTechnicsLogic, BrandsTechnicsLogic>();
                    services.AddTransient<IClientsLogic, ClientsLogic>();
                    services.AddTransient<IDiagnosesLogic, DiagnosesLogic>();
                    services.AddTransient<IEquipmentsLogic, EquipmentsLogic>();
                    services.AddTransient<IMalfunctionsOrdersLogic, MalfunctionsOrdersLogic>();
                    services.AddTransient<IMalfunctionsLogic, MalfunctionsLogic>();
                    services.AddTransient<IMastersLogic, MastersLogic>();
                    services.AddTransient<INotesSalaryMastersLogic, NotesSalaryMastersLogic>();
                    services.AddTransient<IOrdersLogic, OrdersLogic>();
                    services.AddTransient<IRateMastersLogic, RateMastersLogic>();
                    services.AddTransient<ITypesBrandsLogic, TypesBrandsLogic>();
                    services.AddTransient<ITypesTechnicsLogic, TypesTechnicsLogic>();
                    services.AddTransient<IWarehousesLogic, WarehousesLogic>();

                    services.AddTransient<AddDeviceIntoRepair>();
                    services.AddTransient<BrandAndTypeEdit>();
                    services.AddTransient<BrandsTechnic>();
                    services.AddTransient<CalculatingEmployeeSalaries>();
                    services.AddTransient<CompletedOrder>();
                    services.AddTransient<DetailEdit>();
                    services.AddTransient<DetailsInOrder>();
                    services.AddTransient<DetailsInWarehouse>();
                    services.AddTransient<Form1>();
                    services.AddTransient<GuideClients>();
                    services.AddTransient<IssuingClient>();
                    services.AddTransient<MalfunctionEquipmentDiagnosis>();
                    services.AddTransient<MalfunctionEquipmentDiagnosisEdit>();
                    services.AddTransient<MasterEdit>();
                    services.AddTransient<Masters>();
                    services.AddTransient<MessageToClient>();
                    services.AddTransient<PropertiesClient>();
                    services.AddTransient<PropertiesOrder>();
                    services.AddTransient<RateMasterEdit>();
                    services.AddTransient<ReportsOrganization>();
                    services.AddTransient<TypesTechnic>();
                    services.AddTransient<View>();
                    services.AddTransient<Warning>();
                });
        }
    }
}