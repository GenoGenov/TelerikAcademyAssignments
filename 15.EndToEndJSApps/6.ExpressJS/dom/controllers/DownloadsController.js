var File = require('mongoose').model('File');
var fs=require('fs');
var path=require('path');

function showUrl(req,res,next) {
    var fileId=req.params.fileId;
    res.render('your-url',{fileUrl:'http://localhost:1234/download/'+fileId});
}

function downloadFile(req,res,next) {
    var fileId=req.params.fileId;

    File.findOne({_id:fileId}).exec(function (err, file) {
        if(err) res.status(400).send(err);
        else{
            var filePath = path.normalize(__dirname + '/../files/' + file.fileName);
            var readable=fs.createReadStream(filePath);
            //readable.pipe(res);
            res.download(filePath);
        }

    });

}

module.exports={
    showUrl:showUrl,
    downloadFile:downloadFile
}