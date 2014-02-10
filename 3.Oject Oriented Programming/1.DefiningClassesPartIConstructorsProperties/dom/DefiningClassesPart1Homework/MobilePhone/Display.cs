using System;
using MobilePhone.Enums;

namespace MobilePhone
{
    public class Display
    {
        #region Fields

        private NumberOfColors? numberOfColors;
        private double size;

        #endregion

        #region Properties

        public double Size
        {
            get { return size; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Display size cannot be less than 1");
                }
                size = value;
            }
        }

        public NumberOfColors? NumberOfColors
        {
            get { return numberOfColors; }
            set { numberOfColors = value; }
        }

        #endregion

        #region Constructors

        public Display(NumberOfColors? numberOfColors, double size)
        {
            this.NumberOfColors = numberOfColors;
            this.Size = size;
        }

        public Display()
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("\nDisplayInfo:\nNumber of Colors: {0}\nSize: {1}", this.NumberOfColors, this.Size);
        }

        #endregion
    }
}