using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeAndTravel
{
    public class Armor : Item
    {
        private const int GeneralArmorValue = 5;

        public Armor(string name, Location location = null) : base(name, Armor.GeneralArmorValue, ItemType.Armor, location)
        {
        }

        //private static List<ItemType> GetComposingItems()
        //{
        //    return new List<ItemType>() { ItemType.Iron };
        //}
    }
}