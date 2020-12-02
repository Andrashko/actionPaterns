class Originator {
    constructor(state) {
        this._state = state;
        console.log("Originator: My initial state is: " + state);
    }
    DoSomething() {
        console.log("Originator: I'm doing something important.");
        this._state = this.GenerateRandomString(30);
        console.log(`Originator: and my state has changed to: ${this._state}`);
    }

    GenerateRandomString(length = 10) {

        function IntRandom(from = 0, to = 10) {
            return Math.ceil((to - from) * Math.random() + from);
        }

        let allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        let result = "";

        while (length > 0) {
            result += allowedSymbols[IntRandom(0, allowedSymbols.length)];
            length--;
        }

        return result;
    }

    Save(){
        return new ConcreteMemento(this._state);
    }

    Restore (memento){
        if (memento && memento.State){
            this._state = memento.State;
            console.log(`Originator: My state has changed to: ${this._state}"`);
        }
        else
            throw "Unknown memento " + memento;
    }
}

class ConcreteMemento {
    constructor(state) {
        this._state = state;
        this._date = Date.now();
    }

    toString() {
        if (this._state.length <= 10)
            return `${this._date} / ${this._state}`;
        else
            return `${this._date} / ${this._state.substring(0, 9)}`;
    }

    get State(){
        return this._state;
    }
}

class Caretaker {
    constructor(originator) {
        this._originator = originator;
        this._mementos = [];
    }
    Backup() {
        console.log("\nCaretaker: Saving Originator's state...");
        this._mementos.push(this._originator.Save());
    } 
    Undo()
    {
        if (this._mementos.length == 0)
        {
            console.log("Caretaker: Tere is no history to undo");
            return;
        }

        var memento = this._mementos.pop();

        console.log("Caretaker: Restoring state to: " + memento);

        this._originator.Restore(memento);
    }
    ShowHistory()
        {
            console.log("Caretaker: Here's the list of mementos:");

            for (let memento of this._mementos)
            {
                console.log(memento);
            }
        }
}

export {Originator, Caretaker};
