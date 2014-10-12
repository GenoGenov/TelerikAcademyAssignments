var express = require('express');
var passport = require('passport');
var busboy = require('connect-busboy');
var stylus = require('stylus');
var bodyParser = require('body-parser');
var cookieParser = require('cookie-parser');
var path = require('path');
var morgan = require('morgan');
var session = require('express-session');

process.env.PORT = 1234;

module.exports= function (app) {

    app.set('views', path.join(__dirname,'../views'));
    app.set('view engine', 'jade');

    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(session({resave: true, saveUninitialized: true, secret: 'assdfsdgsdgsd'}));
    app.use(stylus.middleware(
        {
            src:  path.normalize(__dirname+'/../public'),
            compile: function (str, path) {
                return stylus(str).set('filename', path);
            }
        }
    ));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(busboy({ immediate: true }));
    app.use(express.static(path.normalize(__dirname+'/../public')));
    app.use(morgan('dev'));
}
