using ClosedXML.Report;
using System.Diagnostics;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Reports
{
    public class IssuingReport
    {
        OrderRepository orderRepository = new();
        WarehouseRepository warehouseRepository = new();
        MalfunctionOrderRepository malfunctionOrderRepository = new();
        public void Report(int idOrder) 
        {
            try
            {
                List<string> nameDetailsInFail = [];
                List<string> priceDetailsInFail = [];
                List<string> nameProblemInFail = [];
                List<string> priceProblemInFail = [];
                List<string> nameProblem = [];
                List<int> priceProblem = [];
                List<string> detailsName = [];
                List<int> detailsPrice = [];
                int foundProblemSum = 0;
                int detailsSum = 0;
                const string outputFile = @"Output\reportIssuing.xlsx";
                var template = new XLTemplate(@"Templates\reportIssuing.xlsx");
                var orderDTO = orderRepository.GetOrder(idOrder);
                var detalsDTO = warehouseRepository.GetDetailsInOrder(idOrder);
                var malfunctionOrderDTO = malfunctionOrderRepository.GetMalfunctionOrdersByIdOrder(idOrder);

                for(int i = 0; i < 5; i++)
                {
                    nameDetailsInFail.Add(String.Format("NameDetails{0}", i));
                    priceDetailsInFail.Add(String.Format("PriceDetails{0}", i));
                }

                for(int i = 0; i < 3; i++)
                {
                    nameProblemInFail.Add(String.Format("FoundProblem{0}", i));
                    priceProblemInFail.Add(String.Format("PriceRepair{0}", i));
                }

                foreach(var malfunction in malfunctionOrderDTO)
                {
                    nameProblem.Add(malfunction.Malfunction.Name);
                    priceProblem.Add(malfunction.Price);
                    foundProblemSum += malfunction.Price;
                }

                foreach (var detail in detalsDTO)
                {
                    detailsName.Add(detail.NameDetail);
                    detailsPrice.Add(detail.PriceSale);
                    detailsSum += detail.PriceSale;
                }

                string device = String.Format("{0} {1} {2}", orderDTO.TypeTechnic?.Name,
                    orderDTO.BrandTechnic?.Name, orderDTO.ModelTechnic);

                template.AddVariable("Id", value: orderDTO.Id);
                template.AddVariable("MasterName", value: orderDTO.Master?.NameMaster);
                template.AddVariable("IdClient", value: orderDTO.Client?.IdClient);
                template.AddVariable("ClientNameAndAddress", value: orderDTO.Client?.NameAndAddressClient);
                template.AddVariable("ClientSecondPhone", value: orderDTO.Client?.NumberSecondPhone);
                template.AddVariable("Device", value: device);
                template.AddVariable("FactoryNumber", value: orderDTO.FactoryNumber);
                template.AddVariable("Equipment", value: orderDTO.Equipment?.Name);
                template.AddVariable("Diagnosis", value: orderDTO.Diagnosis?.Name);
                template.AddVariable("Note", value: orderDTO.Note);
                template.AddVariable("DateCreation", value: orderDTO.DateCreation.Value.ToShortDateString());
                template.AddVariable("DetailsSumPrice", value: detailsSum);
                template.AddVariable("DateEndGuarantee", value: orderDTO.DateEndGuarantee.Value.ToShortDateString());
                template.AddVariable("DateIssuing", value: orderDTO.DateIssue.Value.ToShortDateString());

                for (int i = 0; i < nameDetailsInFail.Count; i++)
                {
                    if (i < detailsName.Count)
                    {
                        template.AddVariable(nameDetailsInFail[i], value: detailsName[i]);
                        template.AddVariable(priceDetailsInFail[i], value: detailsPrice[i]);
                    }
                    else
                    {
                        template.AddVariable(nameDetailsInFail[i], value: null);
                        template.AddVariable(priceDetailsInFail[i], value: null);
                    }
                }
                for (int i = 0; i < nameProblemInFail.Count; i++)
                {
                    if (i < nameProblem.Count)
                    {
                        template.AddVariable(nameProblemInFail[i], value: nameProblem[i]);
                        template.AddVariable(priceProblemInFail[i], value: priceProblem[i]);
                    }
                    else
                    {
                        template.AddVariable(nameProblemInFail[i], value: null);
                        template.AddVariable(priceProblemInFail[i], value: null);
                    }
                }
                template.AddVariable("TotalPrice", value: (detailsSum + foundProblemSum));
                template.AddVariable("OrgName", value: Properties.Settings.Default.NameOrg);
                template.AddVariable("OrgAddress", value: Properties.Settings.Default.AddressOrg);
                template.AddVariable("OrgPhone", value: Properties.Settings.Default.PhoneOrg);
                template.AddVariable("OrgFax", value: Properties.Settings.Default.FaxOrg);
                template.AddVariable("OrgMail", value: Properties.Settings.Default.MailOrg);

                template.Generate();
                try
                {
                    template.SaveAs(outputFile);
                }
                catch (Exception)
                {
                    Warning warning = new()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        LabelText = "Закройте файл reportIssuing.xlsx и повторите попытку!"
                    };
                    warning.ShowDialog();
                }
                Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
