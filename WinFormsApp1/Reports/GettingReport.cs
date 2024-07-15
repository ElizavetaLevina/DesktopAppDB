using ClosedXML.Report;
using System.Diagnostics;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Reports
{
    public class GettingReport
    {
        OrderRepository orderRepository = new();
        public void Report(int idOrder)
        {
            try
            {
                const string outputFile = @"Output\reportGetting.xlsx";
                var template = new XLTemplate(@"Templates\reportGetting.xlsx");
                var orderDTO = orderRepository.GetOrder(idOrder);

                string device = String.Format("{0} {1} {2}", orderDTO.TypeTechnic?.Name,
                    orderDTO.BrandTechnic?.Name, orderDTO.ModelTechnic);

                template.AddVariable("Id", value: orderDTO.NumberOrder);
                template.AddVariable("MasterName", value: orderDTO.MainMaster?.NameMaster);
                template.AddVariable("IdClient", value: orderDTO.Client?.IdClient);
                template.AddVariable("ClientNameAndAddress", value: orderDTO.Client?.NameAndAddressClient);
                template.AddVariable("ClientSecondPhone", value: orderDTO.Client?.NumberSecondPhone);
                template.AddVariable("Device", value: device);
                template.AddVariable("FactoryNumber", value: orderDTO.FactoryNumber);
                template.AddVariable("Equipment", value: orderDTO.Equipment?.Name);
                template.AddVariable("Diagnosis", value: orderDTO.Diagnosis?.Name);
                template.AddVariable("Note", value: orderDTO.Note);
                template.AddVariable("DateCreation", value: orderDTO.DateCreation.Value.ToShortDateString());
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
                        LabelText = "Закройте файл reportGetting.xlsx и повторите попытку!"
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
