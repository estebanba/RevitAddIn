// System
using System.Reflection;
// Autodesk
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
// RevitAddIn
using ribUtil = RevitAddIn.Utilities.Ribbon_Utils;

// This application belongs to the root namespace
namespace RevitAddIn
{
    // Implementing the interface for applications
    public class Application: IExternalApplication
    {
        #region Properties

        // Make a private uiCtlApp
        private static UIControlledApplication _uiCtlApp;

        #endregion

        // This will run on Startup
        public Result OnStartup(UIControlledApplication uiCtlApp)
        {

            #region Globals registration

            // Store _uiCtlApp, register on idling
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

            // Registering globals
            Globals.RegisterProperties(uiCtlApp);

            #endregion

            // Collect the controlled application
            //var ctlApp = uiCtlApp.ControlledApplication;
            //var assembly = Assembly.GetExecutingAssembly();
            //var assemblyPath = assembly.Location;

            //string tabName = "RevitAddIn";

            #region Ribbon setup

            // Add a new ribbon tab
            ribUtil.AddRibbonTab(uiCtlApp, Globals.AddinName);

            // Add panels to the tab
            var panelGeneral = ribUtil.AddRibbonPanelToTab(uiCtlApp, Globals.AddinName, "General");

            // Add buttons to the panel
            var buttonTest = ribUtil.AddPushButtonToPanel(panelGeneral, "Testing", "RevitAddIn.Commands.Cmds_General.Cmd_Test", "_testing", Globals.AssemblyPath);
            var buttonAbout = ribUtil.AddPushButtonToPanel(panelGeneral, "About", "RevitAddIn.Commands.Cmds_General.Cmd_About", "_about", Globals.AssemblyPath);

            #endregion

            return Result.Succeeded;
        }

        #region On shutdown method

        // This will run on shutdown
        public Result OnShutdown(UIControlledApplication uiCtlApp)
        {
            // Cleanup code logic

            // Final return
            return Result.Succeeded;
        }

        #endregion

        #region Use idling to register UiApp

        /// <summary>
        /// Registers the UiApp and Revit username globally.
        /// </summary>
        /// <param name="sender">Sender of the Idling event.</param>
        /// <param name="e">Idling event arguments.</param>
        private static void RegisterUiApp(object sender, IdlingEventArgs e)
        {
            _uiCtlApp.Idling -= RegisterUiApp;

            if (sender is UIApplication uiApp)
            {
                Globals.UiApp = uiApp;
                Globals.UsernameRevit = uiApp.Application.Username;
            }
        }

        #endregion
    }
}