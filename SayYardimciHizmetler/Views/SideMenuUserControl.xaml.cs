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


        public static readonly RoutedEvent TestRoutedEvent = EventManager.RegisterRoutedEvent(
        "TestRouted",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(SidemenuUserControl));

        public event RoutedEventHandler TestRouted
        {
            add { AddHandler(TestRoutedEvent, value); }
            remove { RemoveHandler(TestRoutedEvent, value); }
        }

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            // Raise the custom routed event, this fires the event from the UserControl
            RaiseEvent(new RoutedEventArgs(SidemenuUserControl.TestRoutedEvent, sender as ListViewItem));


            //RouteViewer Rv = new RouteViewer(((sender as Button).Tag).ToString());
            //Rv.Show();

            



            var item = sender as ListViewItem;
            var dc = item.DataContext as SideMenu;
            var pwindow = Window.GetWindow(this);
            object obj = pwindow.FindName("BoardFrame");
            System.Windows.Controls.Frame frame = (System.Windows.Controls.Frame)obj;
            if (item != null)
            {
                //this.BoardFrame.Content = null;
                //switch (item.Name)
                //frame.Content = null;
                /*switch (dc.MenuIcon)
                {
                    case "Home":
                        {
                            //frame.Content = new DashBoard();
                            //this.BreadcrumbContent.Content = "Ana Sayfa";
                            frame.Content = new ColdDrinks();
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

                }*/
            }
        }

        private void TT_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("tt test");
        }
    }
}
