var mongoose = require('mongoose'),
    user = require('../models/User');
    file = require('../models/File');

module.exports = function () {
    mongoose.connect('localhost:27017/FileUpload');
    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...')
    });

    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });
};