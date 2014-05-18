function getUrlData(url) {
    var protocolPart = /^(?:([a-z]+):\/\/)?/;
    var serverPart = /([\w\.\-]+)/;
    var resourcePart = /([\w\.#=&\+\-%\/\?]+)?$/;

    var pattern = new RegExp(protocolPart.source + serverPart.source + resourcePart.source);

    var match = url.match(pattern);

    return {
        protocol: match[1],
        server: match[2],
        resource: match[3]
    };
}

var str = 'http://www.devbg.org/forum/index.php';

console.log(getUrlData(str));