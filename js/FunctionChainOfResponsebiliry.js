function HadnlerFunction(error, request, next) {
    try {
        if (error) {
            console.error(error);
            throw error;
        }
        if (next)
            return next(null, request);
        else
            return null;
    } catch (e) {
        if (next)
            return next(e, request);
        else
            return null;
    }
}

function LogHandlerFunction(error, request, next) {
    try {
        if (error) {
            console.error(error);
            throw error;
        }
        console.log(`Log\n ${JSON.stringify(request)}`);
        if (next)
            return next(null, request);
        else
            return null;
    } catch (e) {
        if (next)
            return next(e, request);
        else
            return null;
    }
}
function AuthorizeHandlerFunction(error, request, next) {
    function Check(Login, Password) {
        return Login == "admin" && Password == "admin";
    }
    try {
        if (error) {
            console.error(error);
            throw error;
        }
        console.log("Authorize");
        if (request.Login && request.Password) {
            if (Check(request.Login, request.Password)) {
                if (next)
                    return next(null, request);
                else
                    return null;
            }
            else {
                console.log("Wrong login or password");
                return null;
            }
        }
        else {
            console.log("Bed request");
            return null;
        }
    } catch (e) {
        if (next)
            return next(e, request);
        else
            return null;
    }
}

class Chain{
    constructor (handler, next){
        this._handler = handler || HadnlerFunction;
        this._next = next || null;
    }

    Use (HadnlerFunction){
        console.log("use");
        console.log(this);
        this._next = new Chain(HadnlerFunction,  this._next);
        console.log(this);
        return this;
    }

    Handle(request){
        return this._handler(null, request, this._next);
    }
}

export {Chain, LogHandlerFunction, AuthorizeHandlerFunction}