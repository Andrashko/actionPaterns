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

import  CashboxWithState from "./State";
import promptSync from "prompt-sync";
let prompt = promptSync();

let cashbox = new CashboxWithState();
while (true) {
    let sum = Number(prompt("Введіть суму до оплати або 0 для виходу:"));
    if (sum<=0) 
        break;
    cashbox.State = prompt("Виберіть статрегію оплати\n" + cashbox.States.join("\n")+"\n");
    if (cashbox.TakePayment(sum))
        console.log("Платіж успішний");
    else
        console.log("Платіж не успішний");    
}