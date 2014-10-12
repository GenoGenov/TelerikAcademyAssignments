var mongoose = require('mongoose');

var fileSchema = new mongoose.Schema({
    path: {type: String, required: true},
    fileName: {type: String, required: true}
});

var File=mongoose.model('File',fileSchema);

module.exports.schema=fileSchema;

