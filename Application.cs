// System
using System.Reflection;
// Autodesk
using Autodesk.Revit.UI;
// RevitAddIn
using ribUtil = RevitAddIn.Utilities.Ribbon_Utils;

// This application belongs to the root namespace
namespace RevitAddIn
{
    // Implementing the interface for applications
    public class Application: IExternalApplication
    {
        // This will run on Startup
        public Result OnStartup(UIControlledApplication uiCtlApp)
        {
            // Collect the controlled application
            var ctlApp = uiCtlApp.ControlledApplication;
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyPath = assembly.Location;

            string tabName = "RevitAddIn";

            // Add a new ribbon tab
            ribUtil.AddRibbonTab(uiCtlApp, tabName);

            // Add panels to the tab
            var panelGeneral = ribUtil.AddRibbonPanelToTab(uiCtlApp, tabName, "General");

            // Add buttons to the panel
            var buttonTest = ribUtil.AddPushButtonToPanel(panelGeneral, "Testing", "RevitAddIn.Commands.Cmds_General.Cmd_Test", "_testing", assemblyPath);

            return Result.Succeeded;
        }

        // This will run on Shutdown
        public Result OnShutdown(UIControlledApplication uiCtlApp)
        {
            return Result.Succeeded;
        }
    }
}