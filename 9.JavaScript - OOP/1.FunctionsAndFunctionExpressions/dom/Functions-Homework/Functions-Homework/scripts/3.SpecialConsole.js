var specialConsole = (function () {
    function stringFormat(format, args) {
        var argindex = 1;
        for (var i in arguments) {
            while (format.indexOf('{' + i + '}') > -1) {
                format = format.replace('{' + i + '}', arguments[argindex]);
            }
            argindex++;
        }

        return format;
    };

    function writeLine(args) {
        if (arguments.length > 1) {
            var arr = [];
            for (var i = 0; i < arguments.length; i++) {
                arr.push(arguments[i].toString());
            }

            console.log(stringFormat.apply(null, arr));
        } else {
            console.log(args.toString());
        }
    };

    return {
        writeLine: writeLine,
        writeError: writeLine,   //??!! that was the requirement ..... at least thats my understanding of it..
        writeWarning: writeLine
    };
}());

specialConsole.writeLine("Message: {0}, {1} !", "hello", "Pesho");
specialConsole.writeLine("Message: hello !");