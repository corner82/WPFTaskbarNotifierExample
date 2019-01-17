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

namespace SayYardimciHizmetler.Views.TransitionTest
{
    /// <summary>
    /// Interaction logic for Slide6_Intro.xaml
    /// </summary>
    public partial class Slide6_Intro : UserControl
    {
        public Slide6_Intro()
        {
            InitializeComponent();
        }

        private void FirstSlideButton_OnClick(object sender, RoutedEventArgs e)
        {
            Transitioner.SelectedIndex = 0;
        }

        private void SecondSlideButton_OnClick(object sender, RoutedEventArgs e)
        {
            Transitioner.SelectedIndex = 1;
        }

    }
}
