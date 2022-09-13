using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_13
{
    public interface ICovariantClient<out T> where T : IAccount
    {
        T GetAccount(TypeAccount type);
    }

    public interface IContrvariantClient<in T> where T : IAccount
    {
        void SetAccount(int value, T acc);
    }

    public enum TypeAccount
    {
        Deposic, NotDeposit
    }

    public class Client : ICovariantClient<IAccount>
    {
        Deposite deposite = new();
        NotDeposit notDeposit = new();
        public string Name { get; set; }
        

        public IAccount GetAccount(TypeAccount type)
        {
            switch (type)
            {
                case TypeAccount.Deposic:
                    return deposite;
                case TypeAccount.NotDeposit:
                    return notDeposit;
                default:
                    return null;
            }
        }
    }
}