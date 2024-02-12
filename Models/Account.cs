using System;

public class Account
{
    public string AccountId { get; set; }
    public decimal Balance { get; set; }
    public decimal MarginUsed { get; set; }
    public decimal MarginAvailable => Balance - MarginUsed;

    // Method to deposit funds into the account
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive", nameof(amount));
        }
        Balance += amount;
    }

    // Method to withdraw funds from the account
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive", nameof(amount));
        }

        if (amount > MarginAvailable)
        {
            return false; // Insufficient funds
        }

        Balance -= amount;
        return true;
    }
}