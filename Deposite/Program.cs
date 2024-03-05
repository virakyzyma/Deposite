using System;

namespace Deposite
{
    internal class Program
    {
        static void Main()
        {
            Deposit deposit = new Deposit()
            {
                FullName = "Joe",
                DepositAmount = 10_000,
                DepositDate = DateTime.Now,
                Rate = 7,
                TermMonths = 12
            };
            Console.WriteLine(deposit.GetInfo());
            Console.WriteLine($"Amount after closing your deposit: {deposit.CloseDeposit(6)}");
        }
    }
    public class Deposit
    {
        private static int idCounter = 0;
        protected int id;
        public Deposit()
        {
            id = ++idCounter;
        }
        public int Id { get { return id; } }
        public string FullName { get; set; }
        protected decimal depositAmount;
        public virtual decimal DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = (value >= 10_000 && value <= 200_000) ? value : throw new Exception("Invalid Deposit Amount"); }
        }
        public decimal Rate { get; set; }
        protected int termMonths;
        public virtual int TermMonths
        {
            get { return termMonths; }
            set { termMonths = (value >= 3 && value <= 36) ? value : throw new Exception("Invalid Term Months"); }
        }
        public DateTime DepositDate { get; set; }
        public virtual string GetInfo()
        {
            return $"""
                Id - {Id}
                FullName - {FullName}
                DepositAmount - {DepositAmount}
                TermMonths - {TermMonths}
                DepositDate - {DepositDate}
                """;
        }
        public virtual decimal CloseDeposit(int passedMonths)
        {
            decimal amount = DepositAmount * (1 + Rate / 100) * passedMonths / 12;
            return amount;
        }
    }
    public class Credit : Deposit
    {
        public override decimal DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = (value >= 1000 && value <= 500_000) ? value : throw new Exception("Invalid Deposit Amount"); }
        }
        public override int TermMonths
        {
            get { return termMonths; }
            set { termMonths = (value >= 1 && value <= 42) ? value : throw new Exception("Invalid Term Months"); }
        }
        public override decimal CloseDeposit(int passedMonths)
        {
            decimal amount = DepositAmount * (1 + Rate / 100) * passedMonths / 12;
            return amount;
        }
    }
}