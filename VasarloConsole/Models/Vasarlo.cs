using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasarloConsole.Models
{
    public class Vasarlo
    {
        private string _name;
        private string _email;
        private double _balance;
        private int _increases = 0;

        public Vasarlo(string name, string email, double balance)
        {
            if(balance<0)
            {
                throw new NegativeBalanceException("Az összeg nem lehet negatív");
            }
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Az email cím nem megfelelő");
            }
            _name = name;
            _email = email;
            _balance = balance;
        }

        public Vasarlo(string email, double balance)
        {
            if (balance < 0)
            {
                throw new NegativeBalanceException("Az összeg nem lehet negatív");
            }
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Az email cím nem megfelelő");
            }
            _email = email;
            _balance = balance;
        }

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; }
        public double Balance { get => _balance; }
        public int Increases { get => _increases; }
        public bool CanSpend => _balance > 0;


        public bool CanBuy(double amount)
        {
            if(CanSpend)
            {
                if (amount > _balance)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void Increase(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                _increases++;
            }
            else
            {
                throw new ArgumentException("Az összeg nem lehet negatív vagy 0");
            }
        }

        public void SpendMoney(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Az összeg nem lehet negatív vagy 0");
            }

            if (CanBuy(amount))
            {
                _balance -= amount;
            }
            else
            {
                throw new ArgumentException("Nincs elég pénz a vásárláshoz");
            }
        }

        public override string ToString()
        {
            return $"{_name} ({_email}) -> {_balance} Ft";
        }
    }
}
