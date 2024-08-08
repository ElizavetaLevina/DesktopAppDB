using System.ComponentModel;
using System.Data;

namespace WinFormsApp1.Helpers
{
    static class Funcs
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new();
            foreach (PropertyDescriptor prop in properties)
            {
                DataColumn column = new(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType)
                {
                    Caption = prop.DisplayName ?? prop.Name
                };
                table.Columns.Add(column);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
