using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SayYardimiciHizmetler
{
    /// <summary>
    /// Interaction logic for ColdDrinks.xaml
    /// </summary>
    public partial class ColdDrinks : Page
    {
        public ColdDrinks()
        {
            InitializeComponent();
            
            /*this.TestItemsControl.ItemsSource = new ObservableCollection<Person>()
            {
                new Person(),
                new Person(),
                new Person(),
                new Person(),
                new Person()
            };*/
            
        }
    }

    public class Person {


    }

    public class PropertiesDrinks
    {
        private string _name;
        private int? _selectedValueOne;
        private string _selectedTextTwo;


        public PropertiesDrinks()
        {
            
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int? SelectedValueOne
        {
            get { return _selectedValueOne; }
            set { _selectedValueOne = value; }
        }


    }

}
