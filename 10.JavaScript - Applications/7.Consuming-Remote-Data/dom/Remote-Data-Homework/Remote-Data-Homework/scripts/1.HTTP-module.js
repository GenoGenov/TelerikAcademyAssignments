var httpWorker = (function() {

    var getHttpRequest = (function() {
        var xmlHttpFactories;
        xmlHttpFactories = [
            function() {
                return new XMLHttpRequest();
            },
            function() {
                return new ActiveXObject("Msxml3.XMLHTTP");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP");
            },
            function() {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function() {
            var xmlFactory, i, len;
            for (i = 0, len = xmlHttpFactories.length; i < len; i++) {
                xmlFactory = xmlHttpFactories[i];
                try {
                    return xmlFactory();
                } catch (error) {

                }
            }
            return null;
        };
    })();

    var makeRequest = function(options) {
        var httpRequest = getHttpRequest();
        options = options || {};

        var requestUrl = options.url;

        httpRequest.onreadystatechange = function() {
            if (httpRequest.readyState === 4) {
                switch (Math.floor(httpRequest.status / 100)) {
                case 2:
                    options.success(httpRequest.responseText);
                    break;
                default:
                    options.error(httpRequest.responseText);
                    break;
                }
            }
        };
        httpRequest.open(options.type, requestUrl, true);
        if (options.headers) {
            for (var prop in options.headers) {
                if (options.headers.hasOwnProperty(prop)) {
                    httpRequest.setRequestHeader(prop, options.headers[prop]);
                }

            }
        }


        return httpRequest.send(options.data);
    };

    var jsonRequest = function (type, url, options) {
        options = options || {};
        options.headers = options.headers || {};
        if (options.headers.hasOwnProperty('type')) {
            delete options.headers.type;
        }
        options.headers['Content-Type'] = 'application/json';
        options.headers['Accept'] = 'application/json';

        return makeRequest({
            url: url,
            data: options.data || null,
            success: options.success ||
                function (data) {
                    if (options.display) {
                        var obj = JSON.parse(data);
                        var info = document.createElement('ul');
                        info.innerHTML += '<h1> Displaying info for a ' + type + ' request to url ' + url+'</h1>';
                        for (var prop in obj) {
                            info.innerHTML += '<li>' + prop + ': ' + obj[prop] + '</li>';
                        }
                        options.display.appendChild(info);
                    } },
            error: options.error ||
                function(error) {
                    if (options.display) {
                        var obj = JSON.parse(error);
                        var info = document.createElement('ul');
                        info.innerHTML += '<h1> Displaying info for a ' + type + ' request to url ' + url+'</h1>';
                        for (var prop in obj) {
                            info.innerHTML += '<li>' + prop + ': ' + obj[prop] + '</li>';
                        }
                        options.display.appendChild(info);
                    }
                        
                },
            type: type,
            headers: options.headers
        });
    };
    return {
        postJSON: function (url, options) {
            options = options || {};
            return jsonRequest('POST', url, options);

        },
        getJSON: function (url, options) {
            options = options || {};
            return jsonRequest('GET', url, options);

        }
    };
}());