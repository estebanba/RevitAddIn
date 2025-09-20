// Autodesk
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

// Associate with general commands
namespace RevitAddIn.Commands.Cmds_General
{
    /// <summary>
    ///     Example Command
    /// </summary>
    //[UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class Cmd_Test: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Collect the documents
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Code logic here
            TaskDialog.Show("It is working", doc.Title);

            // Final return
            return Result.Succeeded;
        }

       
    }

}