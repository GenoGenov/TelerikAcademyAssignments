using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public abstract class GatheringLocation:Location,IGatheringLocation
    {
        public GatheringLocation(string name,ItemType gatheredType,ItemType requiredItem, LocationType type) : base(name, type)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = requiredItem;
        }

        public ItemType GatheredType { get; protected set; }

        public ItemType RequiredItem { get; protected set; }

        public abstract Item ProduceItem(string name);
    }
}
