using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Threading;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        

        public App()
        {
            

            Current.DispatcherUnhandledException += ProcessDispatcherException;
            AppDomain.CurrentDomain.UnhandledException += ProcessUnhandledException;
             
        }

        private static void ProcessUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            //Process.Start(@"C:\Users\M. Zeynel Da�l�\Documents\Visual Studio 2017\Projects\WPFTaskbarNotifier_src\WPFTaskbarNotifierExample\WPFTaskbarNotifierExample\bin\Debug\WPFTaskbarNotifierExample.exe");
        }

        private void ProcessDispatcherException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            e.Handled = true;
        }


    }

    
}