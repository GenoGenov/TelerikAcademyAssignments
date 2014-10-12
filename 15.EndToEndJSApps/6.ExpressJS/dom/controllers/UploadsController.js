var File = require('mongoose').model('File');
var fs=require('fs');

function getFile(req, res, next) {
    var fstream;
    req.pipe(req.busboy);

    var newFile = new File();

    req.busboy.on('file', function (fieldname, file, filename) {
        var path = __dirname + '/../files/' + filename;

        newFile.path = path;
        newFile.fileName = filename;

        fstream = fs.createWriteStream(path);
        file.pipe(fstream);
    });

    req.busboy.on('field', function (fieldname, val) {
    });

    req.busboy.on('finish', function () {
        newFile.save(function (err, file) {
            if(err) res.status(400).send(err);

            res.redirect('/your-url/'+file._id);
        });

    });
}

function showForm(req,res,next) {
    res.render('file-upload');
}

module.exports={
    createFile:getFile,
    showForm:showForm
}
