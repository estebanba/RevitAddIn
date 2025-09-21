// System
using System.Reflection;
// Autodesk
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using RevitAddIn.General;

// RevitAddIn
using ribUtil = RevitAddIn.Utilities.Ribbon_Utils;

// This application belongs to the root namespace
namespace RevitAddIn
{
    // Implementing the interface for applications
    public class Application: IExternalApplication
    {
        // Make a private uiCtlApp
        private static UIControlledApplication _uiCtlApp;

        // This will run on Startup
        public Result OnStartup(UIControlledApplication uiCtlApp)
        {
            #region Globals registration
            // Store the uiCtlApp in the private variable
            _uiCtlApp = uiCtlApp;

            try
            {
                _uiCtlApp.Idling += RegisterUiApp;
            }
            catch
            {
                Globals.UiApp = null;
                Globals.UsernameRevit = null;
            }

            // Globals
            Globals.RegisterProperties(uiCtlApp);

            // Collect the controlled application -> NOW IN GLOBALS
            //var ctlApp = uiCtlApp.ControlledApplication;
            //var assembly = Assembly.GetExecutingAssembly();
            //var assemblyPath = assembly.Location;
            //string tabName = "RevitAddIn";

            #endregion

            #region Ribbon setup

            // Add a new ribbon tab
            ribUtil.AddRibbonTab(uiCtlApp, Globals.AddinName);

            // Add panels to the tab
            var panelGeneral = ribUtil.AddRibbonPanelToTab(uiCtlApp, Globals.AddinName, "General");

            // Add buttons to the panel
            var buttonTest = ribUtil.AddPushButtonToPanel(panelGeneral, "Testing", "RevitAddIn.Commands.Cmds_General.Cmd_Test", "_testing", Globals.AssemblyPath);

            #endregion

            // Final return
            return Result.Succeeded;
        }

        #region On shutdown method

        // This will run on Shutdown
        public Result OnShutdown(UIControlledApplication uiCtlApp)
        {
            return Result.Succeeded;
        }

        #endregion

        #region Use idling to register UiApp
        // On idling, register UiApp/username
        private static void RegisterUiApp(object sender, IdlingEventArgs e)
        {
            _uiCtlApp.Idling -= RegisterUiApp;

            if (sender is UIApplication uiApp )
            {
                Globals.UiApp = uiApp;
                Globals.UsernameRevit = uiApp.Application.Username;
            }
        }

        #endregion
    }
}