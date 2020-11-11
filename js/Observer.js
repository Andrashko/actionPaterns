class Subject
{
    constructor(){
        this.State = 0;
        this._observers = [];
    }
    Attach(observer){
        this._observers.push(observer);
    }

    Detach(observer){
        this._observers = this._observers.filter(o => o !== observer);
    }

    Notyfy(){
        this._observers.forEach(observer => observer.Update(this));
    }

    RandomState(){
        this.State = Math.floor(Math.random()*10);
        console.log(`New state ${this.State}`);
        this.Notyfy();
    }
}

class LessFiveObserver {
    Update (subject){
        if (subject.State<5){
            console.log("state < 5");
        }
    }
}

class EvenObserver{
    Update(subject)
    {            
        if (subject.State % 2 == 0)
        {
            console.log("State is even");
        }
    }
}

export {Subject, LessFiveObserver, EvenObserver};