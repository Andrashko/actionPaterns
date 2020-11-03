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
        this.paymentStrategies = {
            "CASH": new CashPayment(),
            "CARD": new CardPayment(),
        }
    }

    TakePayment(strategy, sum){
        if (this.paymentStrategies[strategy])
            return this.paymentStrategies[strategy].Pay(sum);
        return false;    
    }

    get Strategies () {
        return Object.getOwnPropertyNames(this.paymentStrategies); 
    }
}


export default Cashbox;