using System.Reflection;
using ReserveSpot.Domain;

string wordPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WordExportPlugin.dll");
string excelPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExcelExportPlugin.dll");

Assembly wordAssembly = Assembly.LoadFile(wordPluginPath);
dynamic wordPlugin = wordAssembly.CreateInstance("WordExportPlugin.WordExporter");
Assembly excelAssembly = Assembly.LoadFile(excelPluginPath);
dynamic excelPlugin = excelAssembly.CreateInstance("ExcelExportPlugin.ExcelExporter");


PropertyJSONDao propertyDao = new PropertyJSONDao();
UserJSONDao userDao = new UserJSONDao();

List <Property> allProperties = propertyDao.FindMany(property => true);
List <User> allUsers= userDao.FindMany(property => true);

wordPlugin.ExportToWord(@"F:\Report.docx", allUsers, allProperties);
excelPlugin.ExportToExcel(@"F:\Report.xlsx", allUsers, allProperties);

Console.WriteLine("Reports have been generated.");