var http = require('http');
var fs = require('fs');
var querystring = require('querystring');
var Guid = require('guid');
var url=require('url');

var fileDict={};

http.createServer(function (req, resp) {
    if (req.url == '/') {
        fs.readFile('./upload.html', 'utf8', function (err, data) {
            if (err) {
                console.log(err);
                resp.end();
            } else {
                resp.write(data);
                resp.end();
            }

        });
    }
    else if (req.url == '/upload') {

        req.setEncoding('binary');

        var body = '';
        var binaryEnd;
        var first = true;
        req.on('data', function (data) {
            if (first) {
                binaryEnd = data.toString().substring(0, data.toString().indexOf('\n') - 1);
            }
            first = false;
            body += data;
        });

        req.on('end', function () {

            var note = querystring.parse(body, '\r\n', ':')

            var fileInfo = note['Content-Disposition'].split('; ');
            for (value in fileInfo) {
                if (fileInfo[value].indexOf("filename=") != -1) {
                    var fileName = fileInfo[value].substring(10, fileInfo[value].length - 1);

                    if (fileName.indexOf('\\') != -1)
                        fileName = fileName.substring(fileName.lastIndexOf('\\') + 1);
                    console.log("WRITE Filename: " + fileName);
                }
            }

            var entireData = body.toString();

            var contentType = note['Content-Type'].substring(1);


            var upperBoundary = entireData.indexOf(contentType) + contentType.length;
            var shorterData = entireData.substring(upperBoundary);
            var binaryDataAlmost = shorterData.replace(/^\s\s*/, '').replace(/\s\s*$/, '');


            var binaryData = binaryDataAlmost.substring(0, binaryDataAlmost.indexOf('------WebKitFormBoundary'));
            var guid = Guid.create();
            console.log('WRITE: '+guid.value);
            fs.mkdir('./files/' + guid.value, function (err) {
                if (err) {
                    console.log(err);
                }
                fs.writeFile('./files/' + guid.value + '/' + fileName, binaryData, 'binary', function (err) {
                    resp.write('<h1>Success!<h1>');
                    resp.write('<strong>Your file can be downloaded from this link: '+'http://localhost:1234/download/'+guid.value);
                    fileDict[guid.value]=fileName;
                    resp.end();

                });
            });

        });


    }

    else if(req.url.indexOf('/download')==0){



        var guid = url.parse(req.url).pathname.substring(10);

        if(!fileDict[guid]){
            resp.writeHead(404);
            resp.write('No such file link exists here!');
            resp.end();
        }
        else{
            var filePath='./files/'+guid+'/'+fileDict[guid];
            fs.stat(filePath, function (err,st) {
                if(err){
                    console.log(err);
                }
                console.log('GET: '+guid);
                resp.writeHead(200, {
                    'Content-Length': st.size
                });

                fs.createReadStream(filePath).pipe(resp).on('finish', function () {
                    console.log('READ: '+filePath);
                });



            });
        }



    }


}).listen(1234);
console.log('Listening on port 1234');