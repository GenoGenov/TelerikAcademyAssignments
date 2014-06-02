namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static Size GetRotatedSize(Size figureSize, double figureAngle)
        {
            var resultWidth = Math.Abs(Math.Cos(figureAngle) * figureSize.Width) +
                              (Math.Abs(Math.Sin(figureAngle)) * figureSize.Height);
            var resultHeight = Math.Abs(Math.Sin(figureAngle) * figureSize.Width) +
                               (Math.Abs(Math.Cos(figureAngle)) * figureSize.Height);

            var result = new Size(resultWidth, resultHeight);
            return result;
        }

        public static void Main(string[] args)
        {
        }

        private class Size
        {
            private double height;
            private double width;

            public Size(double width, double height)
            {
                this.Width = width;
                this.Height = height;
            }

            public double Width
            {
                get
                {
                    return this.width;
                }

                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Width or Height cannot be less or equal to zero!");
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

                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Width or Height cannot be less or equal to zero!");
                    }

                    this.height = value;
                }
            }
        }
    }
}