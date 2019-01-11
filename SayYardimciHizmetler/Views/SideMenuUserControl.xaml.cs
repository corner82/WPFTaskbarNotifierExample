using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.ViewModels;
using SayYardimciHizmetler.ViewModels.Factories;
using SayYardimiciHizmetler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SayYardimciHizmetler.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SidemenuUserControl : UserControl
    {
        public SidemenuUserControl()
        {
            InitializeComponent();
            //this.UserControlListView.ItemsSource = new SideMenuViewModelFactory();
            //var factory = new SideMenuViewModelFactory();
            //this.DataContext = factory.CreateViewModel(this);
            var pwindow = Window.GetWindow(this);
            //pwindow.
        }


        public static readonly RoutedEvent SidemenuNavEvent = EventManager.RegisterRoutedEvent(
        "SidemenuNav",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(SidemenuUserControl));

        public event RoutedEventHandler SidemenuNav
        {
            add { AddHandler(SidemenuNavEvent, value); }
            remove { RemoveHandler(SidemenuNavEvent, value); }
        }

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            // Raise the custom routed event, this fires the event from the UserControl
            RaiseEvent(new RoutedEventArgs(SidemenuUserControl.SidemenuNavEvent, sender as ListViewItem));

           /* var item = sender as ListViewItem;
            var dc = item.DataContext as SideMenu;
            var pwindow = Window.GetWindow(this);
            object parentWindowFrameObj = pwindow.FindName("BoardFrame");
            System.Windows.Controls.Frame frame = (System.Windows.Controls.Frame) parentWindowFrameObj;
            if (item != null)
            {
                //frame.Content = null;
                switch (dc.MenuIcon)
                {
                    case "Home":
                        {
                            frame.Content = new DashBoard();
                            //this.BreadcrumbContent.Content = "Ana Sayfa";
                            break;
                        }
                    
                    case "AccountCardDetails":
                        {
                            frame.Content = new Expanders();
                            //this.BreadcrumbContent.Content = "Expanders";
                            break;
                        }
                    case "Tea":
                        {
                            frame.Content = new HotDrinks();
                            //this.BreadcrumbContent.Content = "Hot Drinks";
                            break;
                        }
                    case "Beer":
                        {
                            frame.Content = new ColdDrinks();
                            //this.BreadcrumbContent.Content = "Cold Drinks";
                            break;
                        }
                    default:
                        MessageBox.Show("default");
                        break;

                }
            }*/
        }

        private void TT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("tt test");
        }
    }
}
