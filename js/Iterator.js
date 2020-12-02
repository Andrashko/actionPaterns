class AlphabeticalOrderIterator{
    constructor(collection, reverse = false){
        this._collection = collection;
        this._collection.sort();
        if (reverse)
            this._collection.reverse();
        this._index = -1;
    }

    [Symbol.iterator](){
        return this;
    }

    next (){
        if (this._index === -1){
            this._index = 0;
        }
    
        if (this._index <  this._collection.length)
        {
            return  {
                done: false,
                value: this._collection[this._index++]
            }
        }
        else{
            this._index = -1;
            return {
                done: true
            }
        }
    }
}

function* AlphabeticalOrderGenerator(collection, reverse = false) {
    let _collection = collection.slice();
    _collection.sort();
    if (reverse)
        _collection.reverse();
    let _index = 0;
    while (_index< _collection.length)
        yield _collection[_index++];
}

export {AlphabeticalOrderIterator, AlphabeticalOrderGenerator};