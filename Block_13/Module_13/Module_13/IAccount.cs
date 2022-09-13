using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_13
{
    public class Funtic
    {
        public Funtic(int money)
        {
            Money = money;
        }

        public int Money { get; set; }

        public override string ToString()
        {
            return Money.ToString();
        }
    }

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

    public class Deposite : IAccount<Funtic>
    {
        public Deposite()
        {
            Bablo = default;
            isOpen = false;
        }

        public Funtic Bablo { get; private set; }
        public bool isOpen { get; set; }

        public Funtic GetBablo(int amount)
        {
            if (amount > Bablo.Money)
                throw new ArgumentException("Слишком много просишь, нету столько!");

            Bablo.Money -= amount;
            return new Funtic(amount);
        }

        public void SetBablo(Funtic value, int amount) => value.Money += amount;
    }

    public class NotDeposit : IAccount<Funtic>
    {
        public NotDeposit()
        {
            Bablo = default;
            isOpen = false;
        }

        public Funtic Bablo { get; private set; }

        public bool isOpen { get; set; }

        public Funtic GetBablo(int amount)
        {
            if (amount > Bablo.Money)
                throw new ArgumentException("Слишком много просишь, нету столько!");

            Bablo.Money -= amount;
            return new Funtic(amount);
        }

        public void SetBablo(Funtic value, int amount) => value.Money += amount;
    }
}