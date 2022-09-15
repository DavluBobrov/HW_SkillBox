using System;

namespace Module_13
{
    #region Currency

    public class Funtic
    {
        public Funtic(int money)
        {
            Money = money;
        }

        public Funtic()
        {
            Money = 0;
        }

        public int Money { get; set; }

        public override string ToString()
        {
            return Money.ToString();
        }
    }

    #endregion Currency

    #region Variants Interfaces

    public interface IContrvatiantAccount<in T>
    {
        void SetBablo(T value, int amount);
    }

    public interface ICovariantAccount<out T>
    {
        T GetBablo(int amount);
    }

    public interface IAccount<T> : ICovariantAccount<T>, IContrvatiantAccount<T>
    {
        T Bablo { get; }
        bool isOpen { get; set; }
    }

    #endregion Variants Interfaces

    #region Accounts

    public abstract class Account<T> : IAccount<T>
        where T : Funtic, new()
    {
        protected Account()
        {
            Bablo = new();
            isOpen = false;
        }

        protected Account(T bablo)
        {
            Bablo = bablo;
            isOpen = false;
        }

        public T Bablo { get; protected set; }

        public bool isOpen { get; set; }

        public T GetBablo(int amount)
        {
            if (amount > Bablo.Money)
                throw new ArgumentException("Слишком много просишь, нету столько!");

            Bablo.Money -= amount;
            T t = new();
            t.Money = amount;
            return t;
        }

        public void SetBablo(T value, int amount) => value.Money += amount;
    }

    public class Deposite<T> : Account<T>
        where T : Funtic, new()
    {
        public Deposite() : base()
        {
        }

        public Deposite(T amount) : base(amount)
        {
        }
    }

    public class NotDeposit<T> : Account<T>
        where T : Funtic, new()
    {
        public NotDeposit() : base()
        {
        }

        public NotDeposit(T amount) : base(amount)
        {
        }
    }

    #endregion Accounts
}