using System;
using System.Collections.Generic;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {         
        //    Cashbox cashbox = new Cashbox();
        //    List<Payment> strategies = new List<Payment>(2) {new CashPayment(), new CardPayment() };
                    
        //    while (true) {
        //         Console.WriteLine("Введіть суму до оплати або 0 для виходу");
        //         double sum = Double.Parse(Console.ReadLine());
        //         if (sum<=0) 
        //             break;
        //         Console.WriteLine("Виберіть статрегію оплати \n 1. Готівкою \n 2. Картою");
        //         int strategyIndex = Int32.Parse( Console.ReadLine()) - 1;
        //         cashbox.setPaymentStrategy(strategies[strategyIndex]);
        //         if (cashbox.TakePayment(sum))
        //             Console.WriteLine("Платіж успішний");
        //         else
        //             Console.WriteLine("Платіж не успішний");    
        //    } 

            CashboxWithState cashbox = new CashboxWithState();
            while (true) {
                Console.WriteLine("Введіть суму до оплати або 0 для виходу");
                double sum = Double.Parse(Console.ReadLine());
                if (sum<=0) 
                    break;
                Console.WriteLine("Виберіть статрегію оплати:");
                foreach(string state in cashbox.States)
                    Console.WriteLine(state);
                cashbox.State = Console.ReadLine();
                if (cashbox.TakePayment(sum))
                    Console.WriteLine("Платіж успішний");
                else
                    Console.WriteLine("Платіж не успішний"); 
            }
        }
    }
}