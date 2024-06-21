

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WinFormsApp1.Model
{
    public class CRUD
    {

        //ORDER
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
