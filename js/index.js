import Cashbox from "./Strategy";
import promptSync from "prompt-sync";
let prompt = promptSync();

let cashbox = new Cashbox();
do {
    let sum = Number(prompt("Введіть суму до оплати або 0 для виходу:"));
    if (sum<=0) 
        break;
    let  selectedStrategy = prompt("Виберіть статрегію оплати з "+ cashbox.Strategies.join(",")+":");
    if (cashbox.TakePayment(selectedStrategy, sum))
        console.log("Платіж успішний");
    else
        console.log("Платіж не успішний");    
}while (true);