using System;
using System.Linq;

namespace Bank
{
    internal interface IWithdrawable
    {
        bool Withdraw(decimal ammount);
    }
}