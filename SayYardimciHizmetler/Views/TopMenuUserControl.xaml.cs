using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for TopMenuUserControl.xaml
    /// </summary>
    public partial class TopMenuUserControl : UserControl
    {
        #region constructor
        public TopMenuUserControl()
        {
            InitializeComponent();
            CommandBinding customCommandBinding = new CommandBinding(
            CustomRoutedCommand, ExecutedCustomCommand, CanExecuteCustomCommand);

            // attach CommandBinding to root window
            this.CommandBindings.Add(customCommandBinding);
        }
        #endregion

        #region routed commands
        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();


        private void ExecutedCustomCommand(object sender,
                                            ExecutedRoutedEventArgs e)
        {
            //var src = 
            var src = e.OriginalSource as Button;
            PropertyInfo tt = src.GetType().GetProperty("Tag");
            var val = tt.GetValue(src);
            RaiseEvent(new RoutedEventArgs(TopMenuUserControl.TopMenuCloseWindowEvent, src as Button));
            //MessageBox.Show("Custom Command Executed");
        }

        // CanExecuteRoutedEventHandler that only returns true if
        // the source is a control.
        private void CanExecuteCustomCommand(object sender,
            CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        #endregion

        #region routed events
        public static RoutedEvent TopMenuCloseWindowEvent = EventManager.RegisterRoutedEvent("TopMenuCloseWindow",
                                                                                            RoutingStrategy.Bubble,
                                                                                            typeof(RoutedEventHandler),
                                                                                            typeof(TopMenuUserControl));
        public event RoutedEventHandler TopMenuCloseWindow
        {
            add { AddHandler(TopMenuCloseWindowEvent, value); }
            remove { RemoveHandler(TopMenuCloseWindowEvent, value); }
        }



        #endregion

        private void Item_Click(object sender, EventArgs e)
        {
            /*Hyperlink hyperlink = sender as Hyperlink;

            if (hyperlink == null)
                return;

            NotifyObject notifyObject = hyperlink.Tag as NotifyObject;
            if (notifyObject != null)
            {
                MessageBox.Show("\"" + notifyObject.Message + "\"" + " clicked!");
            }*/
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            //this.ForceHidden();
        }

        private void ButtonPopupLogout_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
        }

        private void ButtonPopupHelp_Click(object sender, RoutedEventArgs e)
        {
            //this.ForceHidden();
            //this.Notify();
        }

        private void ButtonPopupClose_Click(object sender, RoutedEventArgs e)
        {
            //this.ForceHidden();
            // Raise the custom routed event, this fires the event from the UserControl
            RaiseEvent(new RoutedEventArgs(TopMenuUserControl.TopMenuCloseWindowEvent, sender as Button));
        }

        private void ButtonMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            /*ButtonMenuOpen.Visibility = Visibility.Collapsed;
            ButtonMenuClose.Visibility = Visibility.Visible;*/
            //var tt = MainScrollViewer.ComputedHorizontalScrollBarVisibility;
            //this.MainScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;

        }

        private void ButtonMenuClose_Click(object sender, RoutedEventArgs e)
        {
            /*ButtonMenuOpen.Visibility = Visibility.Visible;
            ButtonMenuClose.Visibility = Visibility.Collapsed;*/
        }

        private void ButtonTopMenuClose_Click(object sender, RoutedEventArgs e)
        {
            //this.ForceHidden();
            //this.BoardFrame.Content = new Expanders();
        }

    }
}
