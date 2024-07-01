using System;
//using NUnit.Framework;

public class Account
{
    public double Balance { get; private set; }
    public double OverdraftLimit { get; private set; }

    public Account(double overdraftLimit)
    {
        this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
        this.Balance = 0;
    }
    public bool Deposit(double Amount)
    {
        if (Amount > 0)
        {
            this.Balance += Amount;
            return true;
        }
        return false;
    }

    public bool Withdraw(double Amount)
    {
        if (this.Balance - Amount >= -this.OverdraftLimit && Amount > 0)
        {
            this.Balance -= Amount;
            return true;
        }
        return false;
    }
}


/*
[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);
        
        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }
}
*/