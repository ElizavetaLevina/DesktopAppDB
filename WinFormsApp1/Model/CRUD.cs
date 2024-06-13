

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WinFormsApp1.Model
{
    public class CRUD
    {

        //BRAND TECHNIC
        public static async void AddAsyncBrandTechnic(int id, string? name)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new() { Id = id, NameBrandTechnic = name };
            try
            {
                db.BrandTechnices.Add(brandTechnic);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveBrandTechnic(int id)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new() { Id = id };
            try
            {
                db.BrandTechnices.Remove(brandTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeBrandTechnic(int id, string? name)
        {
            using Context db = new();
            BrandTechnic brandTechnic = new() { Id = id, NameBrandTechnic = name };
            try
            {
                db.BrandTechnices.Update(brandTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        //TYPE TECHNIC
        public static async void AddAsyncTypeTechnic(int id, string? name)
        {
            using Context db = new();
            TypeTechnic typeTechnic = new() { Id = id, NameTypeTechnic = name };
            try
            {
                db.TypeTechnices.Add(typeTechnic);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void RemoveTypeTechnic(int id)
        {
            using Context db = new();
            TypeTechnic typeTechnic = new() { Id = id };
            try
            {
                db.TypeTechnices.Remove(typeTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeTypeTechnic(int id, string? name)
        {
            using Context db = new();
            TypeTechnic typeTechnic = new() { Id = id, NameTypeTechnic = name };
            try
            {
                db.TypeTechnices.Update(typeTechnic);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //MASTER
        public static async void AddAsyncMaster(int id, string? name, string? address, string? numberPhone, string typeSalary, int rate)
        {
            using Context db = new();
            Master master = new() { Id = id, NameMaster = name, Address = address, NumberPhone = numberPhone, TypeSalary = typeSalary, Rate = rate };
            try
            {
                db.Masters.Add(master);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void RemoveMaster(int id)
        {
            using Context db = new();
            Master master = new() { Id = id };
            try
            {
                db.Masters.Remove(master);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeMaster(int id, string? name, string? address, string? numberPhone, string typeSalary, int rate)
        {
            using Context db = new();
            Master master = new() { Id = id, NameMaster = name, Address = address, NumberPhone = numberPhone, TypeSalary = typeSalary, Rate = rate };
            try
            {
                db.Masters.Update(master);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //CLIENT
        public static async void AddAsyncClient(int id, string? idClient, string? name, string? address, string? secondPhone, string typeClient)
        {
            using Context db = new();
            Client client = new() { Id = id, IdClient = idClient,  NameClient = name, Address = address, NumberSecondPhone = secondPhone, 
                TypeClient = typeClient };
            try
            {
                db.Clients.Add(client);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void RemoveClient(int id)
        {
            using Context db = new();
            Client client = new() { Id = id };
            try
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeClient(int id, string? idClient, string? name, string? address, string? secondPhone, string typeClient)
        {
            using Context db = new();
            Client client = new() { Id = id, IdClient = idClient, NameClient = name, Address = address, NumberSecondPhone = secondPhone,
                TypeClient = typeClient };
            try
            {
                db.Clients.Update(client);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //ORDER
        public static async void AddAsyncOrder(int id, int idClient, int? idMaster, DateTime? dateCreation,
            DateTime? dateStartWork, DateTime? dateCompleted, DateTime? dateIssue, int idTypeTechnic,
            int idBrandTechnic, string? model, string? factoryNumber, int? idEquipment,
            int? idDiagnosis, string? note, bool inProgress, int guarantee,
            DateTime? dateEndGuarantee, bool deleted, bool returnUnderGuarantee, DateTime? dateReturn,
            DateTime? dateCompletedReturn, DateTime? dateIssueReturn, bool issue, string color, string? dateLastCall, 
            bool priceAgreed, int? maxPrice)
        {
            using Context db = new();

            Order order = new() { Id = id, ClientId = idClient, MasterId = idMaster, 
                DateCreation = dateCreation, DateStartWork = dateStartWork, DateCompleted = dateCompleted, 
                DateIssue = dateIssue, TypeTechnicId = idTypeTechnic, BrandTechnicId = idBrandTechnic, 
                ModelTechnic = model, FactoryNumber = factoryNumber, EquipmentId = idEquipment, 
                DiagnosisId = idDiagnosis, Note = note, InProgress = inProgress, Guarantee = guarantee, 
                DateEndGuarantee = dateEndGuarantee, Deleted = deleted, 
                ReturnUnderGuarantee = returnUnderGuarantee, DateReturn = dateReturn, 
                DateCompletedReturn = dateCompletedReturn, DateIssueReturn = dateIssueReturn,
                Issue = issue, ColorRow = color, DateLastCall = dateLastCall, PriceAgreed = priceAgreed, 
                MaxPrice = maxPrice };
            try
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void RemoveOrder(int id)
        {
            using Context db = new();
            Order order = new() { Id = id };
            try
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeOrder(int id, int idClient, int? idMaster, DateTime? dateCreation,
            DateTime? dateStartWork, DateTime? dateCompleted, DateTime? dateIssue, int idTypeTechnic,
            int idBrandTechnic, string? model, string? factoryNumber, int? idEquipment,
            int? idDiagnosis, string? note, bool inProgress, int guarantee,
            DateTime? dateEndGuarantee, bool deleted, bool returnUnderGuarantee, DateTime? dateReturn,
            DateTime? dateCompletedReturn, DateTime? dateIssueReturn, bool issue, string color,
            string? dateLastCall, bool priceAgreed, int? maxPrice)
        {
            using Context db = new();
            Order order = new() { Id = id, ClientId = idClient, MasterId = idMaster,
                DateCreation = dateCreation, DateStartWork = dateStartWork,
                DateCompleted = dateCompleted, DateIssue = dateIssue, TypeTechnicId = idTypeTechnic,
                BrandTechnicId = idBrandTechnic,  ModelTechnic = model, FactoryNumber = factoryNumber,
                EquipmentId = idEquipment,  DiagnosisId = idDiagnosis, Note = note, InProgress = inProgress,
                Guarantee = guarantee, DateEndGuarantee = dateEndGuarantee, Deleted = deleted,
                ReturnUnderGuarantee = returnUnderGuarantee, DateReturn = dateReturn,
                DateCompletedReturn = dateCompletedReturn, DateIssueReturn = dateIssueReturn,
                Issue = issue, ColorRow = color, DateLastCall = dateLastCall, PriceAgreed = priceAgreed, 
                MaxPrice = maxPrice };
            try
            {
                db.Orders.Update(order);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //DETAILS
        public static async void AddAsyncDetails(int id, List<int>? idWarehouse)
        {
            using Context db = new();
            Details details = new() { Id = id, IdWarehouse = idWarehouse};
            try
            {
                db.Details.Add(details);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void RemoveDetails(int id)
        {
            using Context db = new();
            Details details = new() { Id = id };
            try
            {
                db.Details.Remove(details);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeDetails(int id, List<int>? idWarehouse)
        {
            using Context db = new();
            Details details = new() { Id = id, IdWarehouse = idWarehouse };
            try
            {
                db.Details.Update(details);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //WAREHOUSE
        public static async void AddAsyncWarehouse(int id, string? nameDetail, int pricePurchase, 
            int priceSale, DateTime datePurchase, bool availability, int? IdOrder)
        {
            using Context db = new();
            Warehouse warehouse = new() { Id = id, NameDetail = nameDetail, PricePurchase = pricePurchase, 
                PriceSale = priceSale, DatePurchase = datePurchase, Availability = availability, 
                IdOrder = IdOrder };
            try
            {
                db.Warehouse.Add(warehouse);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveWarehouse(int id)
        {
            using Context db = new();
            Warehouse warehouse = new() { Id = id };
            try
            {
                db.Warehouse.Remove(warehouse);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeWarehouse(int id, string? nameDetail, int pricePurchase,
            int priceSale, DateTime datePurchase, bool availability, int? IdOrder)
        {
            using Context db = new();
            Warehouse warehouse = new() { Id = id, NameDetail = nameDetail, PricePurchase = pricePurchase,
                PriceSale = priceSale, DatePurchase = datePurchase, Availability = availability,
                IdOrder = IdOrder };
            try
            {
                db.Warehouse.Update(warehouse);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //TYPEBRAND
        public static async void AddAsyncTypeBrand(int brandTechnicsId, int typeTechnicsId)
        {
            using Context db = new();
            TypeBrand typeBrand = new() { BrandTechnicsId = brandTechnicsId, 
            TypeTechnicsId = typeTechnicsId };
            try
            {
                db.TypeBrands.Add(typeBrand);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveTypeBrand(int brandTechnicsId, int typeTechnicsId)
        {
            using Context db = new();
            TypeBrand typeBrand = new() { BrandTechnicsId = brandTechnicsId,
                TypeTechnicsId = typeTechnicsId };
            try
            {
                db.TypeBrands.Remove(typeBrand);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //MALFUNCTION
        public static async void AddAsyncMalfunction(int id, string? name, int price)
        {
            using Context db = new();
            Malfunction malfunction = new()
            {
                Id = id,
                Name = name,
                Price = price
            };
            try
            {
                db.Malfunctions.Add(malfunction);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveMalfunction(int id)
        {
            using Context db = new();
            Malfunction malfunction = new() { Id = id };
            try
            {
                db.Malfunctions.Remove(malfunction);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeMalfunction(int id, string? name, int price)
        {
            using Context db = new();
            Malfunction malfunction = new()
            {
                Id = id,
                Name = name,
                Price = price
            };
            try
            {
                db.Malfunctions.Update(malfunction);
                db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //MALFUNCTIONORDER
        public static async void AddAsyncMalfunctionOrder(int malfunctionId, int orderId, int price)
        {
            using Context db = new();
            MalfunctionOrder malfunctionOrder = new()
            {
                MalfunctionId = malfunctionId,
                OrderId = orderId,
                Price = price
            };
            try
            {
                db.MalfunctionOrders.Add(malfunctionOrder);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveMalfunctionOrder(int malfunctionId, int orderId, int price)
        {
            using Context db = new();
            MalfunctionOrder malfunctionOrder = new()
            {
                MalfunctionId = malfunctionId,
                OrderId = orderId,
                Price = price
            };
            try
            {
                db.MalfunctionOrders.Remove(malfunctionOrder);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //DIAGNOSIS
        public static async void AddAsyncDiagnosis(int id, string name)
        {
            using Context db = new();
            Diagnosis diagnosis = new()
            {
                Id = id,
                Name = name
            };
            try
            {
                db.Diagnosis.Add(diagnosis);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveDiagnosis(int id)
        {
            using Context db = new();
            Diagnosis diagnosis = new() { Id = id };
            try
            {
                db.Diagnosis.Remove(diagnosis);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeDiagnosis(int id, string name)
        {
            using Context db = new();
            Diagnosis diagnosis = new()
            {
                Id = id,
                Name = name
            };
            try
            {
                db.Diagnosis.Update(diagnosis);
                db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //EQUIPMENT
        public static async void AddAsyncEquipment(int id, string name)
        {
            using Context db = new();
            Equipment equipment = new()
            {
                Id = id,
                Name = name
            };
            try
            {
                db.Equipment.Add(equipment);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void RemoveEquipment(int id)
        {
            using Context db = new();
            Equipment equipment = new() { Id = id };
            try
            {
                db.Equipment.Remove(equipment);
                db.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void ChangeEquipment(int id, string name)
        {
            using Context db = new();
            Equipment equipment = new()
            {
                Id = id,
                Name = name
            };
            try
            {
                db.Equipment.Update(equipment);
                db.SaveChangesAsync();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
