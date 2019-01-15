using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Threading;
using Core.Common.ServiceLocator;
using SayYardimciHizmetler.Models;
using Core.Common.User;

namespace SayYardimiciHizmetler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        

        public App()
        {

            // set current user for servicemanager
            ServiceLocatorSingleton.Instance.RegisterServiceObject<IUser>(new UserBase {
                                                                                Name = "Mustafa",
                                                                                SicilNo = 9732,
                                                                                Surname = "Yetkili"
                                                                                });

            //ServiceLocatorSingleton.Instance.RegisterServiceObject<ISideMenuDataAccess>(new SideMenuDataAccess());
            //ServiceLocatorSingleton.Instance.RegisterServiceObject<ITopMenuButtonsDataAccess>(new TopMenuButtonsDataAccess());

            Current.DispatcherUnhandledException += ProcessDispatcherException;
            AppDomain.CurrentDomain.UnhandledException += ProcessUnhandledException;
            



        }

        private static void ProcessUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            //Process.Start(@"C:\Users\M. Zeynel Daðlý\Documents\Visual Studio 2017\Projects\WPFTaskbarNotifier_src\SayYardimiciHizmetler\SayYardimiciHizmetler\bin\Debug\SayYardimiciHizmetler.exe");
        }

        private void ProcessDispatcherException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            e.Handled = true;
        }


    }

    
}