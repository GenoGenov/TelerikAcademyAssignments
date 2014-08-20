namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class AlfreddosPlace : PizzaFactory
    {
        private const string Name = "Alfreddo's Pizza Palace";

        public string TheName
        {
            get
            {
                return Name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("white cheese");
            ingridients.Add("yellow cheese");
            ingridients.Add("blue cheese");
            ingridients.Add("extra smelly cheese");

            var pizza = new CheesePizza(ingridients, this.TheName);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("ham");
            ingridients.Add("bacon");

            var pizza = new Calzone(ingridients, this.TheName);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("pepperoni");
            ingridients.Add("salami");

            var pizza = new PepperoniPizza(ingridients, this.TheName);
            return pizza;
        }
    }
}