var mongoose = require('mongoose');
var usersSchema = new mongoose.Schema({
    username: {type: String, min: 4,required:true},
    password: {type: String, min: 4,required:true}
});

usersSchema.path('username').validate(function (value, callback) {
    User.find()
        .where('username').equals(value)
        .exec(function (err, users) {
            if (err) throw err;
            callback(users.length === 0);
        });
});

usersSchema.statics.getByName= function (username, callback) {
    User.findOne({username:username}).exec(function (err, data) {
        if(err){
            console.log(err);
        }else{
            if(callback){
                callback(data);
            }
        }
    });
}

var User = mongoose.model('User', usersSchema);

module.exports=User;
