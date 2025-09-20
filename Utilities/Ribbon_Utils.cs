using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddIn.Utilities
{
    public static class Ribbon_Utils
    {
        // Method to add a new ribbon tab
        public static Result AddRibbonTab(UIControlledApplication uiCtlApp, string tabName)
        {
            try
            {
                uiCtlApp.CreateRibbonTab(tabName);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: Could not create tab {tabName}. {ex.Message}");
                return Result.Failed;
            }
        }

        // Method to add a new ribbon panel to a specified tab
        public static RibbonPanel? AddRibbonPanelToTab(UIControlledApplication uiCtlApp, string tabName, string panelName)
        {
            try
            {
                return uiCtlApp.CreateRibbonPanel(tabName, panelName);
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: Could not create panel {panelName} in tab {tabName}. {ex.Message}");
                return null;
            }

            GetRibbonPanelByName(uiCtlApp, tabName, panelName); 
        }

        // Method to retrieve a ribbon panel by its name from a specified tab
        public static RibbonPanel GetRibbonPanelByName(UIControlledApplication uiCtlApp, string tabName, string panelName)
        {
            var panels = uiCtlApp.GetRibbonPanels(tabName);

            foreach (var panel in panels)
            {
                if (panel.Name == panelName)
                {
                    return panel;
                }
            }

            return null;
        }

        // Method to add a push button to a specified ribbon panel
        /// <summary>
        /// Method will be described as in the hover menu.
        /// </summary>
        /// <param name="panel">This is the ribbonpanel to add to.</param>
        /// <param name="buttonName">Test</param>
        /// <param name="className">Test</param>
        /// <param name="internalName">Test</param>
        /// <param name="assemblyPath">Test</param>
        /// <returns></returns>
        public static PushButton AddPushButtonToPanel(RibbonPanel panel, string buttonName, string className, string internalName, string assemblyPath)
        {
            if (panel == null)
            {
                Debug.WriteLine($"Error: Could not create {buttonName}. The provided RibbonPanel is null.");
                return null;
            }

            var pushButtonData = new PushButtonData(internalName, buttonName, assemblyPath, className);

            if (panel.AddItem(pushButtonData) is PushButton pushButton)
            {
                pushButton.ToolTip = $"This is the {buttonName} button.";
                pushButton.Image = null; // You can set a 16x16 image here
                pushButton.LargeImage = null; // You can set a 32x32 image here

                return pushButton;
            }
            else
            {
                Debug.WriteLine($"Error: Could not create {buttonName}. Failed to add PushButtonData to the panel.");
                return null;
            }
           
        }
    }
}
