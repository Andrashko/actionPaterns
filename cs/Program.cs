using System;
using System.Collections.Generic;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {         
           Cashbox cashbox = new Cashbox();
          
           do {
                Console.WriteLine("Введіть суму до оплати або 0 для виходу");
                double sum = Double.Parse(Console.ReadLine());
                if (sum<=0) 
                    break;
                Console.WriteLine("Виберіть статрегію оплати з ");
                foreach (string strategy in cashbox.Strategies)    
                   Console.WriteLine(strategy);
                string selectedStrategy = Console.ReadLine();
                if (cashbox.TakePayment(selectedStrategy, sum))
                    Console.WriteLine("Платіж успішний");
                else
                    Console.WriteLine("Платіж не успішний");    
           }while (true);
        }
    }
}