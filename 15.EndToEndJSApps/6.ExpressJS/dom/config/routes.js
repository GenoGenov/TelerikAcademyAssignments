var auth = require('./auth');
var controllers = require('../controllers');

module.exports = function (app) {
    app.delete('/api/users/:id', auth.isAuthenticated, controllers.users.deleteUser);
    app.post('/register', controllers.users.createUser);
    app.post('/login',auth.login);

    app.get('/upload',auth.isAuthenticated,controllers.uploads.showForm);
    app.post('/upload',auth.isAuthenticated,controllers.uploads.createFile);
    app.get('/your-url/:fileId',auth.isAuthenticated,controllers.downloads.showUrl);
    app.get('/download/:fileId',auth.isAuthenticated,controllers.downloads.downloadFile);
};
