var chatDb=require('./mongo-config/chat-db');

chatDb.registerUser({user:'Ehee',pass:'12345'}, function () {
    chatDb.registerUser({user:'Ohoo',pass:'12345'}, function () {
        chatDb.sendMessage({from:'Ehee',to:'Ohoo',text:'wef2ew'}, function () {
            chatDb.getMessages({with:'Ehee',and:'Ohoo'}, function (err, data) {
                console.log('All Messages:');
                console.log(data);
            });
        });
    });
});

