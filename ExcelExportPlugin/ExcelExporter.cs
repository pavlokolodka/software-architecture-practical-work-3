using Microsoft.Office.Interop.Excel;
using ReserveSpot.Domain;

namespace ExcelExportPlugin
{
    public class ExcelExporter
    {
        public void ExportToExcel(string path, List<User> users, List<Property> properties)
        {
            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Add();

            try
            {
                Worksheet userSheet = workbook.Sheets.Add();
                userSheet.Name = "Users";

                userSheet.Cells[1, 1] = "Email";
                userSheet.Cells[1, 2] = "FirstName";
                userSheet.Cells[1, 3] = "LastName";
                userSheet.Cells[1, 4] = "IsAdmin";
                userSheet.Cells[1, 5] = "IsVerified";

                for (int i = 0; i < users.Count; i++)
                {
                    userSheet.Cells[i + 2, 1] = users[i].Email;
                    userSheet.Cells[i + 2, 2] = users[i].FirstName;
                    userSheet.Cells[i + 2, 3] = users[i].LastName;
                    userSheet.Cells[i + 2, 4] = users[i].IsAdmin.ToString();
                    userSheet.Cells[i + 2, 5] = users[i].IsVerified.ToString();
                }

                Worksheet propertySheet = workbook.Sheets.Add();
                propertySheet.Name = "Properties";

                propertySheet.Cells[1, 1] = "Name";
                propertySheet.Cells[1, 2] = "Description";
                propertySheet.Cells[1, 3] = "ImageUrl";
                propertySheet.Cells[1, 4] = "Type";
                propertySheet.Cells[1, 5] = "Location";
                propertySheet.Cells[1, 6] = "ContactPhone";
                propertySheet.Cells[1, 7] = "ContactName";
                propertySheet.Cells[1, 8] = "PricePerNight";
                propertySheet.Cells[1, 9] = "Capacity";
                propertySheet.Cells[1, 10] = "UserID";

                for (int i = 0; i < properties.Count; i++)
                {
                    propertySheet.Cells[i + 2, 1] = properties[i].Name;
                    propertySheet.Cells[i + 2, 2] = properties[i].Description;
                    propertySheet.Cells[i + 2, 3] = properties[i].ImageUrl;
                    propertySheet.Cells[i + 2, 4] = properties[i].Type.ToString();
                    propertySheet.Cells[i + 2, 5] = properties[i].Location;
                    propertySheet.Cells[i + 2, 6] = properties[i].ContactPhone;
                    propertySheet.Cells[i + 2, 7] = properties[i].ContactName;
                    propertySheet.Cells[i + 2, 8] = properties[i].PricePerNight.ToString();
                    propertySheet.Cells[i + 2, 9] = properties[i].Capacity.ToString();
                    propertySheet.Cells[i + 2, 10] = properties[i].UserID.ToString();
                }

                workbook.SaveAs(path);
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
