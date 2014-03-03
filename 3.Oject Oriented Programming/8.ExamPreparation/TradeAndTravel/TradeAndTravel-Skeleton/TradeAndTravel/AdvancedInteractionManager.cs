using System;
using System.Linq;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor":
                    item = new Armor(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString,itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString,itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString,itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    location = new Town(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
            
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            switch (commandWords[2])
            {
                case "armor":
                    if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron))
                    {
                        this.AddToPerson(actor, new Armor(commandWords[3]));
                    }
                    break;
                case "weapon":
                    if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron))
                    {
                        if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Wood))
                        {
                            this.AddToPerson(actor, new Weapon(commandWords[3]));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            var location = actor.Location as IGatheringLocation;
            if(location!=null)
            {
                if(actor.ListInventory().Exists(x=>x.ItemType==location.RequiredItem))
                {
                    this.AddToPerson(actor, location.ProduceItem(commandWords[2]));
                }
            }
        }
    }
}