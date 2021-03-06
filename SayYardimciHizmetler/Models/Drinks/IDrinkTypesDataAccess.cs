﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public interface IDrinkTypesDataAccess
    {
        List<DrinkType> GetAllColdDrinks();
        List<DrinkType> GetAllHotDrinks();
        List<DrinkType> GetAllMeetingRoomDrinks();
    }
}
