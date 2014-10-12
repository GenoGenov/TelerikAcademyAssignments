var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true },
    password: {type: String, require: '{PATH} is required'}
});

userSchema.method({
    authenticate: function (password) {
        return password === this.password;
    }
});

var User = mongoose.model('User', userSchema);

module.exports.schema = userSchema;