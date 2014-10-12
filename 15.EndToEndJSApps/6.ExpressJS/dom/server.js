var express=require('express');
var path=require('path');
var app=express();

require('./config/express')(app);
require('./config/mongoose')();
require('./config/passport')();
require('./config/routes')(app);

app.get('/',function(req,res){
    res.render('index',{isAuthenticated:req.isAuthenticated()});
});
console.log('Servel listening on port ' + process.env.port);
app.listen(process.env.port);


