using Core.Common.Commands;
using Core.Common.Views;
using SayYardimciHizmetler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SayYardimciHizmetler.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {
        #region constructor
        public SideMenuViewModel()
        {
            DeleteCommand = new BaseCommand(OnDelete, CanDelete );

        }
        #endregion

        #region Properties
        public BaseCommand DeleteCommand { get; set; }
        private  ICommand testCommand;

        public ICommand TestCommand
        {
            get
            {
                if (testCommand == null)
                    new RelayCommand(
                        p => this.CanExecuteTestCommand(),
                        p => this.ExecuteTestCommand()
                        );
                return testCommand;
            }
            
        }

        private IList<SideMenu> menuItems;
        #endregion


        #region MenuItems
        public IList<SideMenu> MenuItems
        {
            get
            {
                if (menuItems == null)
                    LoadMenuItems();
                return menuItems;
            }
            
        }

        public void LoadMenuItems()
        {
            menuItems = new ObservableCollection<SideMenu>();

            //get the data access via the service locator.
            var dataAccess = GetService<ISideMenuDataAccess>();
            foreach (var item in dataAccess.GetSideMenuItems())
                menuItems.Add(item);
        }
        #endregion

        private bool CanExecuteTestCommand()
        {
            return true;
        }

        private void ExecuteTestCommand()
        {
            MessageBox.Show("test commnad");
        }

        private void OnDelete()
        {
            MessageBox.Show("ondelete commnad");
        }
        private bool CanDelete()
        {
            return true;
        }

        #region commndMethods



        #endregion
    }
}
