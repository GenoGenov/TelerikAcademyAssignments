using System;
using System.Linq;

namespace Bank
{
    internal interface IDepositable
    {
        void MakeDeposit(decimal ammount);
    }
}