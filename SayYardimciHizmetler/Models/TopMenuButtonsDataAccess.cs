using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models
{
    public class TopMenuButtonsDataAccess : ITopMenuButtonsDataAccess
    {
        private IEnumerable<TopMenuButton> topMenuItems;

        public IEnumerable<TopMenuButton> TopMenuItems
        {
            get {
                if (topMenuItems == null)
                    GetTopMenuButtons();
                return topMenuItems;

            }
            //set { topMenuItems = value; }
        }



        public IEnumerable<TopMenuButton> GetTopMenuButtons()
        {
            return new List<TopMenuButton>()
            {
                new TopMenuButton {ButtonName = "TestButton1", ButtonContent = "test1", IconName = "Power"},
                new TopMenuButton {ButtonName = "TestButton2", ButtonContent = "test2", IconName = "Bell"},
                new TopMenuButton {ButtonName = "TestButton3", ButtonContent = "test3", IconName = "Bell"}
            };
        }
    }
}
