using System;
using System.Collections.Generic;
namespace cs
{
    interface Payment
    {
        public bool Pay(double PaySum);
    }

    class CashPayment : Payment
    {
        public bool Pay(double PaySum)
        {
            Console.Write("Внесіть готівку:");
            double Cash = Double.Parse(Console.ReadLine());
            double Change = Cash - PaySum;
            if (Change > 0)
            {
                Console.WriteLine(String.Format("Ваша решта {0}", Change));
                return true;
            }
            if (Change == 0)
                return true;
            return false;
        }
    }

    class CardPayment : Payment
    {
        public bool Pay(double PaySum)
        {
            Console.WriteLine("Оплата катою");
            return true;
        }
    }

    class Cashbox
    {
        private Dictionary<string, Payment> paymentStrategies = new Dictionary<string, Payment>();
        public Cashbox()
        {
            paymentStrategies.Add("CASH", new CashPayment());
            paymentStrategies.Add("CARD", new CardPayment());
        }

        public bool TakePayment(string strategy, double sum)
        {
            Payment payment;
            if (paymentStrategies.TryGetValue(strategy, out payment))
            {
                return payment.Pay(sum);
            }
            return false;
        }

        public List<string> Strategies
        {
            get
            {
                List<string> result = new List<string>();
                foreach (string strategy in paymentStrategies.Keys)
                {
                    result.Add(strategy);
                }
                return result;
            }
        }
    }
}