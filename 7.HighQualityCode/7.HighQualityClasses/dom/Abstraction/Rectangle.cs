namespace Abstraction
{
    using System;

    internal class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height) : base()
        {
            this.Width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width must be bigger than zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height must be bigger than zero!");
                }

                this.height = value;
            }
        }
        
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}