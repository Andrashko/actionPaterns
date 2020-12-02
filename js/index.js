function TestMemento() {
    import { Originator, Caretaker } from "./Memento";
    let originator = new Originator("Init state");
    let caretaker = new Caretaker(originator);

    caretaker.Backup();
    originator.DoSomething();

    caretaker.Backup();
    originator.DoSomething();

    caretaker.Backup();
    originator.DoSomething();

    console.log();
    caretaker.ShowHistory();

    console.log("\nClient: Now, let's rollback!\n");
    caretaker.Undo();

    console.log("\n\nClient: Once more!\n");
    caretaker.Undo();

    console.log("\n\nClient: Once more!\n");
    caretaker.Undo();

    console.log("\n\nClient: Once more!\n");
    caretaker.Undo();
}


// import {LogHandler, AuthorizeHandler, ResponceHandler} from "./ChainOfResposebility";
// let chain = new LogHandler();
// chain.SetNext(new AuthorizeHandler()).SetNext(new ResponceHandler());
// console.log(chain.Handle({Login:"admin", Password:"admin"}));
// console.log(chain.Handle({Login:"Noname", Password:"No"}));

// import {Chain, LogHandlerFunction, AuthorizeHandlerFunction} from "./FunctionChainOfResponsebiliry";
// let chain = new Chain();
// chain.Use(LogHandlerFunction).Use(AuthorizeHandlerFunction);
// console.log(chain);
// console.log(chain.Handle({Login:"admin", Password:"admin"}));
// import {Subject, LessFiveObserver, EvenObserver} from "./Observer";

// let subject = new Subject();
// let less5 = new LessFiveObserver();
// let even = new EvenObserver();
// subject.Attach(less5);
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

// import  {Cashbox, CashPayment, CardPayment} from "./Strategy";
// import promptSync from "prompt-sync";
// let prompt = promptSync();

// const strategies = [new CashPayment() , new CardPayment()];
// let cashbox = new Cashbox();
// while (true) {
//     let sum = parseFloat(prompt("Введіть суму до оплати або 0 для виходу:"));
//     if (sum<=0) 
//         break;
//     let  selectedStrategyIndex = parseInt(prompt("Виберіть статрегію оплати \n 1. Готівкою \n 2. Картою\n")) - 1 ;
//     cashbox.Strategy = strategies[selectedStrategyIndex];
//     if (cashbox.TakePayment(sum))
//         console.log("Платіж успішний");
//     else
//         console.log("Платіж не успішний");    
// }

// import  CashboxWithState from "./State";
// import promptSync from "prompt-sync";
// let prompt = promptSync();

// let cashbox = new CashboxWithState();
// while (true) {
//     let sum = Number(prompt("Введіть суму до оплати або 0 для виходу:"));
//     if (sum<=0) 
//         break;
//     cashbox.State = prompt("Виберіть статрегію оплати\n" + cashbox.States.join("\n")+"\n");
//     if (cashbox.TakePayment(sum))
//         console.log("Платіж успішний");
//     else
//         console.log("Платіж не успішний");    
// }