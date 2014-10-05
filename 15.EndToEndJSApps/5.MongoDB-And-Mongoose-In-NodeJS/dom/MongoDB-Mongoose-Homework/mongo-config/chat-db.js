var mongoose = require('mongoose');

var User = require('../models/users');
var Message = require('../models/messages');

var connectionStr = 'localhost:27017/Chat';
mongoose.connect(connectionStr);
var db = mongoose.connection;

db.once('open', function () {
    console.log('MongoDB connected to ' + connectionStr);
});

db.on('error', function (err) {
    console.log(err);
});

module.exports = {
    registerUser: function (obj, callback) {
        var user = new User();
        user.username = obj.user;
        user.password = obj.pass;
        user.save(function (err, data) {
            if (err) {
                console.log(err);
            } else {
                if (callback) {
                    callback(data);
                }
                console.log(data.username + ' registered successfully!');
            }

        });
    },
    sendMessage: function (msg, callback) {
        var message = new Message();

        User.findOne({username: msg.from}).exec(function (err, fromUsr) {
            if (err) {
                console.log(err);
            } else {
                message.from = fromUsr;
                User.findOne({username: msg.to}).exec(function (err, toUsr) {
                    if (err) {
                        console.log(err);
                    } else {
                        message.to = toUsr;
                        message.text = msg.text;

                        message.save(function (err, data) {
                            if (err) {
                                console.log(err);
                            } else {
                                console.log(msg.from + ' sent message to ' + msg.to + ' (' + msg.text + ')');
                                if (callback) {
                                    callback(data);
                                }

                            }
                        });
                    }
                });

            }
        });


    },
    getMessages: function (options, callback) {
        User.getByName(options.with, function (first) {
            User.getByName(options.and, function (second) {

                Message.find()
                    .or([
                        {from: first.id, to: second.id},
                        {from: second.id, to: first.id}
                    ]).exec(function (err, data) {
                        if(err){
                            callback(err);
                        }
                        if (callback) {
                            var result = [];
                            for (var i = 0; i < data.length; i++) {
                                var msgModel = {};
                                msgModel.from = data[0].from == first.id ? first.username : second.username;
                                msgModel.to=data[0].to==first.id?first.username:second.username;
                                msgModel.text=data[0].text;
                                result.push(msgModel);
                            }
                            callback(null,result);
                        }
                    });
            })
        });

    }

}