using Microsoft.Office.Interop.Word;
using ReserveSpot.Domain;

namespace WordExportPlugin
{
    public class WordExporter
    {
        public void ExportToWord(string path, List<User> users, List<Property> properties)
        {
            Application wordApp = new Application();
            Document doc = wordApp.Documents.Add();

            try
            {
                Paragraph userParagraph = doc.Content.Paragraphs.Add();
                Table userTable = doc.Tables.Add(userParagraph.Range, users.Count + 1, 6);
                userTable.Borders.Enable = 1;

                userTable.Cell(1, 1).Range.Text = "Email";
                userTable.Cell(1, 2).Range.Text = "FirstName";
                userTable.Cell(1, 3).Range.Text = "LastName";
                userTable.Cell(1, 4).Range.Text = "IsAdmin";
                userTable.Cell(1, 5).Range.Text = "IsVerified";

                for (int i = 0; i < users.Count; i++)
                {
                    userTable.Cell(i + 2, 1).Range.Text = users[i].Email;
                    userTable.Cell(i + 2, 2).Range.Text = users[i].FirstName;
                    userTable.Cell(i + 2, 3).Range.Text = users[i].LastName;
                    userTable.Cell(i + 2, 4).Range.Text = users[i].IsAdmin.ToString();
                    userTable.Cell(i + 2, 5).Range.Text = users[i].IsVerified.ToString();
                }

                Paragraph emptyParagraph = doc.Content.Paragraphs.Add();
                emptyParagraph.Range.Text = "\n";

                Paragraph propertyParagraph = doc.Content.Paragraphs.Add();
                Table propertyTable = doc.Tables.Add(propertyParagraph.Range, properties.Count + 1, 10);
                propertyTable.Borders.Enable = 1;

                propertyTable.Cell(1, 1).Range.Text = "Name";
                propertyTable.Cell(1, 2).Range.Text = "Description";
                propertyTable.Cell(1, 3).Range.Text = "ImageUrl";
                propertyTable.Cell(1, 4).Range.Text = "Type";
                propertyTable.Cell(1, 5).Range.Text = "Location";
                propertyTable.Cell(1, 6).Range.Text = "ContactPhone";
                propertyTable.Cell(1, 7).Range.Text = "ContactName";
                propertyTable.Cell(1, 8).Range.Text = "PricePerNight";
                propertyTable.Cell(1, 9).Range.Text = "Capacity";
                propertyTable.Cell(1, 10).Range.Text = "UserID";

                for (int i = 0; i < properties.Count; i++)
                {
                    propertyTable.Cell(i + 2, 1).Range.Text = properties[i].Name;
                    propertyTable.Cell(i + 2, 2).Range.Text = properties[i].Description;
                    propertyTable.Cell(i + 2, 3).Range.Text = properties[i].ImageUrl;
                    propertyTable.Cell(i + 2, 4).Range.Text = properties[i].Type.ToString();
                    propertyTable.Cell(i + 2, 5).Range.Text = properties[i].Location;
                    propertyTable.Cell(i + 2, 6).Range.Text = properties[i].ContactPhone;
                    propertyTable.Cell(i + 2, 7).Range.Text = properties[i].ContactName;
                    propertyTable.Cell(i + 2, 8).Range.Text = properties[i].PricePerNight.ToString();
                    propertyTable.Cell(i + 2, 9).Range.Text = properties[i].Capacity.ToString();
                    propertyTable.Cell(i + 2, 10).Range.Text = properties[i].UserID.ToString();
                }


                doc.SaveAs2(path);
            }
            finally
            {
                doc.Close(false);
                wordApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
