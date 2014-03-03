using System;
using System.Linq;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int InitialWoodValue = 2;

        public Wood(string name, Location location = null) : base(name, Wood.InitialWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop")
            {
                if (this.Value > 0)
                {
                    this.Value--;
                }
            }
            
            base.UpdateWithInteraction(interaction);
        }
    }
}