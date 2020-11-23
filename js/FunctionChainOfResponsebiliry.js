function HadnlerFunction(error, request, next = this._next) {
    try {
        console.log(arguments);
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
        console.log(arguments);
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
        console.log(arguments);
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
    constructor (handler){
        this = handler || HadnlerFunction;
        this._next = null;
    }

   
    Use (HadnlerFunction){
        HadnlerFunction._next = this._next;
        this._next = HadnlerFunction;
    }

    Handle(request){
        this()
    }
}

export {Chain, LogHandlerFunction, AuthorizeHandlerFunction}