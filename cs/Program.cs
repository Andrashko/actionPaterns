using System;
using System.Collections.Generic;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {     
            var subject = new EventSubject();
            var less5 = new EventLessFiveObserver();
            var even = new EventEvenObserver();
            subject.Attach(even);
            subject.Attach(less5);
            subject.RandomState();
            subject.RandomState();
            subject.RandomState();
            subject.RandomState();
            subject.RandomState();
        }

        private static void All(){
            // var subject = new Subject();
            // var lessFive = new LessFiveObserver();
            // var even = new EvenObserver();
            // subject.Attach(lessFive);
            // subject.Attach(even);
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
            // subject.Detach(even);
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
            // subject.RandomState();
                
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

            // CashboxWithState cashbox = new CashboxWithState();
            // while (true) {
            //     Console.WriteLine("Введіть суму до оплати або 0 для виходу");
            //     double sum = Double.Parse(Console.ReadLine());
            //     if (sum<=0) 
            //         break;
            //     Console.WriteLine("Виберіть статрегію оплати:");
            //     foreach(string state in cashbox.States)
            //         Console.WriteLine(state);
            //     cashbox.State = Console.ReadLine();
            //     if (cashbox.TakePayment(sum))
            //         Console.WriteLine("Платіж успішний");
            //     else
            //         Console.WriteLine("Платіж не успішний"); 
            // }           

        }
    }
}