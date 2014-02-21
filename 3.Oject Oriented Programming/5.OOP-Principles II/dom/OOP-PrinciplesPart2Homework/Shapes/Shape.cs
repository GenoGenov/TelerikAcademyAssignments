using System;
using System.Linq;

namespace Shapes
{
    public abstract class Shape
    {
        #region Fields
        
        protected double height;
        protected double width;
        
        #endregion
        
        #region Constructors
        
        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        
        #endregion

        #region Properties
        
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
                    throw new ArgumentException("Width or Height can not be less than or equal to zero");
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
                    throw new ArgumentException("Width or Height can not be less than or equal to zero");
                }
                this.height = value;
            }
        }
        
        #endregion

        public abstract double CalculateSurface();
    }
}