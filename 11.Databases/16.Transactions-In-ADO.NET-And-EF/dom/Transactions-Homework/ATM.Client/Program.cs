namespace ATM.Client
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Transactions;

    using ATM.Data;
    using ATM.Model;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new ATMData();
            db.SaveChanges();
            var entry = db.CardAccounts.All().First();
            var moneyFromATM = PayMoney(entry.Cardnumber, entry.CardPIN, 1000);
        }

        private static void SaveTranToLog(string cardNumber, decimal oldAmount, decimal newAmount)
        {
            using (var db=new ATMData())
            {
                using (var tranScope = new TransactionScope(TransactionScopeOption.Required,new TransactionOptions(){IsolationLevel = IsolationLevel.RepeatableRead}))
                {
                    db.WithdrawalLogs.Add(
                        new WithdrawalLog
                            {
                                CardNumber = cardNumber,
                                NewBalance = newAmount,
                                OldBalance = oldAmount
                            });
                    db.SaveChanges();
                    tranScope.Complete();
                }
            }
        }

        private static decimal PayMoney(string cardNumber, string cardPin, decimal amount)
        {
            var db = new ATMData();
            decimal result = 0;
            using (var tranScope = new TransactionScope(TransactionScopeOption.Required,new TransactionOptions(){IsolationLevel = IsolationLevel.RepeatableRead}))
            {
                
                using (db)
                {
                    Console.WriteLine("Transaction started");
                    try
                    {
                        var account = db.CardAccounts.Find(cardNumber);
                        if (account.CardPIN != cardPin)
                        {
                            throw new InvalidOperationException("The PIN provided was not correct !");
                        }
                        account.CardCash -= amount; //The validation is in the ATMEntities class !!!
                        db.SaveChanges();
                        SaveTranToLog(cardNumber, account.CardCash + amount, account.CardCash);
                        tranScope.Complete();
                        result = amount;
                        Console.WriteLine(
                            "The withdrawal from account {0} was successful. Transfered sum: {1}",
                            cardNumber,
                            amount);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something went wrong during the transaction: {0}", e.Message);
                    }
                    Console.WriteLine("Transaction terminated");
                    return result;
                }
            }
        }
    }
}