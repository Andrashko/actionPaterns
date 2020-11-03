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

class CashboxWithState {
    constructor(){
        this.paymentStates = {
            "CASH": new CashPayment(),
            "CARD": new CardPayment(),
        }
        this.state = "CASH";
    }
    
    get States () {
        return Object.getOwnPropertyNames(this.paymentStates); 
    }

    set State(value){
        if (this.States.indexOf(value)>-1)
            this.state=value;
        else
            throw "Unknown state";
    }

    TakePayment(sum){
        if (this.paymentStates[this.state])
            return this.paymentStates[this.state].Pay(sum);
        return false;    
    }

    
}


export default CashboxWithState;