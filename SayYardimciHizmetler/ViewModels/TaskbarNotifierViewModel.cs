using Core.Common.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels
{
    public class TaskbarNotifierViewModel : BaseViewModel
    {
        #region constructor
        public TaskbarNotifierViewModel()
        {

        }
        #endregion

        #region properties

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }



        #endregion


    }
}
