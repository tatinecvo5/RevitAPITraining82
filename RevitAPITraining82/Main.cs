using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining82
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
        //public class NavisworksExportOptions : IDisposable
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            /*return Execute(commandData, ref message, elements, NavisworksExportOptions);
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements, NavisworksExportOptions navisworksExportOptions)
        {*/
            //public void Export(string folder, string name, NavisworksExportOptions options)


            Document doc = commandData.Application.ActiveUIDocument.Document;

            using (var ts = new Transaction(doc, "экспорт в NWC"))
            {
                ts.Start();
                var nwcOption = new NavisworksExportOptions();
                doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "файл.nwc", nwcOption);

                ts.Commit();
            }
            TaskDialog.Show("Cообщение", "Файл NWC сохранен на рабочем столе");
            return Result.Succeeded;
        }
    }

}
