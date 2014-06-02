namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public void Cook()
        {
            
        }
        private static void Main(string[] args)
        {
        }

        public class Chef
        {
            public void Cook()
            {
                var vegetables = this.GetVegetables();
                
                this.PrepareVegetablesForCooking(vegetables);

                Bowl bowl = this.GetBowl();
                bowl.Add(vegetables);
            }

            private void PrepareVegetablesForCooking(List<Vegetable> vegetables)
            {
                foreach (var vegetable in vegetables)
                {
                    this.Peel(vegetable);
                    this.Cut(vegetable);
                }
            }

            private List<Vegetable> GetVegetables()
            {
                Potato potato = this.GetPotato();
                Carrot carrot = this.GetCarrot();
                var result = new List<Vegetable>();
                result.Add(potato);
                result.Add(carrot);
                return result;
            }
 
            private void Peel(Vegetable vegetable)
            {
                // TODO: Implement this method
                throw new NotImplementedException();
            }

            private Bowl GetBowl()
            { 
                return new Bowl();
            }

            private Carrot GetCarrot()
            {
                return new Carrot();
            }

            private void Cut(Vegetable potato)
            {
                // ...
            }

            private Potato GetPotato()
            {
                return new Potato();
            }
        }
    }
}