using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BitArray
{
    public class BitArray64 : IEnumerable<int>
    {
        #region Fields
        
        private const int BITS_COUNT = 64;
        
        private ulong bits;
        
        #endregion
        
        #region Constructors
        
        public BitArray64()
        {
            this.bits = 0;
        }
        
        #endregion
        
        #region Properties
        
        public int Length
        {
            get
            {
                return BITS_COUNT;
            }
        }
        
        #endregion
        
        #region Indexer
        
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < BITS_COUNT)
                {
                    ulong mask = (ulong)1 << index;
                    
                    if ((this.bits & mask) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                }
            }
            
            set
            {
                if (index < 0 || index >= BITS_COUNT)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                }
                
                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("Value must be 0 or 1.");
                }
                
                ulong mask = (ulong)1 << index;
                
                if (value == 1)
                {
                    this.bits |= mask;
                }
                else
                {
                    this.bits &= ~mask;
                }
            }
        }
        
        #endregion
        
        #region Overrides
        
        public override string ToString()
        {
            return Convert.ToString((long)this.bits, 2).PadLeft(64, '0');
        }
        
        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;
            
            if (other == null)
            {
                return false;
            }
            
            return this.bits == other.bits;
        }
        
        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }
        
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < BITS_COUNT; i++)
            {
                yield return this[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<int>).GetEnumerator();
        }
        
        #endregion
        
        #region Operators
        
        public static bool operator ==(BitArray64 arrayA, BitArray64 arrayB)
        {
            return BitArray64.Equals(arrayA, arrayB);
        }
        
        public static bool operator !=(BitArray64 arrayA, BitArray64 arrayB)
        {
            return !(BitArray64.Equals(arrayA, arrayB));
        }
    
        #endregion
    }
}