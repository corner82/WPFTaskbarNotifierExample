using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFTaskbarNotifier;
using Microsoft.AspNet.SignalR.Client;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// This is just a mock object to hold something of interest. 
    /// </summary>
    public class NotifyObject
    {
        public NotifyObject(string message, string title)
        {
            this.message = message;
            this.title = title;
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        private string message;
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
    }

    /// <summary>
    /// This is a TaskbarNotifier that contains a list of NotifyObjects to be displayed.
    /// </summary>
    public partial class ExampleTaskbarNotifier : TaskbarNotifier
    {

        /// <summary>
        /// This name is simply added to sent messages to identify the user; this 
        /// sample does not include authentication.
        /// </summary>
        public String UserName { get; set; }
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        public HubConnection Connection { get; set; }

        public ExampleTaskbarNotifier()
        {
            InitializeComponent();
            ConnectAsync();
        }

        private async void ConnectAsync()
        {
            try
            {
                Connection = new Microsoft.AspNet.SignalR.Client.HubConnection(ServerURI);
                Connection.Closed += Connection_Closed;
                HubProxy = Connection.CreateHubProxy("MyHub");
                //Handle incoming event from server: use Invoke to write to console from SignalR's thread
                HubProxy.On<string, string>("AddMessage", (name, message) =>
                    this.Dispatcher.Invoke(() => {
                        MessageBox.Show($"{name}, {message}");
                        this.Notify();
                        this.BoardFrame.Content = new Expanders();
                    //RichTextBoxConsole.AppendText(String.Format("{0}: {1}\r", name, message))
                    }
                    )
                );
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            try
            {
                await Connection.Start();
            }
            catch (Exception ex)
            {
                //StatusText.Content = "Unable to connect to server: Start server before connecting clients.";
                //No connection: Don't enable Send button or show chat UI
                Console.WriteLine(ex.Message);
                return;
            }

            //Show chat UI; hide login UI
            /*SignInPanel.Visibility = Visibility.Collapsed;
            ChatPanel.Visibility = Visibility.Visible;
            ButtonSend.IsEnabled = true;
            TextBoxMessage.Focus();
            RichTextBoxConsole.AppendText("Connected to server at " + ServerURI + "\r");*/
        }

        /// <summary>
        /// If the server is stopped, the connection will time out after 30 seconds (default), and the 
        /// Closed event will fire.
        /// </summary>
        void Connection_Closed()
        {
            //Hide chat UI; show login UI
            /*var dispatcher = Application.Current.Dispatcher;
            dispatcher.Invoke(() => ChatPanel.Visibility = Visibility.Collapsed);
            dispatcher.Invoke(() => ButtonSend.IsEnabled = false);
            dispatcher.Invoke(() => StatusText.Content = "You have been disconnected.");
            dispatcher.Invoke(() => SignInPanel.Visibility = Visibility.Visible*/
        }

        private ObservableCollection<NotifyObject> notifyContent;
        /// <summary>
        /// A collection of NotifyObjects that the main window can add to.
        /// </summary>
        public ObservableCollection<NotifyObject> NotifyContent
        {
            get
            {
                if (this.notifyContent == null)
                {
                    // Not yet created.
                    // Create it.
                    this.NotifyContent = new ObservableCollection<NotifyObject>();
                }

                return this.notifyContent;
            }
            set
            {
                this.notifyContent = value;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            Hyperlink hyperlink = sender as Hyperlink;

            if(hyperlink == null)
                return;

            NotifyObject notifyObject = hyperlink.Tag as NotifyObject;
            if(notifyObject != null)
            {
                MessageBox.Show("\"" + notifyObject.Message + "\"" + " clicked!");
            }
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.ForceHidden();
        }

        private void ButtonPopupLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonPopupHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ForceHidden();
            //this.taskbarNotifier.Notify();
            this.Notify();
        }

        private void ButtonPopupClose_Click(object sender, RoutedEventArgs e)
        {
            this.ForceHidden();
        }

        private void ButtonMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Collapsed;
            ButtonMenuClose.Visibility = Visibility.Visible;
        }

        
        private void ButtonMenuClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenuOpen.Visibility = Visibility.Visible;
            ButtonMenuClose.Visibility = Visibility.Collapsed;
        }

        private void ButtonTopMenuClose_Click(object sender, RoutedEventArgs e)
        {
            //this.ForceHidden();
            this.BoardFrame.Content = new Expanders();
        }

        private void ListViewItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                this.BoardFrame.Content = null;
                switch (item.Name)
                {
                    case "HomeOpener":
                        {
                            this.BoardFrame.Content = new DashBoard();
                            this.BreadcrumbContent.Content = "Ana Sayfa";
                            break;
                        }
                    case "ExpandersOpener":
                        {
                            this.BoardFrame.Content = new Expanders();
                            this.BreadcrumbContent.Content = "Expanders";
                            break;
                        }
                    case "HotDrinksOpener":
                        {
                            this.BoardFrame.Content = new HotDrinks();
                            this.BreadcrumbContent.Content = "Hot Drinks";
                            break;
                        }
                    case "ColdDrinksOpener":
                        {

                            this.BoardFrame.Content = new ColdDrinks();
                            this.BreadcrumbContent.Content = "Cold Drinks";
                            break;
                        }
                    default:
                        MessageBox.Show("default");
                        break;

                }
            }
        }
    }
}