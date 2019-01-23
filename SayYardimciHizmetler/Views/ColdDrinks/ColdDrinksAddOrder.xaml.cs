using Core.Common.Commands;
using MaterialDesignThemes.Wpf;
using SayYardimciHizmetler.Models.Drinks;
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

namespace SayYardimciHizmetler.Views.ColdDrinks
{
    /// <summary>
    /// Interaction logic for ColdDrinksAddOrder.xaml
    /// </summary>
    public partial class ColdDrinksAddOrder : UserControl
    {
        public ColdDrinksAddOrder()
        {
            InitializeComponent();
        }

        //separate method
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //tbox.Text = qhm.Option1;
            //MessageBox.Show("test");
            Mediator.NotifyColleagues("SelectedDrinkTypeChanged", new DrinkOrderNumber { Id = 1, Name = "Test Order Number" });

            
            //use the message queue to send a message.
            /*var messageQueue = SnackbarThree.MessageQueue;
            var message = "test başarılı text";

            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));*/
        }

        private void SnackBar3_OnClick(object sender, RoutedEventArgs e)
        {
            //use the message queue to send a message.
            /*var messageQueue = SnackbarThree.MessageQueue;
            var message = "test başarılı text";

            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));*/
        }

        private void ComboBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
