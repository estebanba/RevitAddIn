// System
using System;

// Autodesk
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;

namespace RevitAddIn.General
{
    public static class Globals
    {
        #region Properties
        // Applications
        public static UIControlledApplication UiCtlApp { get; set; }
        public static ControlledApplication CtlApp { get; set; }
        public static UIApplication UiApp { get; set; }

        // Assembly
        public static System.Reflection.Assembly Assembly { get; set; }
        public static string AssemblyPath { get; set; }

        // Revit versioning
        public static string RevitVersion { get; set;}
        public static int? RevitVersionInt { get; set; }
                
        // User names
        public static string UsernameRevit { get; set; }
        public static string UsernameWindows { get; set; }
        
        // Guids and versioning
        public static string AddinVersionNumber { get; set; }
        public static string AddinVersionName {get; set;}
        public static string AddinName { get; set; }
        public static string AddinGuid { get; set; }

        #endregion

        #region Register Method

        // Method to register properties
        public static void RegisterProperties(UIControlledApplication uiCtlApp)
        {
            UiCtlApp = uiCtlApp;
            CtlApp = uiCtlApp.ControlledApplication;
            // UiApp set on idling

            Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            AssemblyPath = Assembly.Location;

            RevitVersion = CtlApp.VersionNumber;
            RevitVersionInt = int.Parse(RevitVersion);

            // Revit username set on idling
            //UsernameRevit = UiApp.Application.Username;
            UsernameWindows = Environment.UserName;

            AddinVersionNumber = "26.03.01";
            AddinVersionName = "WIP";
            AddinName = "RevitAddIn";
            AddinGuid = "F6E4C718-21A6-4BA3-9386-ED59A4340EF3";
        }
        #endregion
    }
}
