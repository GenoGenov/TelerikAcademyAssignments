function getEmailAddresses(input) {
    var regex = /\b\w+[\w\-]*(\.\w+[\w\-]*)*@[a-z0-9]+[a-z0-9-]*(\.[a-z0-9]+[a-z0-9-]*)*(\.[a-z]{2,6})\b/g;

    var matches = [];
    var match;
    while (match = regex.exec(input)) {
        matches.push(match[0]);
    }

    return matches;
}

var str = 'pench0@gmail.com wekjfjkefgkweggwekgf wegewedgre.com fffe@ wefgwefw dd@abv.bg'

var emails = getEmailAddresses(str);

if(emails.length>0){
    console.log(emails);
}else{
    console.log('the text does not contain valid email addresses');
}