using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Mine:GatheringLocation
    {
        public Mine(string name) : base(name, ItemType.Iron, ItemType.Armor, LocationType.Mine)
        {
        }

        public override Item ProduceItem(string name)
        {
            return new Iron(name);
        }
    }
}
