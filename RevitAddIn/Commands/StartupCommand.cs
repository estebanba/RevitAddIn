using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;

namespace RevitAddIn.Commands
{
    /// <summary>
    ///     External command entry point
    /// </summary>
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class StartupCommand : ExternalCommand
    {
        public override void Execute()
        {
            TaskDialog.Show(Document.Title, "Revit Add-In is started!");

            var titleBlockId = ElementId.InvalidElementId;

            try
            {
                var sheet = ViewSheet.Create(Document, titleBlockId);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sheet could not be made\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }
    }
}