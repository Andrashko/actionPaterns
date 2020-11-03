using System;

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
        private  Payment paymentStrategy = null;
       
        public void setPaymentStrategy(Payment paymentStrategy){
            this.paymentStrategy = paymentStrategy;
        }   
        public bool TakePayment(double sum)
        {
            if (this.paymentStrategy != null)
                return this.paymentStrategy.Pay(sum);
            return false;
        }
    }
}