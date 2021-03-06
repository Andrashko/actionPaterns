﻿using System;
using System.Collections.Generic;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTemplate();
        }

        static void TestTemplate(){
            Console.WriteLine("Same client code can work with different subclasses:");

            Client2.ClientCode(new ConcreteClass1());

            Console.Write("\n");
            
            Console.WriteLine("Same client code can work with different subclasses:");
            Client2.ClientCode(new ConcreteClass2());
        }
        static void TestCommand(){
    
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
    
        }
        static void TestMediator(){
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggets operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }

    //     static void TestMemento(){
    //         Originator originator = new Originator("Init state");
    //         Caretaker caretaker = new Caretaker(originator);

    //         caretaker.Backup();
    //         originator.DoSomething();

    //         caretaker.Backup();
    //         originator.DoSomething();

    //         caretaker.Backup();
    //         originator.DoSomething();

    //         Console.WriteLine();
    //         caretaker.ShowHistory();

    //         Console.WriteLine("\nClient: Now, let's rollback!\n");
    //         caretaker.Undo();

    //         Console.WriteLine("\n\nClient: Once more!\n");
    //         caretaker.Undo();

    //         Console.WriteLine("\n\nClient: Once more!\n");
    //         caretaker.Undo();

    //         Console.WriteLine("\n\nClient: Once more!\n");
    //         caretaker.Undo();

    //         Console.WriteLine();
    //     }
    //     static void TestVisitor()
    //     {
    //         List<IComponent> components = new List<IComponent>
    //         {
    //             new ConcreteComponentA(),
    //             new ConcreteComponentB()
    //         };

    //         Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
    //         var visitor1 = new ConcreteVisitor1();
    //         Client.ClientCode(components, visitor1);

    //         Console.WriteLine();

    //         Console.WriteLine("It allows the same client code to work with different types of visitors:");
    //         var visitor2 = new ConcreteVisitor2();
    //         Client.ClientCode(components, visitor2);
            
    //         //-------------------------------------------
    //         ex.Student s = new ex.Student("Іванов", "Іван",2);
    //         ex.Printer printer = new ex.Printer();
    //         s.Accept(printer);  
    //         s.Accept(new ex.Hi()); 
    //     }
    //     static void TestIterator()
    //     {
    //         var collection = new WordsCollection();
    //         collection.AddItem("First");
    //         collection.AddItem("Second");
    //         collection.AddItem("Third");

    //         Console.WriteLine("Straight traversal:");

    //         foreach (var element in collection)
    //         {
    //             Console.WriteLine(element);
    //         }

    //         Console.WriteLine("\nReverse traversal:");

    //         collection.ReverseDirection();

    //         foreach (var element in collection)
    //         {
    //             Console.WriteLine(element);
    //         }
    //     }
    //     private static void TestChain()
    //     {
    //         var Chain = new LogHendler();
    //         Chain.SetNext(new AuthorizeHendler()).SetNext(new ResponceHendler());
    //         Console.WriteLine(Chain.Handle(new Request("admin", "admin")));
    //         Console.WriteLine(Chain.Handle(new Request("Noname", "No")));
    //     }
    //     private static void EventTest()
    //     {
    //         var subject = new EventSubject();
    //         var less5 = new EventLessFiveObserver();
    //         var even = new EventEvenObserver();
    //         subject.Attach(even);
    //         subject.Attach(less5);
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //     }

    //     private static void StateTest()
    //     {
    //         CashboxWithState cashbox = new CashboxWithState();
    //         while (true)
    //         {
    //             Console.WriteLine("Введіть суму до оплати або 0 для виходу");
    //             double sum = Double.Parse(Console.ReadLine());
    //             if (sum <= 0)
    //                 break;
    //             Console.WriteLine("Виберіть статрегію оплати:");
    //             foreach (string state in cashbox.States)
    //                 Console.WriteLine(state);
    //             cashbox.State = Console.ReadLine();
    //             if (cashbox.TakePayment(sum))
    //                 Console.WriteLine("Платіж успішний");
    //             else
    //                 Console.WriteLine("Платіж не успішний");
    //         }
    //     }
    //     private static void ObserverTest()
    //     {
    //         var subject = new Subject();
    //         var lessFive = new LessFiveObserver();
    //         var even = new EvenObserver();
    //         subject.Attach(lessFive);
    //         subject.Attach(even);
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.Detach(even);
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //         subject.RandomState();
    //     }
    //     public static void StrategyTest()
    //     {
    //         Cashbox cashbox = new Cashbox();
    //         List<Payment> strategies = new List<Payment>(2) { new CashPayment(), new CardPayment() };

    //         while (true)
    //         {
    //             Console.WriteLine("Введіть суму до оплати або 0 для виходу");
    //             double sum = Double.Parse(Console.ReadLine());
    //             if (sum <= 0)
    //                 break;
    //             Console.WriteLine("Виберіть статрегію оплати \n 1. Готівкою \n 2. Картою");
    //             int strategyIndex = Int32.Parse(Console.ReadLine()) - 1;
    //             cashbox.setPaymentStrategy(strategies[strategyIndex]);
    //             if (cashbox.TakePayment(sum))
    //                 Console.WriteLine("Платіж успішний");
    //             else
    //                 Console.WriteLine("Платіж не успішний");
    //         }

    //     }
     }
}