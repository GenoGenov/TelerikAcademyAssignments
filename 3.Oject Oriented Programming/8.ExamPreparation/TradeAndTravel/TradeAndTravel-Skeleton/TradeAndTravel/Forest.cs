using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class Forest:GatheringLocation
    {
        public Forest(string name) : base(name, ItemType.Wood, ItemType.Weapon, LocationType.Forest)
        {
        }

        public override Item ProduceItem(string name)
        {
            return new Wood(name);
        }
    }
}
