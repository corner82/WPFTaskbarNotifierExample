using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.ColdDrinks
{

    public class ColdDrinkTypesDataAccess : IColdDrinkTypesDataAccess
    {
        private ObservableCollection<ColdDrinkType> coldDrinkTypes;

        public ObservableCollection<ColdDrinkType> ColdDrinkTypes
        {
            get {
                if (coldDrinkTypes == null)
                    coldDrinkTypes = this.GetAllColdDrinks();
                    return coldDrinkTypes;
            }
            set { coldDrinkTypes = value; }
        }

        public ObservableCollection<ColdDrinkType> GetAllColdDrinks()
        {
            return new ObservableCollection<ColdDrinkType>() {
                new ColdDrinkType
                {
                    ColdDrinksAttr = new ObservableCollection<ColdDrinkAttribute>()
                    {
                        new ColdDrinkAttribute{ Id = 1, PropertyName = "500 ml"},
                        new ColdDrinkAttribute {Id = 2, PropertyName = "1500 ml"}
                    },
                    Name = "Su",
                    OrderNumbers = new ObservableCollection<ColdDrinkOrderNumber>()
                    {
                        new ColdDrinkOrderNumber{ Id = 1, Name = "1"},
                        new ColdDrinkOrderNumber{ Id = 2, Name = "2"},
                        new ColdDrinkOrderNumber{ Id = 3, Name = "3"},
                        new ColdDrinkOrderNumber{ Id = 4, Name = "4"},
                        new ColdDrinkOrderNumber{ Id = 5, Name = "5"},
                        new ColdDrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                },
                new ColdDrinkType
                {
                    ColdDrinksAttr = new ObservableCollection<ColdDrinkAttribute>()
                    {
                        new ColdDrinkAttribute{ Id = 3, PropertyName = "Sade"},
                        new ColdDrinkAttribute {Id = 4, PropertyName = "Limon"},
                        new ColdDrinkAttribute {Id = 5, PropertyName = "Karışık"}
                    },
                    Name = "Maden Suyu",
                    OrderNumbers = new ObservableCollection<ColdDrinkOrderNumber>()
                    {
                        new ColdDrinkOrderNumber{ Id = 1, Name = "1"},
                        new ColdDrinkOrderNumber{ Id = 2, Name = "2"},
                        new ColdDrinkOrderNumber{ Id = 3, Name = "3"},
                        new ColdDrinkOrderNumber{ Id = 4, Name = "4"},
                        new ColdDrinkOrderNumber{ Id = 5, Name = "5"},
                        new ColdDrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                },
                new ColdDrinkType
                {
                    ColdDrinksAttr = new ObservableCollection<ColdDrinkAttribute>()
                    {
                        new ColdDrinkAttribute{ Id = 6, PropertyName = "Karışık"},
                        new ColdDrinkAttribute {Id = 7, PropertyName = "Vişne"},
                        new ColdDrinkAttribute {Id = 8, PropertyName = "Şeftali"}
                    },
                    Name = "Meyve Suyu",
                    OrderNumbers = new ObservableCollection<ColdDrinkOrderNumber>()
                    {
                        new ColdDrinkOrderNumber{ Id = 1, Name = "1"},
                        new ColdDrinkOrderNumber{ Id = 2, Name = "2"},
                        new ColdDrinkOrderNumber{ Id = 3, Name = "3"},
                        new ColdDrinkOrderNumber{ Id = 4, Name = "4"},
                        new ColdDrinkOrderNumber{ Id = 5, Name = "5"},
                        new ColdDrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                }
            };
        }

        /*public ObservableCollection<ColdDrinkAttribute> GetAllColdDrinkAttr()
        {
            ObservableCollection<ColdDrinkType> coldDinkTypes = GetAllColdDrinks();
            ObservableCollection<ColdDrinkAttribute> coldDrinkAttr = new ObservableCollection<ColdDrinkAttribute>();
            foreach (var item in coldDinkTypes)
            {
                //coldDrinkAttr.Add(item.ColdDrinksAttr);
            }
        }*/
    }
}
