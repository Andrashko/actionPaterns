import promptSync from "prompt-sync";
let prompt = promptSync();

class CashPayment{
    Pay(PaySum){
        let Cash = Number(prompt("Внесіть готівку:"));
        let Change= Cash - PaySum;
        if (Change>0)
        {
            console.log(`Ваша решта ${Change}`);
            return true;
        }
        if (Change==0)
            return true;
        return false;
    }        
}

class CardPayment{
    Pay(PaySum){
        console.log("Оплата каpтою");            
        return true;
    }
}

class Cashbox {
    constructor(){
        this.paymentStrategy = null;
    }

    TakePayment(sum){
        if (this.paymentStrategy && this.paymentStrategy.Pay)
            return this.paymentStrategy.Pay(sum);
        return false;    
    }

    set Strategy (value) {
        this.paymentStrategy = value;
    }
}


export  {Cashbox, CashPayment, CardPayment};