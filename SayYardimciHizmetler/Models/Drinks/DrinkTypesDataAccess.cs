using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public class DrinkTypesDataAccess : IDrinkTypesDataAccess
    {
        private List<DrinkType> coldDrinkTypes;

        public List<DrinkType> ColdDrinkTypes
        {
            get
            {
                if (coldDrinkTypes == null)
                    coldDrinkTypes = this.GetAllColdDrinks();
                return coldDrinkTypes;
            }
            set { coldDrinkTypes = value; }
        }


        public List<DrinkType> GetAllColdDrinks()
        {
            return new List<DrinkType>() {
                new DrinkType
                {
                    DrinksAttr = new List<DrinkAttr>()
                    {
                        new DrinkAttr{ Id = 1, PropertyName = "500 ml", Price = 0.5},
                        new DrinkAttr {Id = 2, PropertyName = "1500 ml", Price = 1}
                    },
                    DrinkTypeID = 1,
                    Name = "Su",
                    BaseTypeID = 1,
                    //Price = 0.5,
                    OrderNumbers = new List<DrinkOrderNumber>()
                    {
                        new DrinkOrderNumber{ Id = 1, Name = "1"},
                        new DrinkOrderNumber{ Id = 2, Name = "2"},
                        new DrinkOrderNumber{ Id = 3, Name = "3"},
                        new DrinkOrderNumber{ Id = 4, Name = "4"},
                        new DrinkOrderNumber{ Id = 5, Name = "5"},
                        new DrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                },
                new DrinkType
                {
                    DrinksAttr = new List<DrinkAttr>()
                    {
                        new DrinkAttr{ Id = 3, PropertyName = "Sade", Price = 0.5},
                        new DrinkAttr {Id = 4, PropertyName = "Limon", Price = 1},
                        new DrinkAttr {Id = 5, PropertyName = "Karışık", Price = 1}
                    },
                    DrinkTypeID = 2,
                    Name = "Maden Suyu",
                    //Price = 1,
                    OrderNumbers = new List<DrinkOrderNumber>()
                    {
                        new DrinkOrderNumber{ Id = 1, Name = "1"},
                        new DrinkOrderNumber{ Id = 2, Name = "2"},
                        new DrinkOrderNumber{ Id = 3, Name = "3"},
                        new DrinkOrderNumber{ Id = 4, Name = "4"},
                        new DrinkOrderNumber{ Id = 5, Name = "5"},
                        new DrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                },
                new DrinkType
                {
                    DrinksAttr = new List<DrinkAttr>()
                    {
                        new DrinkAttr{ Id = 6, PropertyName = "Karışık", Price = 1.5},
                        new DrinkAttr {Id = 7, PropertyName = "Vişne", Price = 1.5},
                        new DrinkAttr {Id = 8, PropertyName = "Şeftali", Price = 1.5}
                    },
                    DrinkTypeID = 3,
                    Name = "Meyve Suyu",
                    BaseTypeID = 1,
                    //Price = 1.5,
                    OrderNumbers = new List<DrinkOrderNumber>()
                    {
                        new DrinkOrderNumber{ Id = 1, Name = "1"},
                        new DrinkOrderNumber{ Id = 2, Name = "2"},
                        new DrinkOrderNumber{ Id = 3, Name = "3"},
                        new DrinkOrderNumber{ Id = 4, Name = "4"},
                        new DrinkOrderNumber{ Id = 5, Name = "5"},
                        new DrinkOrderNumber{ Id = 6, Name = "6"},
                    }
                }
            };
        }
    }
}
